using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class CustomerData
    {
        private string connectionString = "Data Source=LAPTOP-R1VL050P\\SQLEXPRESS2017; Initial Catalog=FACTURADB; Integrated Security=True;";

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CustomerList", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.customer_id = reader.GetInt32(0);
                        customer.name = reader.GetString(1);
                        customer.address = reader.IsDBNull(2) ? null : reader.GetString(2);
                        customer.phone = reader.IsDBNull(3) ? null : reader.GetString(3);
                        customer.active = reader.GetBoolean(4);

                        customers.Add(customer);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return customers;
        }

        public bool InsertCustomer(string name, string address, string phone, bool active)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CustomerInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@active", active);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SoftDeleteCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@customer_id", customerId);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}