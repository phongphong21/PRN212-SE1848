using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        #region Nhóm các thuộc tính của Employee
        private int _id; // 
        private string _id_card;
        private string _name;
        private string _email;
        private string _phone;
        #endregion
        #region Nhóm Constructor của Employee
        public Employee()
        {
            this._id = 0; 
            this._id_card = "000";
            this._name = "obama";
            this._email = "obama@gmail.com";
            this._phone = "12345";
        } 

        public Employee(int _id, string _id_card, string _name, string _email, string _phone)
        {
            this._id = _id;
            this._id_card = _id_card;
            this._name = _name;
            this._email = _email;
            this._phone = _phone;
        } 
        #endregion 
        #region Nhóm các thuộc tính của Employee
        public int Id
        {
            get { return _id; } // chỉ cho phép đọc
            set { _id = value; } // chỉ cho phép ghi
            // xóa get và set đi thì biến đó là private
            // xóa get  thì biến đó là writeonly và xóa set thì biến đó là readonly
        }
        public string Id_card
        {
            get { return _id_card; }
            set { _id_card = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion
        #region Nhóm các phương thức của Employee
        public void printInfor()
        {
            string msg = $"{_id}\t{_id_card}\t{_name}\t{_email}\t{_phone}";
            Console.WriteLine(msg);
        }

        public override string ToString()
        {
            string msg = $"{_id}\t{_id_card}\t{_name}\t{_email}\t{_phone}";
            return msg;
        }
        #endregion 
    }
}
