using DemoLINQ2ObjectModelClass;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Để hiển thị tiếng Việt trên console
ListProduct lp = new ListProduct();
lp.gen_products();
//lọc ra các sản phẩm có giá trị từ a đến b
var result = lp.FilterProductsByPrice(100, 200);
Console.WriteLine("các sản phẩm có giá từ 100 đến 200");
result.ForEach(x=> Console.WriteLine(x));

//Câu 2: sắp xếp sản phẩm theoh đơn giá tăng dần 

var result2 = lp.SortProductByPriceAsc2();
Console.WriteLine("\nsau khi sắp xếp giá tăng dần: ");
result2.ForEach(x=> Console.WriteLine(x));

// câu 3 : sắp xếp theo giảm dần
var result3 = lp.SortProductByPriceDesc();
Console.WriteLine("\nsau khi sắp xếp giá giảm dần: ");
result3.ForEach(x => Console.WriteLine(x));

//câu 4 tính tổng các giá trị sp trong kho hàng
Console.WriteLine("\nTổng giá trị kho hàng = " + lp.SumOfValue());
// câu 5 tìm chi tiết sản phẩm khi biết mã sản phẩm 

Product p = lp.SearchProductDetail(3);
if(p!= null)
{
    Console.WriteLine("\nTìm thấy sản phẩm , thông tin cho tiết");
    Console.WriteLine(p);
}
else
{
    Console.WriteLine("\nkhông tìm thấy sản phẩm");
}
//Câu 6 viết hàm lọc ra TOP N sản phẩm có giá trị lớn nhất
var result4 = lp.getTopProducts(3);
Console.WriteLine($"\nTop sản phẩm có giá trị lớn nhất:");
result4.ForEach(x => Console.WriteLine(x));
