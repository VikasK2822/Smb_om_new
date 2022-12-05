using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace smb_om.Infrastructure
{
   public interface Ilogin
    {
        public IQueryable<UserManager> ValidateUser(string uid, string pass);
        public IQueryable<OrderManagerLogin> ValidateUserlogin(string uid, string pass);
        
        public UserManager ValidateUser1(string uid, string pass);
        public IQueryable<OrderManagerLogin> ValidateUserom(string uid, string pass);

    }
}
