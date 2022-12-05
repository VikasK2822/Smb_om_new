using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface Iemail
    {
        public int InsertEmail(string to, string from, string subject, string body, string mailtype, string createdby, string ordernumber, int ismailsent = 1);
        public int sendmail(string to, string from, string subject, string body, string mailtype, string createdby, string ordernumber);
    }
}
