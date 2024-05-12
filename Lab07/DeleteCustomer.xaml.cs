using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab07
{
    /// <summary>
    /// Lógica de interacción para DeleteCustomer.xaml
    /// </summary>
    public partial class DeleteCustomer : Window
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtid.Text, out int customerId))
            {
                CustomerData customerData = new CustomerData();
                bool success = customerData.DeleteCustomer(customerId);

                if (success)
                {
                    MessageBox.Show("Customer deactivated successfully!");
                    CustomersList list = new CustomersList();
                    list.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Failed to deactivate customer.");
                }
            }
            else
            {
                MessageBox.Show("Invalid customer ID.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }
    }
}
