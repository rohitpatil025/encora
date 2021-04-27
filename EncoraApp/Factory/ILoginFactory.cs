using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Factory
{
    public interface ILoginFactory
    {
        Models.UserModel Login(Models.UserModel user);
    }
}