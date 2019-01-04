using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Employee : IEmployee
    {
        public Employee()
        {
        }

        public Employee(string nm,string Desig)
        {
            Name = nm;
            designation = Desig;
        }
        public int EmpID { get ; set ; }
        public string Name { get ; set ; }
        public string designation { get; set ; }
    }
}
