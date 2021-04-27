using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}