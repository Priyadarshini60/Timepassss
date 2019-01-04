using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm
{
    class Employee : IEmployee
    {
        public Employee(string v1, string v2)
        {
        }

        public int EmpID { get ; set ; }
        public string EmpName { get ; set; }
        public string EmpDesign { get ; set ; }
    }
}
