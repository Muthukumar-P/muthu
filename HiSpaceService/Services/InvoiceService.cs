using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiSpaceModels;
using HiSpaceService.Models;

namespace HiSpaceService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HiSpaceContext _context;

		public InvoiceService(HiSpaceContext context)
		{
			_context = context;
		}

        public async Task<ServiceResult<Invoice>> Get(int memberBookingSpaceID)
        {   
            MemberBookingSpace bookedSpace = await GetBookedSpace(memberBookingSpaceID);         
            ServiceResult<Invoice> serviceResult = new ServiceResult<Invoice>();

            if (bookedSpace == null)
			{
                 serviceResult.IsSuccess = false;
                 serviceResult.Message = "booking not found";
                 serviceResult.Result = null;
            return serviceResult;
            }            
            
            if(bookedSpace.IsInvoiceCreated)
                serviceResult.Result = await GetCreatedInvoice(memberBookingSpaceID);
                
                serviceResult.Result = await GenerateInvoice(bookedSpace);
                serviceResult.IsSuccess = true;
                serviceResult.Message = "invoice added";
            return serviceResult;
        }

        public async Task<ServiceResult<Invoice>> Add(Invoice invoice)
        {
        MemberBookingSpace bookedSpace = await (from MBS in _context.MemberBookingSpaces
                                        where MBS.MemberBookingSpaceID == invoice.MemberBookingSpaceID
                                        && MBS.BookingStatus == "Approved"
                                        select MBS)
                                            .SingleOrDefaultAsync();
        ServiceResult<Invoice> serviceResult = new ServiceResult<Invoice>();

            if (bookedSpace == null)
			{
                 serviceResult.IsSuccess = false;
                 serviceResult.Message = "booking not found";
                 serviceResult.Result = null;
            return serviceResult;
            }
				
			try
			{
				_context.Invoices.Add(invoice);
				bookedSpace.IsInvoiceCreated = true;
				int recordsAffected = await _context.SaveChangesAsync();
				
			if(recordsAffected > 0)
            {
                serviceResult.IsSuccess = true;
                serviceResult.Message = "invoice added";
                serviceResult.Result = invoice;
            return serviceResult;
            }

                serviceResult.IsSuccess = false;
                 serviceResult.Message = "invoice not added";
                 serviceResult.Result = null;
			}
			catch(Exception ex)
			{				
                 serviceResult.IsSuccess = false;
                 serviceResult.Message = "exception ocurred";
                 serviceResult.Result = null;                        
			}
			return serviceResult;
        }

        async Task<Invoice> GenerateInvoice(MemberBookingSpace bookedSpace)
        {            
            Invoice invoice = new Invoice();
            List<MemberBookingSpaceSeat> bookedSpaceSeats = GetBookedSpaceSeats(bookedSpace.MemberBookingSpaceID);
            bool isSeatBooking = IsSeatBooking(bookedSpaceSeats);		
			if (isSeatBooking)
            invoice.SeatCost = bookedSpaceSeats.Sum(n => n.SeatPrice ?? 0); 
			else
            invoice.SpaceCost = bookedSpace.SpacePrice;
            
            double totalAddOnsCost = await GetTotalAddOnsCost(bookedSpace.MemberBookingSpaceID);
            double totalfacilitiesCost = await GetTotalFacilitiesCost(bookedSpace.MemberBookingSpaceID);

            invoice.FacilitiesTotal = totalAddOnsCost + totalfacilitiesCost;
			invoice.TotalCost = (isSeatBooking ? invoice.SeatCost : invoice.SpaceCost) + 										invoice.FacilitiesTotal;
            return invoice;
        }

        async Task<MemberBookingSpace> GetBookedSpace(int memberBookingSpaceID)
        {
        MemberBookingSpace bookedSpace = await (from MBS in _context.MemberBookingSpaces
                            where MBS.MemberBookingSpaceID == memberBookingSpaceID
                            && MBS.BookingStatus == "Approved"
                            select MBS)
                                    .SingleOrDefaultAsync();
        return bookedSpace;
        }
        bool IsSeatBooking(List<MemberBookingSpaceSeat> bookedSpaceSeats)
        {
            bool isSeatBooking = false;
            if (bookedSpaceSeats.Count > 0)
                isSeatBooking = bookedSpaceSeats.Any(n => n.SeatPrice != null);
        return isSeatBooking;
        }

        List<MemberBookingSpaceSeat> GetBookedSpaceSeats(int memberBookingSpaceID)
		{
			return (from seat in _context.MemberBookingSpaceSeats
                                where seat.MemberBookingSpaceID == memberBookingSpaceID
								&& seat.SeatStatus == "Approved"
                                select seat).ToList();
		}

        async Task<Invoice> GetCreatedInvoice(int memberBookingSpaceID)
        {
        Invoice invoice = await _context.Invoices
			                .Where(n => n.MemberBookingSpaceID == memberBookingSpaceID)
			                .SingleOrDefaultAsync();
		return invoice;		
        }

        double AmountAfterDiscount(double actualPrice, double discountPercent)
		{
			return (1 - discountPercent/100) * actualPrice;
		}

        double CostForQuantity(double unitPrice, double quantity)
		{
			return unitPrice * quantity;
		}

        async Task<double> GetTotalAddOnsCost(int memberBookingSpaceID)
        {
           List<FacilityAddOn> bookedAddOns = await (from addOn in _context.FacilityAddons
											where addOn.MemberBookingSpaceID == memberBookingSpaceID 
											&& addOn.IsIncludeInInvoice
											select addOn).ToListAsync();

            double totalCost = 0;
			double amountAfterDiscount = 0;
			double actualCost = 0;
			if(bookedAddOns.Count > 0)
			foreach(FacilityAddOn addOn in bookedAddOns)
			{
				actualCost = CostForQuantity(addOn.ActualCost, addOn.Quantity);
				amountAfterDiscount = AmountAfterDiscount(actualCost, addOn.DiscountPercent);
				totalCost = totalCost + amountAfterDiscount;
			}
			return totalCost;
        }

        async Task<double> GetTotalFacilitiesCost(int memberBookingSpaceID)
        {
            var bookedFacilities = await (from fb in _context.FacilityBookings
                                    join cf in _context.ClientFacilities
                                    on fb.ClientFacilityID equals cf.ClientFacilityID
                                    join fy in _context.FacilityMasters
                                    on cf.FacilityID equals fy.FacilityID
                                    where fb.MemberBookingSpaceID == memberBookingSpaceID 
                                    && fb.IsIncludeInInvoice
                                    select new {FacilityBooking = fb,
                                        ClientFacility = cf,
                                        FacilityMaster = fy}).ToListAsync();
        	double totalCost = 0;
            double amountAfterDiscount = 0;
			double actualCost = 0;
			if(bookedFacilities.Count > 0)
			foreach(var bookedFacility in bookedFacilities)
			{
				FacilityBooking booking = bookedFacility.FacilityBooking;
				actualCost = CostForQuantity(booking.ClientFacility.PaidAmenityPrice, booking.Quantity);
				amountAfterDiscount = AmountAfterDiscount(actualCost, booking.DiscountPercent);
				totalCost = totalCost + amountAfterDiscount;
			}
			return totalCost;
        }
    }
}