using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class FulltimeEmployee : Employee
    {
        override public double calSalary()
        {
            return base.calSalary()+5000000; // Salary for a full-time employee
        }
    }
}
