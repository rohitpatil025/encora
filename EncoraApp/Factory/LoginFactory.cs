using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Factory
{
    public abstract class LoginFactory
    {
        public abstract ILoginFactory GetLogin(string loginType);  
    }
}