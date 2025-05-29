using OOP1;
using System.ComponentModel.DataAnnotations;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
//tạo đối tượng Category
Category category1 = new Category();
category1.Id = 1;
category1.Name = "Nước Nắm";
//xuất thông tin = cách gọi hàm
category1.PrintInfor();
//giả sử ta đổi gtri trong ô nhớ đó 
category1.Name = "Thuốc trị diệm ka";
Console.WriteLine("Sau khi đổi giá trị :");
category1.PrintInfor();
//sử dụng lớp Employee
Console.WriteLine("-------EMPLOYEE-------");
Employee employee1 = new Employee();
employee1.Id = 1;//gọi setter property của id
employee1.Idcard = "001";
employee1.Name = "Phong";
employee1.Email = "phong@gmail.com";
employee1.Phone = "0912345678";
//xuất thông tin
employee1.PrintInfor();
Employee employee2 = new Employee()
{
    Id=2,
    Idcard="002",
    Name="Duy",
    Email="duy@gmail.com",
    Phone="0123456789"
};
Console.WriteLine("-------Employee 2-----");
employee2.PrintInfor();

Employee employee3 = new Employee();
Console.WriteLine("-------Employee 3-----");
employee3.PrintInfor();

//tạo employee 4
Console.WriteLine("-------Employee 4-----");
Employee employee4 = new Employee(4, "004", "a", "a@gmail.com", " 0432124235");
employee4.PrintInfor();
Console.WriteLine("-------Employee 4.c2-----");
Console.WriteLine(employee4);//tự động gọi hàm to string

Console.WriteLine("=======Customer 1======");
Customer customer1 = new Customer()
{
    Id = "cus1",
    Name = " lê Giang ",
    Email = "giang@gmail.com",
    Phone = "012423",
    Address = "hcm"

};
customer1.PrintInfor();
customer1.Address = "hn";
Console.WriteLine("after");

