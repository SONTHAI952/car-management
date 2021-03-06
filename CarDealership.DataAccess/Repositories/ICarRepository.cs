using System.Collections.Generic;
using CarDealership.DataAccess.Models;

namespace CarDealership.DataAccess.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        IList<Car> GetCars(string name);
        void Delete(int id);

        void Add(Car car);
        void Update(Car car);
    }
}
