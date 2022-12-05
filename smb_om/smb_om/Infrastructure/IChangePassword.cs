using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface IChangePassword
    {
        public int ChangePassword(string uid, string pass, string update_by);

        public bool CheckUid(string uid, string pass);

    }
   
}
