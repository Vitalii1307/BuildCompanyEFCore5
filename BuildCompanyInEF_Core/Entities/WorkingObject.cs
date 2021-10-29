using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class WorkingObject
    {
        public int WorkingObjectId { get; set; }
        public string InventoryEquipment { get; set; }
        public string Area { get; set; }
        public DateTime Deadline { get; set; }
        public List<Order> Orders { get; set; }
    }
}
