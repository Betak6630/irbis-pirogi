﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Irbis.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
    }
}