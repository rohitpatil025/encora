using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Factory
{
    public class FormsLogin : ILoginFactory
    {
        public Models.UserModel Login(Models.UserModel user)
        {
            //user name and password validated with database entries (password is plain text here not used any encrytion )
            using (entity.encoraEntities context = new entity.encoraEntities())
            {
                bool IsValidUser = context.users.Any(o => o.userName.ToLower() ==
                     user.UserName.ToLower() && o.password == user.UserPassword);
                if (IsValidUser)
                {
                    var userDetails = context.users.Where(o => o.userName.ToLower() ==
                     user.UserName.ToLower() && o.password == user.UserPassword).FirstOrDefault();
                    user.ID = userDetails.id;
                    user.Created = userDetails.created;
                    user.Modified = userDetails.modified;
                    return user;
                }
                user.ErrorMessage = "invalid Username or Password";
            }
            return user;
        }
    }
}