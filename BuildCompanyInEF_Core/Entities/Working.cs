using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class Working
    {
        public int WorkingId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdentificationCode { get; set; }
        public string Nationality { get; set; }
        public string Specialty { get; set; }
        public int PhoneNumber { get; set; }
        public int Salary { get; set; }
        public List<Brigade> Brigades { get; set; } = new List<Brigade>();
        public List<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();
    }
}
