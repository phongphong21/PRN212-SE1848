using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_Reuse_OOP2
{
    public static class YourUtils
    {
        public static int Tuoi(this Employee emp)
        {
            return DateTime.Now.Year - emp.Birthday.Year;
        }
        //viết extension method tháng này có phải sinh nhật của nhân viên hay không
        public static bool IsBirthdayMonth(this Employee emp)
        {
            return emp.Birthday.Month == DateTime.Now.Month;
        }
    }
}
