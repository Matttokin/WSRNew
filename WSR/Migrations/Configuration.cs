namespace WSR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WSR.DataBase;
    using WSR.DataBase.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WSR.DataBase.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WSR.DataBase.Context context)
        {

            createRole(context, "Менеджер по продажам");
            createRole(context, "Работник склада");
            createRole(context, "Менеджер по доставке");
            createRole(context, "Курьер");

            createNom(context, "Кактус", 1);
            createNom(context, "Велик", 2);
            createNom(context, "Гелик", 99);
            createNom(context, "Антивелик", 7);
            createNom(context, "АнтиГелиВелик", 4);
            createNom(context, "Кот", 1);

        }
        public void startSeed()
        {
            Seed(new Context());
        }
        public void createRole(WSR.DataBase.Context db, string nameRole)
        {
            var rol = db.Roles.FirstOrDefault(x => x.Name.Equals(nameRole));

            if (rol == null)
            {
                db.Roles.Add(new Role { Name = nameRole });
                db.SaveChanges();
            }
        }

        public void createNom(WSR.DataBase.Context db, string nameNom, int count)
        {
            var rol = db.Nomenclatures.FirstOrDefault(x => x.Name.Equals(nameNom));

            if (rol == null)
            {
                db.Nomenclatures.Add(new Nomenclature { Name = nameNom, Count = count });
                db.SaveChanges();
            }
        }
    }
}
