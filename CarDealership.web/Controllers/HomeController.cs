using CarDealership.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Data.SqlClient;
using CarDealership.DataAccess.Repositories;
using CarDealership.DataAccess.Models;

namespace CarDealership.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICarRepository _carRepository;

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(Car car)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
        //    _carRepository = new CarRepository(conn);
        //    _carRepository.Add(car);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
        //    _carRepository = new CarRepository(conn);
        //    _carRepository.Delete(id);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Update(Car car)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
        //    _carRepository = new CarRepository(conn);
        //    _carRepository.Update(car);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Index(string query)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
        //    _carRepository = new CarRepository(conn);
        //    var cars = _carRepository.GetCars(query);
        //    return View(cars);
        //}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
