using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class EmailPendingAwaitingDocuments
    {
        public static string EmailHeader(string ContactName)
        {

            string subject = "Information Required to prevent Cancellation - Call 844-591-4852" + ContactName;
            return subject;
        }

        public static string EmailBody(string HEaderSalutation, string ordernumber, string SellerID, string productname, string CancelNrfcDays, string productWithDifferentStatus, string billingServiceaddress, string serviceaddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(HEaderSalutation);
            sb.AppendLine(ordernumber);
            sb.AppendLine(SellerID);
            sb.AppendLine("IMPORTANT: In order to process your request for " + productname + ", please contact AT&T Concierge at 844-591-4852.");
            sb.AppendLine("Please note that your order will be automatically cancelled if we do not hear from you in  " + CancelNrfcDays + ", please contact AT&T Concierge at 844-591-4852.");
            sb.AppendLine(productWithDifferentStatus);
            sb.AppendLine(billingServiceaddress);
            sb.AppendLine(serviceaddress);
            sb.AppendLine("Reminders");

            sb.AppendLine("If revisions are needed to your account and/or PIN, please visit att.com.");
            sb.AppendLine("Thanks again for choosing AT&T,");
            sb.AppendLine("AT&T Concierge 844.591.4852 Monday - Friday: 10:00 am - 6:30 pm ET");
            sb.AppendLine("Questions?");
            sb.AppendLine("Please use the contact information above for questions regarding this message.This is an automated email so replies to the address will not be answered.");
            sb.AppendLine("Privacy Policy - Terms of Service - Internet");
            sb.AppendLine("©2022 AT & T Intellectual Property.All Rights Reserved.AT & T, Globe logo, and all other AT & T marks contained herein are trademarks of AT & T Intellectual Property and / or AT & T affiliated companies.All other marks are the property of their respective owners.");
            return sb.ToString();

        }
    }
}
