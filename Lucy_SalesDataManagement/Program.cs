using Lucy_SalesDataManagement;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
//khai báo chuỗi kết nối sql
string connectionString = @"server=DESKTOP-OCQM1EP\SQLEXPRESS;database=Lucy_Salesdata;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);
//Q1: lọc ra toàn bộ khách hàng 
var ds = context.Customers.ToList();
foreach(var d in ds)
{
    Console.WriteLine(d.CustomerID+"\t"+ d.ContactName);
}
//Q2: tìm kiếm danh sách khách hàng khi biết mã 
int ma = 10;
Customer cust = context.Customers.FirstOrDefault(x => x.CustomerID==ma);
if(cust != null)
{
    Console.WriteLine(cust.CustomerID +"\t"+ cust.ContactName);
}
//Q3: lọc ra danh sách các hóa đơn của khách hàng 
// các cột dữ liệu gồm: mã hóa đơn + ngày hóa đơn
if(cust != null)
{
    var dshd= cust.Orders.Select(od => new {od.OrderID,od.OrderDate}).ToList();
    var dshd2 = from od in cust.Orders select new { od.OrderID, od.OrderDate, };
    Console.WriteLine("Danh sách hóa đơn khách hàng : ");
    foreach(var od in dshd)
    {
        Console.WriteLine(od.OrderID +"\t"+ od.OrderDate.ToString("dd/MM/yyyy"));
    }
}
//Câu 4 : từ kết quả của Q3 . Bổ sung thêm cột Trị giá của đơn hàng cho mỗi hóa đơn 
if(cust != null)
{
    var dshd = cust.Orders.Select(od => new
    {
        od.OrderID,
        od.OrderDate,
        TotalValue = od.Order_Details.Sum(odd => odd.Quantity * odd.UnitPrice * (1 - (decimal)odd.Discount))
    });
    Console.WriteLine("\nDanh sách hóa đơn khách hàng : ");
    foreach (var od in dshd)
    {
        Console.WriteLine(od.OrderID + "\t" + od.OrderDate.ToString("dd/MM/yyyy")+"\t"+od.TotalValue);
    }
}

