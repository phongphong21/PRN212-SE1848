using OOP2;
using OOP4_Reuse_OOP2;
using System.Runtime.CompilerServices;
using System.Text;

Console.OutputEncoding= Encoding.UTF8;

FulltimeEmployee fe = new FulltimeEmployee();
fe.Id = 1;
fe.Name = "Nguyen Van A";
fe.IdCard = "1234";
fe.Birthday = new DateTime(1990, 5, 1);
Console.WriteLine(fe);
Console.WriteLine($"Tuổi: {fe.Tuoi()}");

if (fe.IsBirthdayMonth())
{
    Console.WriteLine("Tháng này là sinh nhật của nhân viên");
}
else
{
    Console.WriteLine("Tháng này không phải là sinh nhật của nhân viên");
}
