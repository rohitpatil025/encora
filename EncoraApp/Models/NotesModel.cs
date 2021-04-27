using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncoraApp.Models
{
    public class NotesModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool isArchived { get; set; }
    }
}