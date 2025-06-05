using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = {100, 51,120,130,50,70,123,17,237 };

/* câu 1 : dùng LINQ2Object để lọc ra các số chẵn 
 */ 
//cách method Syntax
var result = arr.Where(x => x % 2 == 0);
//cách query syntax
var result2 = from x in arr where x % 2 == 0 select x;
result2.ToList().ForEach(x => Console.WriteLine(x));
//câu 2 : Sắp xếp danh sách tăng dần :
var sortedArray = arr.OrderBy(x => x);
var sortedArrayQuery = from x in arr orderby x select x;
Console.WriteLine("\nDanh sách sau khi sắp xếp : ");
foreach(var item  in sortedArray)
{
    Console.WriteLine(item);
}
//câu 3 : giảm dần

var var sortedArrayDecrending = arr.OrderBy(x => x);
var sortedArrayQuery = from x in arr orderby x select x;
