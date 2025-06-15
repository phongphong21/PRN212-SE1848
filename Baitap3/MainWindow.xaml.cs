using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Baitap3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGui_Click(object sender, RoutedEventArgs e)
        {
            string binhChon = "";

            if (radRatTot.IsChecked == true)
                binhChon = radRatTot.Content.ToString();
            else if (radTot.IsChecked == true)
                binhChon = radTot.Content.ToString();
            else if (radTamDuoc.IsChecked == true)
                binhChon = radTamDuoc.Content.ToString();
            else if (radKhongTot.IsChecked == true)
                binhChon = radKhongTot.Content.ToString();

            string gioiTinh = "";

            if (radNam.IsChecked == true)
                gioiTinh = radNam.Content.ToString();
            else if (radNu.IsChecked == true)
                gioiTinh = radNu.Content.ToString();

            string infor = "Bạn bình chọn Hệ Thống: " + binhChon + Environment.NewLine;
            infor += "Giới tính của bạn: " + gioiTinh;

            MessageBoxResult ret;
            ret = MessageBox.Show(infor, "Mời bạn xác nhận",
                                  MessageBoxButton.YesNo,
                                  MessageBoxImage.Question);

            if (ret == MessageBoxResult.Yes)
            {
                // Gửi xử lý xác nhận tại đây
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}