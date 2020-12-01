using Newtonsoft.Json;
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
    public class GetTokenController : ApiController
    {
        
        public ExportUser Post(string login, string password)
        {
            Context db = new Context();

            var user = db.Users.FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password) && x.Role.Name.Equals("Курьер")) ;
            if(user == null)
            {
                return null;
            } else
            {
                ExportUser u = new ExportUser { FIO = user.FIO, Token = user.Token };
                return u;
            }
        }
    }
    public class ExportUser
    {
        public string FIO { get; set; }
        public string Token { get; set; }
    }
}
