using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using versta.Models;

namespace versta.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db;
        public HomeController(OrderContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUser()
        {

            var users = from c in db.Orders
                        select new
                        {
                            c.Id,
                            c.CitySet,
                            c.AddressSet,
                            c.CityGet,
                            c.AddressGet,
                            c.Weight,
                            c.Date,
                            
                        };

            return Json(users);

        }

        public IActionResult AddUser(string citySet, string addressSet, string cityGet, string addressGet, int weight, DateTime? date)
        {

            if (citySet != null && addressSet != null && cityGet != null && addressGet != null && weight != 0 && date != null)
            {



                Order neworder = new Order
                {

                    CitySet = citySet,
                    AddressSet = addressSet,
                    CityGet = cityGet,
                    AddressGet = addressGet,
                    Weight = weight,
                    Date = date.Value,
                    
                };

                db.Add(neworder);

                db.SaveChanges();

                var OrderData = from c in db.Orders
                               where c.Id == neworder.Id
                               select new
                               {
                                   c.Id,
                                   c.CitySet,
                                   c.AddressSet,
                                   c.CityGet,
                                   c.AddressGet,
                                   c.Weight,
                                   c.Date,
                                  
                               };

                return Json(OrderData);
            }

            return NoContent();
        }

        public IActionResult RemoveUser(int nameid)
        {
            var order = db.Orders.FirstOrDefault(q => q.Id == nameid);

            if (order != null)
            {
                db.Remove(order);

                db.SaveChanges();
            }

            return NoContent();

        }
    }
}
