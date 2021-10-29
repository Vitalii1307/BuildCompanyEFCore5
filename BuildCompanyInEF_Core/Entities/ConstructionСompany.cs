﻿using BuildCompanyInEF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core
{
    class ConstructionСompany
    {
        public int ConstructionСompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Owner { get; set; }
        public int USREOUCode { get; set; }
        public List<Department> Departments { get; set; }
        public List<Order> Orders { get; set; }
    }
}
