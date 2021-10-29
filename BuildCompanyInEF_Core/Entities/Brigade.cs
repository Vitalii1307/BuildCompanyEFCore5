using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class Brigade
    {
        public int BrigadeId { get; set; }
        //public string Foreman { get; set; }
        public string WorkingDays { get; set; }
        public string WorkShift { get; set; }
        public List<DirectWork> DirectWorks { get; set; }
        public List<Working> Workings { get; set; } = new List<Working>();
        public List<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();

    }
}
