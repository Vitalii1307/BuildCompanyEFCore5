using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class Equipment
    {
        public int EquipmentId{ get;set; }
        public string Name{ get;set; }
        public string Model{ get;set; }
        public string Manufacturer{ get;set; }
        public int SerialNumber{ get;set; }

        public List<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();

    }
}
