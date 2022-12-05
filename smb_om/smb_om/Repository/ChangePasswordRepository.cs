using Microsoft.EntityFrameworkCore;
using smb_om.Data;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Repository
{
    public class ChangePasswordRepository : IChangePassword
    {
        private readonly DataContext _context;

        public ChangePasswordRepository(DataContext context)
        {
            this._context = context;
        }

     

        public int ChangePassword(string uid, string pass,string update_by)
        {
            var entity = _context.OrderManagerLogin.FirstOrDefault(item => item.UserId == uid);
            var model = new OrderManagerLogin
            {
                UserId = uid,
                Password = pass,
                Updated_by = update_by,
                Updated_Date = DateTime.UtcNow,
                Created_Date = DateTime.UtcNow
            };

            if (entity != null)
            {
                //entity.Password = pass;
                //entity.Updated_by = update_by;

                //  _context.Attach(model);
                entity.Password = pass;
                entity.Updated_by = update_by;

                entity.Updated_Date = DateTime.UtcNow;
                entity.Created_Date = DateTime.UtcNow;
                _context.OrderManagerLogin.Update(entity);
                 return _context.SaveChanges();


            }

            return 0;

           
        }

        public bool CheckUid(string uid, string pass)
        {
            var IQueryablevalidateUser = (from _user in _context.OrderManagerLogin
                                          where _user.UserId == uid && _user.Password == pass
                                          select _user
                             ).Count();

            if (IQueryablevalidateUser > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
