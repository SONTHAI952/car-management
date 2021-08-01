using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using CarDealership.DataAccess.Repositories;
using CarDealership.DataAccess.Models;



namespace CarDealership.web.Controllers
{
    public class CustomerController : Controller
    {
        
        private ICustomerRepository _customerRepository;

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _customerRepository = new CustomerRepository(conn);
            _customerRepository.Add(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _customerRepository = new CustomerRepository(conn);
            _customerRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Customer customer)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _customerRepository = new CustomerRepository(conn);
            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Index(string query)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=(local);Database=DB1;Trusted_Connection=True;";
            _customerRepository = new CustomerRepository(conn);
            var customers = _customerRepository.GetCustomers(query);
            return View(customers);
        }

    }
}
