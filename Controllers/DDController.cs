using DesireDelivery.Manager;
using DesireDelivery.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DesireDelivery.Controllers
{
    public class DDController : Controller
    {
        // GET: DD
        private RegisterOwnerManager registerOwnerManager;
        private RestaurantManager restaurantManager;

        public DDController()
        {
            registerOwnerManager = new RegisterOwnerManager();
            restaurantManager = new RestaurantManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterOwner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterOwner(Owner owner)
        {
            ViewBag.Message = registerOwnerManager.Save(owner);
            return View();
        }

        public ActionResult RegisterRestaurant()
        {
            ViewBag.Owners = restaurantManager.GetAllOwner();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterRestaurant(Restaurant restaurant)
        {
            ViewBag.owner = restaurantManager.GetAllOwner();
            ViewBag.Message = restaurantManager.Save(restaurant);
            return View();
        }
    }
}