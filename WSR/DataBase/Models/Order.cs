using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSR.DataBase.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Status { get; set; }
        public ICollection<OrderNom> OrderNoms { get; set; }

        
    }
}