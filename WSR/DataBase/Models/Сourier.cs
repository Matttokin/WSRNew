﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSR.DataBase.Models
{
    public class Сourier
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public Order Order { get; set; }

        public int? OrderId { get; set; }
    }
}