﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class ParttimeEmployee:Employee
    {
        public int WorkingHour { get; set; } 
        override public double calSalary()
        {
            return 100000*WorkingHour; 
        }
    }
}
