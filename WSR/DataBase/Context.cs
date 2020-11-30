using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WSR.DataBase.Models;

namespace WSR.DataBase
{
    public class Context : DbContext
    {
        public Context()
            : base("DBConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<OrderNom> OrderNoms { get; set; }

        public DbSet<Сourier> Сouriers { get;  set; }
    }
}