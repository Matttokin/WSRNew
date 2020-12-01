using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSR.DataBase;
using WSR.DataBase.Models;

namespace WSR.Controllers
{
    public class WebController : ApiController
    {
        public string Get(string fio, string login, string password, string role)
        {
            Context db = new Context();
            var rol = db.Roles.FirstOrDefault(x => x.Name.Equals(role));

            if (rol == null) return "Роль не найдена";

            db.Users.Add(new DataBase.Models.User { FIO = fio, Login = login, Password = password, RoleId = rol.Id }) ;
            db.SaveChanges();
            return "Успешно";
        }
    }
}
