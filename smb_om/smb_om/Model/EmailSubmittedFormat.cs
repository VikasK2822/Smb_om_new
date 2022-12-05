using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class EmailSubmittedFormat
    {
        public static string EmailHeader(string ContactName)
        {

            string subject = "AT&T Order being Processed  " + ContactName;
            return subject;
        }

        public static string EmailBody(string HEaderSalutation, string ordernumber, string SellerID, string productname, string CancelNrfcDays, bool productWithDifferentStatus, Address addressbilling, Address addressService)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hello," + HEaderSalutation);
            sb.AppendLine(ordernumber);
            sb.AppendLine(SellerID);
            sb.AppendLine("We were not able to process your order.  Additional information is required in order to process your order. ");
            sb.AppendLine("IMPORTANT: In order to process your request for " + productname + ", please contact AT&T Concierge at 844-591-4852.");
            sb.AppendLine("Please note that your order will be automatically cancelled if we do not hear from you in  " + CancelNrfcDays + ", please contact AT&T Concierge at 844-591-4852.");
            sb.AppendLine("If you have ordered at least one other item, you will be receiving another email shortly regarding the balance of your order.");
            sb.AppendLine("Your billing address is:");
            sb.AppendLine("Billing Address");
            sb.AppendLine(addressbilling.Apartment_Value);
            sb.AppendLine(addressbilling.Assigned_Street_Number);
            sb.AppendLine(addressbilling.Level_Value);
            sb.AppendLine(addressbilling.City);
            sb.AppendLine(addressbilling.State);
            sb.AppendLine(addressbilling.Zip);
            sb.AppendLine("");
            sb.AppendLine("Service Address");
            sb.AppendLine(addressService.Apartment_Value);
            sb.AppendLine(addressService.Assigned_Street_Number);
            sb.AppendLine(addressService.Level_Value);
            sb.AppendLine(addressService.City);
            sb.AppendLine(addressService.State);
            sb.AppendLine(addressService.Zip);

            sb.AppendLine("AT&T Concierge 844.591.4852 Monday - Friday: 10:00 am - 6:30 pm ET");
            sb.AppendLine("If you are a tax exempt organization, please visit www.att.com/taxexempt to register your status with AT&T once your services have been activated.");
            sb.AppendLine("Questions?");
            sb.AppendLine("Please use the contact information above for questions regarding this message.This is an automated email so replies to the address will not be answered.");
            sb.AppendLine("Privacy Policy - Terms of Service - Internet");
            sb.AppendLine("©2022 AT & T Intellectual Property.All Rights Reserved.AT & T, Globe logo, and all other AT & T marks contained herein are trademarks of AT & T Intellectual Property and / or AT & T affiliated companies.All other marks are the property of their respective owners.");
            return sb.ToString();

        }
    }
}
