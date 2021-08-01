using System.Collections.Generic;
using CarDealership.DataAccess.Models;
using System.Data.SqlClient;

namespace CarDealership.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly SqlConnection _conn;
        public CarRepository(SqlConnection sqlConnection)
        {
            _conn = sqlConnection;
        }

        public IList<Car> GetCars(string name)
        {
            var query = "select * from Car";
            if (!string.IsNullOrWhiteSpace(name))
                query += " where Name like '%" + name + "%'";
            SqlCommand cm = new SqlCommand(query, _conn);
            var cars = new List<Car>();
            _conn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            {
                while (reader.Read())
                {
                    var car = new Car();
                    car.Id = (int)reader["Id"];
                    car.Name = reader["Name"].ToString();
                    car.Price = (int)reader["Price"];
                    cars.Add(car);
                }
            }
            _conn.Close();
            return cars;
        }

        public void Add(Car car)
        {
            var query = "insert into Car(Name, Price) values (N'" + car.Name + "','" + car.Price + "')";
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete(int id)
        {
            var query = "delete from Car where [Id]= " + id;
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

        public void Update(Car car)
        {
            var query = "UPDATE Car SET Name = '" + car.Name + "', Price = '" + car.Price + "' WHERE Id = " + car.Id;
            SqlCommand cm = new SqlCommand(query, _conn);
            _conn.Open();
            cm.ExecuteNonQuery();
            _conn.Close();
        }

    }
}
