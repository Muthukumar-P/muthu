using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HiSpaceService.Utilities
{
    public static class InternetSMS
    {
        static string user = "karthick@highbrowdiligence.com";
        static string password = "Onecrore@1";
        static string sender = "TEST SMS";

        public static string Send()
        {            
            string receipient = "8056997213,9840352595,8438532205,9677379622";
            //string receipient = "8056997213,9866047323";
            string OTP = GenerateOTP();
            string message = "Dear Customer, Welcome to HiSpace! Your OTP is " + OTP + " for activate your login. (Ref.ID-002354623). Dated on " + DateTime.Now.ToString();

            string internetSmsUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose";
            internetSmsUrl += "?";
            internetSmsUrl += "user=" + user + ":" + password + "&";
            internetSmsUrl += "senderID=" + sender + "&";
            internetSmsUrl += "receipientno=" + receipient + "&";
            internetSmsUrl += "dcs=0&";
            internetSmsUrl += "msgtxt=" + message + "&";
            internetSmsUrl += "state=1";
            //State = 0 - User can add a custom message of his / her choice, e.g. “Thanks for submitting your response”.
            //State = 1 - User can send sms to multiple numbers(9810028310, 9837371812,…), unique transaction id are generated for each mobile number on successful submission.
            // State = 2 - On sending messages to multiple numbers, this will return a unique Job ID for the campaign.
            //State = 3 - On sending messages to multiple numbers, this will return a unique Job ID for the campaign along with multiple Transaction id
            //  State = 4 - User can send messages to a single mobile number; on successful submission a unique Transaction id is generated.

            // Create a request object  
            WebRequest request = HttpWebRequest.Create(internetSmsUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();

            return dataString;
        }

        public static string GenerateOTP()
        {
            string otp = "";
            int otpLength = 6;
            for (int i = 0; i < otpLength; i++)
                otp += new Random().Next(0, 9).ToString();
            return otp;
        }
    }
}
