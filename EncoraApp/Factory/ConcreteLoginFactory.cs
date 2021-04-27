using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Factory
{
    public class ConcreteLoginFactory : LoginFactory
    {
        public override ILoginFactory GetLogin(string loginType)
        {
            switch (loginType)
            {
                case "form":
                    return new FormsLogin();
                default:
                    throw new ApplicationException(string.Format("'{0}' Login method not implemented ", loginType));
            }
        }

    }
}