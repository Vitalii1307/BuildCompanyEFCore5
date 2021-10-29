using BuildCompanyInEF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core
{
    class Order
    {
        public int OrderId { get; set; }
        //public int ObjectID { get; set; }
        public int ApproximatePrice { get; set; }
        public DateTime Date { get; set; }
        public string Task { get; set; }
       
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public ConstructionСompany Company { get; set; }
        public WorkingObject WorkingObject { get; set; }
        public List<DirectWork> DirectWorks { get; set; }

    }
}
