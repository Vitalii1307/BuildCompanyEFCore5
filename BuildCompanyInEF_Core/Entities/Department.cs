using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Entities
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string NameDepartment { get; set; }
        //public Employee DepartmentManager { get; set; }
        public string Specialization { get; set; }
        public ConstructionСompany ConstructionCompany { get; set; }
        public List<Employee> Employees { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
