using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class EmailOrderConfirmation
    {
        public  string EmailHeader(string ContactName)
        {

            string subject = "AT&T Order Confirmation " + ContactName;
            return subject;
        }

        public  string EmailBody(string HEaderSalutation, string ordernumber, string SellerID, string productname, string CancelNrfcDays, string productWithDifferentStatus, string billingServiceaddress, string serviceaddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<b>"+ HEaderSalutation + "</b>");
            sb.AppendLine(ordernumber);
            sb.AppendLine(SellerID);
            sb.AppendLine("Your request for AT&T " + productname + " has been received. It will be processed within 24 hours. You will then receive another email with an updated status of your order.  We look forward to serving you.");
            sb.AppendLine("Your billing address is:");
            sb.AppendLine("Billing Address");
            sb.AppendLine(billingServiceaddress);
            sb.AppendLine("");
            sb.AppendLine("Service Address");
            sb.AppendLine(serviceaddress);
            sb.AppendLine("Thanks again for choosing AT&T,");
            sb.AppendLine(" AT & T Concierge");
            sb.AppendLine("844.591.4852");
            sb.AppendLine("Monday - Friday: 10:00 am - 6:30 pm ET");
            sb.AppendLine("Questions?");
            sb.AppendLine("Please use the contact information above for questions regarding this message.This is an automated email so replies to the address will not be answered.");
            sb.AppendLine("Privacy Policy - Terms of Service - Internet");
            sb.AppendLine("©2022 AT & T Intellectual Property.All Rights Reserved.AT & T, Globe logo, and all other AT & T marks contained herein are trademarks of AT & T Intellectual Property and / or AT & T affiliated companies.All other marks are the property of their respective owners.");
            return sb.ToString();

        }
    }
}
