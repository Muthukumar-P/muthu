using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiSpaceModels;
using HiSpaceService.Models;

namespace HiSpaceService.Services
{
    public interface IInvoiceService
    {
        Task<ServiceResult<Invoice>> Get(int memberBookingSpaceID);

        Task<ServiceResult<Invoice>> Add(Invoice invoice);
    }
}