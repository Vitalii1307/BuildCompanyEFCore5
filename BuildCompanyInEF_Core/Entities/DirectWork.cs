using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class DirectWork
    {
        public int DirectWorkId { get; set; }
        public string NameWork { get; set; }
        public Brigade Brigade { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Order Order { get; set; }
        public int PriceOf { get; set; }

        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
