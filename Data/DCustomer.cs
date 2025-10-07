using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DCustomer
    {

        private string connectionString= "Server=HUGO\\SQLEXPRESS01;Database=INVOICESADB;Integrated Security=True; TrustServerCertificate=true";
        public List<Customer> Read()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_ListCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer c = new Customer
                        {
                            CustomerID = Convert.ToInt32(reader["customer_id"]),
                            Name = reader["name"].ToString(),
                            Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : string.Empty,
                            Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty,
                            Active = Convert.ToBoolean(reader["active"])
                        };

                        customers.Add(c);
                    }
                }
            }

            return customers;
        }

        public void Create(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_InsertCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", (object)customer.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
