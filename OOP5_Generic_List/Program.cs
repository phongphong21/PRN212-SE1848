/*
 * Sử dụng Generic List để quản lý nhân sự đầy đủ
 * Tính năng CRUD
 * C -> Create: tạo dữ liệu mới
 * R -> Read/Retrieve: xem , lọc, tìm kiếm, sắp xếp , thống kê,...
 * U -> Update: cập nhật dữ liệu 
 * D -> Delete: xóa dữ liệu
 */
//Câu 1: Tạo 5 nhân viên trong đó 3 nhân viên chính thức , 2 thời vụ và lưu vào Generic List:
using OOP2;
using System.Text;

List<Employee> employees = new List<Employee>();
FulltimeEmployee fel = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Name 1",
    Birthday = new DateTime(1990, 1, 1)
};
employees.Add(fel);
FulltimeEmployee fel2 = new FulltimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Name 2",
    Birthday = new DateTime(1980, 1, 1)
};
employees.Add(fel2);
FulltimeEmployee fel3 = new FulltimeEmployee()
{
    Id = 3,
    IdCard = "789",
    Name = "Name 3",
    Birthday = new DateTime(1970, 1, 1)
};
employees.Add(fel3);
ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 4,
    IdCard = "101",
    Name = "Name 4",
    Birthday = new DateTime(1995, 1, 1),
    WorkingHour = 2
};
employees.Add(pe1);
ParttimeEmployee pe2= new ParttimeEmployee()
{
    Id = 5,
    IdCard = "102",
    Name = "Name 5",
    Birthday = new DateTime(1999, 1, 1),
    WorkingHour = 3
};
employees.Add(pe2);

Console.OutputEncoding = Encoding.UTF8;
//câu 2 : R -> xuất toàn bộ nhân sự
Console.WriteLine("Câu 2: R -> Xuất toàn bộ nhân sự :");
//cách 1:
employees.ForEach(e=> Console.WriteLine(e));
//Câu 3 R -> Lọc ra các nhân sự chính thức 
//cách 1: 
List<FulltimeEmployee> fe_list= employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("\nCâu 3 -> Lọc ra các nhân viên chính thức : ");
foreach (FulltimeEmployee fe in fe_list)
    Console.WriteLine(fe);
//câu 4 : Tổng lương nhân viên chính thức :
double fe_sum_salary = fe_list.Sum(e => e.calSalary());
Console.WriteLine("\ncâu 4 : Tổng lương nhân viên chính thức :");
Console.WriteLine(fe_sum_salary);

//câu 5 : Tổng lương nhân viên thời vụ :
double pe_sum_salary = employees.OfType<ParttimeEmployee>().Sum(e => e.calSalary());
Console.WriteLine("\ncâu 5 : Tổng lương nhân viên thời vụ :");
Console.WriteLine(pe_sum_salary);
//bổ sung thêm sửa và xóa 
Console.WriteLine("------------------------------------------------");
int choice;
Console.WriteLine("Chọn chức năng bạn muốn thực hiện:");
Console.WriteLine("1. Sửa thông tin nhân viên");
Console.WriteLine("2. Xóa thông tin nhân viên");
Console.WriteLine("3. Thoát chương trình");
Console.WriteLine("Nhập lựa chọn của bạn (1-3):");
while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
{
    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một số từ 1 đến 3:");
}
switch (choice)
{
    case 1:
        // Sửa
        Console.WriteLine("Bạn đã chọn sửa thông tin nhân viên.");
        #region Chức năng sửa thông tin của nhân viên
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("\nDanh sách nhân viên hiện tại:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        int idtoUpdate = -1;
        Console.WriteLine("\nNhập ID nhân viên cần sửa thông tin:");
        if (int.TryParse(Console.ReadLine(), out idtoUpdate))
        {
            if (idtoUpdate > 0)
            {
                Employee? empToUpdate = employees.FirstOrDefault(e => e.Id == idtoUpdate);
                if (empToUpdate != null)
                {
                    Console.WriteLine("Nhập tên mới cho nhân viên (hiện tại là: " + empToUpdate.Name + "):");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        empToUpdate.Name = newName;
                    }
                    else
                    {
                        Console.WriteLine("Tên không được để trống. Giữ nguyên tên cũ.");
                    }
                    Console.WriteLine("Nhập ngày sinh mới cho nhân viên (hiện tại là: " + empToUpdate.Birthday.ToString("dd/MM/yyyy") + "):");
                    string? newBirthdayInput = Console.ReadLine();
                    if (DateTime.TryParse(newBirthdayInput, out DateTime newBirthday))
                    {
                        empToUpdate.Birthday = newBirthday;
                    }
                    else
                    {
                        Console.WriteLine("Ngày sinh không hợp lệ. Giữ nguyên ngày sinh cũ.");
                    }
                    Console.WriteLine("Nhập ID_card mới cho nhân viên (hiện tại là: " + empToUpdate.IdCard + "):");
                    string? newIdCard = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newIdCard))
                    {
                        empToUpdate.IdCard = newIdCard;
                    }
                    else
                    {
                        Console.WriteLine("ID_card không được để trống. Giữ nguyên ID_card cũ.");
                    }
                    Console.WriteLine("Thông tin nhân viên sau khi cập nhật:");
                    foreach (Employee emp in employees)
                    {
                        Console.WriteLine(emp);
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhân viên với ID: " + idtoUpdate);
                }
            }
            else
            {
                Console.WriteLine("ID phải lớn hơn 0.");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ. Vui lòng nhập một số nguyên.");
        }
        #endregion
        break;
    case 2:
        // Xóa thông tin nhân viên
        Console.WriteLine("Bạn đã chọn xóa thông tin nhân viên.");
        #region Chức năng xóa thông tin của nhân viên
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("\nDanh sách nhân viên hiện tại:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        int idToDelete = -1;
        Console.WriteLine("\nNhập ID nhân viên cần xóa:");
        if (int.TryParse(Console.ReadLine(), out idToDelete))
        {
            if (idToDelete > 0)
            {
                Employee? empToDelete = employees.FirstOrDefault(e => e.Id == idToDelete);
                if (empToDelete != null)
                {
                    employees.Remove(empToDelete);
                    Console.WriteLine("Đã xóa nhân viên với ID: " + idToDelete);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhân viên với ID: " + idToDelete);
                }
            }
            else
            {
                Console.WriteLine("ID phải lớn hơn 0.");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ. Vui lòng nhập một số nguyên.");
        }
        Console.WriteLine("Danh sách nhân viên sau khi xóa:");
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp);
        }
        #endregion
        break;
    default:
        Console.WriteLine("Bạn đã chọn thoát chương trình.");
        return;
}
