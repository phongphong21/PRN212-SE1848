using System.Text;

Console.OutputEncoding=Encoding.UTF8;
void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
int n = 5;
Console.WriteLine($"n trước khi vào hàm = {n}");
ham1(n);
Console.WriteLine($"n sau khi vào hàm = {n}");

void ham2(ref int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
Console.WriteLine("---------------");
n = 5;
Console.WriteLine($"n trước khi vào hàm = {n}");
ham2(ref n);
Console.WriteLine($"n sau khi vào hàm = {n}");
//ref yêu cầu biến ban đầu phải có giá trị , nếu không có sẽ báo lỗi
void ham3 (out int n)
{
    n = 9;
}
Console.WriteLine("---------------");
n = 211;
ham3 (out n);