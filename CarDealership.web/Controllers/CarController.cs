using CarDealership.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using CarDealership.DataAccess.Repositories;
using CarDealership.DataAccess.Models;


namespace CarDealership.web.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository _carRepository;

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _carRepository = new CarRepository(conn);
            _carRepository.Add(car);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _carRepository = new CarRepository(conn);
            _carRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Car car)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _carRepository = new CarRepository(conn);
            _carRepository.Update(car);
            return RedirectToAction("Index");
        }

        public IActionResult Index(string query)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _carRepository = new CarRepository(conn);
            var cars = _carRepository.GetCars(query);
            return View(cars);
        }

    }
}
