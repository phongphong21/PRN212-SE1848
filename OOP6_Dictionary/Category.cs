using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public Category()
        {
            Products = new Dictionary<int, Product>();
        }
        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }
        /*khi quản lý mọi đối tượng ta đều phải đáp ứng 
         * đầy đủ tính năng CRUD (Create, Read, Update, Delete)
         */
        public void AddProduct(Product p)
        {
            //kiểm tra nếu id của product chưa tồn tại thì thêm mới
            if (p == null)
            {
                return;//dữ liệu đầu vào null
            }
            //thêm mới Product vào Dictionary
            Products.Add(p.Id, p);
        }
        //xuất toàn bộ sản phẩm
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        //Lọc các sản phẩm có giá trị từ min tới max
        public Dictionary<int, Product> FilterProductsByPrice(double min,double max)
        {
            return Products.Where(item => item.Value.Price >= min && item.Value.Price <= max)
                .ToDictionary<int, Product>();
        }
        //sắp xếp sản phẩm theo đơn giá tăng dần 
        public Dictionary<int,Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }
        //sắp xếp theo giá tăng dần , nếu giá trùng thì số lượng giảm dần
        public Dictionary<int, Product> sortComplex()
        {
            return Products.OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item=>item.Value.Price)
                .ToDictionary<int,Product>();
        }
        //update
        public bool UpdateProduct(Product p)
        {
            if(p== null)
            {
                return false;
            }
            if (Products.ContainsKey(p.Id) == false)
            {
                return false; //không thấy 
            }
            //cập nhật giá trị tại ô nhớ chưa p.id
            Products[p.Id] = p;
            return true;//đánh dấu là sửa thành công
        }
        //delete
        public bool RemoveProduct(int id)
        {
            if(Products.ContainsKey(id) == false)
                return false;
            Products.Remove(id);
            return true;
        }
        //viết hàm cho phép xóa nhiều sản phẩm có đơn giá từ A đến B
        public Dictionary<int, Product> RemoveProductByPrice(double a, double b)
        {
            var removedProducts = Products
                .Where(item => item.Value.Price >= a && item.Value.Price <= b)
                .ToDictionary(item => item.Key, item => item.Value);

            foreach (var key in removedProducts.Keys)
            {
                Products.Remove(key);
            }

            return removedProducts;
        }

    }
}
