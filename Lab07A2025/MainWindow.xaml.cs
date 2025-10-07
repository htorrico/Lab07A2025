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
using Business;
using Entity;
namespace Lab07A2025
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BCustomer bCustomer = new BCustomer();
            dgCustomers.ItemsSource=bCustomer.Read();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Cuenta todos los que contenga el número 5 en tu teléfono
            BCustomer bCustomer = new BCustomer();
            lblsize.Content = bCustomer.GetSize5() ;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                BCustomer bCustomer = new BCustomer();
                bCustomer.Create(new Customer
                {

                    Address = txtAddress.Text,
                    Name = txtName.Text,
                    Phone = txtPhone.Text,

                });
                MessageBox.Show("Customer created successfully");   
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }
    }
}