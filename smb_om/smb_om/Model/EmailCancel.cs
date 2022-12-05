using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class EmailCancel
    {
      
        public  string EmailHeader (string ContactName)
        {

            string subject = "Information Required to prevent Cancellation - Call 844-591-4852" + ContactName;
            return subject;
        }

        public  string  EmailBody( string  HEaderSalutation, string OrderNumber, string AccountNumber, string SellerID,string productname, string billingServiceaddress, string serviceaddress)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(HEaderSalutation);
            sb.AppendLine("<b>" + OrderNumber + " "+ AccountNumber + "</b>");
            sb.AppendLine(SellerID);
            sb.AppendLine("Thank you for your recent order with AT&T.  Unfortunately, we are unable to process your request for ");
            sb.AppendLine(productname);
            sb.AppendLine("If you would like to move forward with your order, please contact AT&T Concierge at 844-591-4852 or your Sales Person to re-establish.  Otherwise, the original request will remain cancelled.");
            sb.AppendLine(billingServiceaddress );
            sb.AppendLine(serviceaddress);
            sb.AppendLine("<b>Reminders</b>");
            sb.AppendLine("If revisions are needed to your account and/or PIN, please visit att.com.");
            sb.AppendLine("Thanks again for choosing AT&T,");
            sb.AppendLine("AT&T Concierge 844.591.4852Monday - Friday: 10:00 am - 6:30 pm ET");
            sb.AppendLine("Questions?");
            sb.AppendLine("Please use the contact information above for questions regarding this message.This is an automated email so replies to the address will not be answered.");
            sb.AppendLine("Privacy Policy - Terms of Service - Internet");
            sb.AppendLine("©2022 AT & T Intellectual Property.All Rights Reserved.AT & T, Globe logo, and all other AT & T marks contained herein are trademarks of AT & T Intellectual Property and / or AT & T affiliated companies.All other marks are the property of their respective owners.");
            return sb.ToString();

        }

    }
}
