using smb_om.Data;
using smb_om.Infrastructure;
using smb_om.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class LoginRepository : Ilogin
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            this._context = context;
        }
      

        public IQueryable<OrderManagerLogin> ValidateUserom(string uid, string pass)
        {

            var IQueryablevalidateUser = (from _user in _context.OrderManagerLogin
                                          where _user.UserId == uid && _user.Password == pass
                                          select _user
                               );
            //var IQueryablevalidateUser = (from _user in _context.UserManager
            //                                  // where _user.UserId == uid && _user.Password == pass
            //                              select _user
            //                 ).FirstOrDefault();
            //var strings = IQueryablevalidateUser;
            //strings.Password = EncryptionLibrary.DecryptText(strings.Password);
            //IQueryablevalidateUser = strings;


            return IQueryablevalidateUser;
        }

        public IQueryable<UserManager> ValidateUser(string uid, string pass)
        {

            var IQueryablevalidateUser = (from _user in _context.UserManager
                                          where _user.UserId == uid && _user.Password == pass
                                          select _user
                               );
            //var IQueryablevalidateUser = (from _user in _context.UserManager
            //                                  // where _user.UserId == uid && _user.Password == pass
            //                              select _user
            //                 ).FirstOrDefault();
            //var strings = IQueryablevalidateUser;
            //strings.Password = EncryptionLibrary.DecryptText(strings.Password);
            //IQueryablevalidateUser = strings;


            return IQueryablevalidateUser;
        }

        public IQueryable<OrderManagerLogin> ValidateUserlogin(string uid, string pass)
        {

            var IQueryablevalidateUser = (from _user in _context.OrderManagerLogin
                                          where _user.UserId == uid && _user.Password == pass
                                          select _user
                               );
            //var IQueryablevalidateUser = (from _user in _context.UserManager 
            //                                  // where _user.UserId == uid && _user.Password == pass
            //                              select (p => new {p. }) _user
            //                 ).FirstOrDefault();

            //var posts = _context.UserManager
            //             // .Where(p => p.Tags == "<sql-server>")
            //              .Select(p => new UserManager()
            //              {
            //                   UserId = p.UserId ,
            //                  Password = p.Password
                              
            //              }).FirstOrDefault();
           // var strings = IQueryablevalidateUser;
      //      var  = EncryptionLibrary.DecryptText(posts.Password );
          //  IQueryablevalidateUser = strings;


            return IQueryablevalidateUser;
        }

        public UserManager ValidateUser1(string uid, string pass)
        {

            //var IQueryablevalidateUser = (from _user in _context.UserManager
            //                              where _user.UserId == uid && _user.Password == pass
            //                              select _user
            //                   );
            var IQueryablevalidateUser = (from _user in _context.UserManager
                                              // where _user.UserId == uid && _user.Password == pass
                                          select _user
                             ).FirstOrDefault();
            var strings = IQueryablevalidateUser;
            strings.Password = EncryptionLibrary.DecryptText(strings.Password);
            IQueryablevalidateUser = strings;


            return IQueryablevalidateUser;
        }
    }
}
