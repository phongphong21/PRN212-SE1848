using DemoAliasClone;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Customer c1 = new Customer
{
    Id = 1,
    Name = "John Doe"
};
Customer c2 = new Customer
{
    Id = 2,
    Name = "Jane Smith"
};

c1 = c2;
//c1 trỏ tới vùng nhớ mà c2 đang quản lý chứ ko phải c1=c2
// lúc này xảy ra 2 tình huống:
//1. ô nhớ alpha mà c1 quản lí lúc này bị trống, không còn đối tượng tham gia quản lí nữa
//=> hệ điều hành sẽ thu hồi ô nhớ alpha này 
// gọi là cơ chế gom rác tự động : Automatic Garbage Collection
// ta không thể nào lấy được giá trị tại ô nhớ này nữa
//2. Lúc này ô nhớ beta sẽ có 2 đối tượng tham gia quản lí 
//- đối tượng ban đầu là c2
//- bây h có thêm đối tượng c1 quản lí
// trường hợp 1 ô nhớ từ 2 đối tượng tham gia quản lí, nó được gọi là Alias:
//-> bất kì 1 đối tượng nào thay đổi giá trị tại ô nhớ Beta thì đối tượng còn lại đều bị ảnh hưởng
c1.Name = "hồ đồ";
//thì lúc này c2 cũng đổi tên thành "hồ đồ"
Console.WriteLine("Tên của c2" +c2.Name);

Customer c3 = new Customer();
Customer c4 = c3;
c3 = c1;


Product p1 = new Product { Id = 1, Name = "P1", quantity = 10, Price = 20 };

Product p2 = new Product { Id = 2, Name = "P2", quantity = 15, Price = 22 };

p1 = p2;
Console.WriteLine("------Thông tin của p1------");
Console.WriteLine(p1);
Console.WriteLine("------Thông tin của p2------");
Console.WriteLine(p2);

p2.Name ="Thuốc trị ho";
p2.quantity = 50;
p2.Price = 100;

Console.WriteLine("------Thông tin của p1 sau khi thay đổi p2------");
Console.WriteLine(p1);

Product p3 = new Product { Id = 3, Name = "P3", quantity = 15, Price = 22 };
Product p4 = new Product { Id = 4, Name = "P4", quantity = 15, Price = 22 };

Product p5 = p3;
p3 = p4;
//HĐH có thu hôi ô nhớ đã cấp phát cho p3 quản lí trước đó hay không? vì sao?
// nếu bổ sung :
p5 = p3;
//thì có thu hồi ô nhớ đã cấp phát cho p3 hay không? vì sao?

Product p6 = p4.Clone();
//HĐH sao chép toàn bộ dữ liệu trong ô nhớ à p4 đang quản lý qua 1 ô nhớ mới
//và giao nó cho p6 quản lý ô nhớ mới này :
//p4 và p6 quản lý 2 ô nhớ hoàn toàn khác nhau , nhưng có giá trị giống nhau
//==> p6 đổi không liên quan p4 và ngược lại 
Console.WriteLine("Thông tin của p4");
Console.WriteLine(p4);
Console.WriteLine("Thông tin của P6");
Console.WriteLine(p6);
p4.Name = "thuốc trị xàm ";
Console.WriteLine("Thông tin của p4");
Console.WriteLine(p4);
Console.WriteLine("Thông tin của P6");
Console.WriteLine(p6);
