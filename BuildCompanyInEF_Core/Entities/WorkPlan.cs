using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class WorkPlan
    {
        public int WorkingId { get; set; }
        public Working Working { get; set; }

        public int BrigadeId { get; set; }
        public Brigade Brigade { get; set; }

        public DateTime DateTimeShift { get; set; }
    }
}
