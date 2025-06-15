using DemoLINQ2SQL;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
//khai báo chuỗi kết nối sql
string connectionString = @"server=DESKTOP-OCQM1EP\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
//câu 1 : truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("---Danh sách danh mục---");
foreach (var d in dsdm)
{
    Console.WriteLine(d.CategoryID+"\t"+d.CategoryName);
}
//câu 2: lấy thông tin chi tiết danh mục khi biết mã 
int madm = 7;
Category cate =context.Categories.FirstOrDefault(c => c.CategoryID == madm);
if(cate == null)
{
    Console.WriteLine("không tìm thấy danh mục có mã = "+ madm);
}else
{
    Console.WriteLine("\nTìm thấy danh mục có mã = " + madm);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}
//câu 3 : dùng Query syntax để truy vấn toàn bộ sản phẩm
var dssp = from p in context.Products
            select p;
Console.WriteLine("\n---Danh sách sản phẩm---");
foreach (var p in dssp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}
//Câu 4: dùng Query syntax và Anonymous type để lọc ra các sản phẩm nhưng chỉ lấy mã sản phẩm và đơn giá, đồng thời sắp xếp giảm dần 
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new { p.ProductID, p.UnitPrice };
Console.WriteLine("\n---Danh sách sản phẩm (chỉ lấy mã và đơn giá)---");
foreach (var p in dssp4)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}
//câu 5 : sửa câu 4 theo extention method (method syntax)
var dssp5 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Select(p => new { p.ProductID, p.UnitPrice });
Console.WriteLine("\n---Danh sách sản phẩm câu 5---");
foreach (var p in dssp5)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}
//câu 6: Lọc ra top 3 sản phẩm có đơn giá cao nhất
var dssp6 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Take(3);
Console.WriteLine("\nDanh sách sản phẩm có đơn giá cao nhất (top 3):");
foreach (var p in dssp6)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}
//câu 7: Sửa danh mục khi biết mã danh mục
int madm_edit = 7;
Category cate_edit = context.Categories.FirstOrDefault(c => c.CategoryID == madm_edit);
if (cate_edit != null)
{
    cate_edit.CategoryName = "Hàng trôi nổi";
    context.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
}
//câu 8 : Xóa danh mục khi biết mã danh mục
int madm_remove = 4;
Category cate_remove = context.Categories.FirstOrDefault(c => c.CategoryID == madm_remove);
if (cate_remove != null)
{
    context.Categories.DeleteOnSubmit(cate_remove);
    context.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
}
//câu 9: xóa các danh mục nếu không có sản phẩm nào 
//lưu ý :xóa cùng 1 lúc nhiều danh mục , mà danh mục này không có chứa bất kì sản phẩm nào
var dssdm_emty_product = context.Categories.Where(c => c.Products.Count() == 0).ToList();
context.Categories.DeleteAllOnSubmit(dssdm_emty_product);
context.SubmitChanges();
//câu 10 : thêm mới 1 danh mục
Category c_new = new Category();
c_new.CategoryName = "Hàng lậu";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();

//câu 11: thêm mới nhiều danh mục 
List<Category> list = new List<Category>();
list.Add(new Category() { CategoryName="Hàng Gia Dụng"});
list.Add(new Category() { CategoryName = "Hàng Điện Tử"});
list.Add(new Category() { CategoryName = "Hàng Phụ Kiện"});
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();