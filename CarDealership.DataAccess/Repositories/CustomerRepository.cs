using System.Collections.Generic;
using CarDealership.DataAccess.Models;
using System.Data.SqlClient;

namespace CarDealership.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _conn;
        public CustomerRepository(SqlConnection sqlConnection)
        {
            _conn = sqlConnection;
        }

        public IList<Customer> GetCustomers(string name)
        {
            var query = "select * from Customer";
            if (!string.IsNullOrWhiteSpace(name))
                query += " where Name like '%" + name + "%'";
            SqlCommand cm = new SqlCommand(query, _conn);
            var customers = new List<Customer>();
            _conn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            {
                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.Id = (int)reader["Id"];
                    customer.Name = reader["Name"].ToString();
                    customer.Gender = reader["Gender"].ToString();
                    customers.Add(customer);
                }
            }
            _conn.Close();
            return customers;
        }

        public void Add(Customer customer)
        {
            var query = "insert into Customer(Name, Gender) values (N'" + customer.Name + "','" + customer.Gender + "')";
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete(int id)
        {
            var query = "delete from Customer where [Id]= " + id;
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

        public void Update(Customer customer)
        {
            var query = "UPDATE Car SET Name = '" + customer.Name + "', Gender = '" + customer.Gender + "' WHERE Id = " + customer.Id;
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

    }
}
