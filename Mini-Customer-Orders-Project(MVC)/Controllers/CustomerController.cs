using Microsoft.AspNetCore.Mvc;
using Mini_Customer_Orders_Project_MVC_.Entity;
using Mini_Customer_Orders_Project_MVC_.ProjectContext;

namespace Mini_Customer_Orders_Project_MVC_.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values=context.Customers.ToList(); 
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            context.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values =context.Customers.Where(x=>x.Id== id).FirstOrDefault();
            context.Remove(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.Where(x=>x.Id==id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {
            var value = context.Customers.Where(x => x.Id == c.Id).FirstOrDefault();
            value.City = c.City;
            value.Name= c.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
