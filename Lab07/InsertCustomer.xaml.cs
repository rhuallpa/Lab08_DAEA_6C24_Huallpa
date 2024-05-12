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
    /// Lógica de interacción para InsertCustomer.xaml
    /// </summary>
    public partial class InsertCustomer : Window
    {
        public InsertCustomer()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            // Convertir el valor del CheckBox a booleano con un valor por defecto de false si es null
            bool active = Active.IsChecked ?? false;

            CustomerData customerData = new CustomerData();
            bool success = customerData.InsertCustomer(name, address, phone, active);

            if (success)
            {
                MessageBox.Show("Customer inserted successfully!");
                CustomersList list = new CustomersList();
                list.ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to insert customer.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

