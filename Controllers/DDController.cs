using DesireDelivery.Manager;
using DesireDelivery.Manager.Owner;
using DesireDelivery.Models;
using DesireDelivery.Models.OwnersA;
using System;
using System.IO;
using System.Web.Mvc;

namespace DesireDelivery.Controllers
{
    public class DDController : Controller
    {
        // GET: DD
        private RegisterOwnerManager registerOwnerManager;
        private RestaurantManager restaurantManager;
        private FoodsManager foodsViewManager;

        public DDController()
        {
            registerOwnerManager = new RegisterOwnerManager();
            restaurantManager = new RestaurantManager();
            foodsViewManager = new FoodsManager();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterOwner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterOwner(Owner owner)
        {
            string fileName = Path.GetFileNameWithoutExtension(owner.ImageFile.FileName);
            string extension = Path.GetExtension(owner.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmddssfff") + extension;
            owner.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            owner.ImageFile.SaveAs(fileName);

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
            ViewBag.Owners = restaurantManager.GetAllOwner();
            ViewBag.Message = restaurantManager.Save(restaurant);
            return View();
        }
        [HttpGet]
        public ActionResult FoodsAdding()
        {
            ViewBag.Restaurants = foodsViewManager.GetAllRestaurants();
            return View();
        }
        [HttpPost]
        public ActionResult FoodsAdding(Foods foods)
        {
            string fileName = Path.GetFileNameWithoutExtension(foods.ImageFile.FileName);
            string extension = Path.GetExtension(foods.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmddssfff") + extension;
            foods.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            foods.ImageFile.SaveAs(fileName);

            ViewBag.Message = foodsViewManager.Save(foods);
            ViewBag.Restaurants = foodsViewManager.GetAllRestaurants();
            return View();
        }
    }
}
