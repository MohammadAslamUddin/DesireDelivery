using DesireDelivery.Manager;
using DesireDelivery.Manager.Owner;
using DesireDelivery.Manager.User;
using DesireDelivery.Models;
using DesireDelivery.Models.OwnersA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace DesireDelivery.Controllers
{
    public class FoodsController : Controller
    {
        private RegisterOwnerManager registerOwnerManager;
        private RestaurantManager restaurantManager;
        private FoodsManager foodsManager;
        private RegisterUserManager registerUserManager;
        private FoodsViewManager foodsViewManager;

        public FoodsController()
        {
            registerOwnerManager = new RegisterOwnerManager();
            restaurantManager = new RestaurantManager();
            foodsManager = new FoodsManager();
            registerUserManager = new RegisterUserManager();
            foodsViewManager = new FoodsViewManager();
        }




        //-------------------------------------Owner -------------------------------------------------------------
        
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
        [HttpGet]
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
            ViewBag.Restaurants = foodsManager.GetAllRestaurants();
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

            ViewBag.Message = foodsManager.Save(foods);
            ViewBag.Restaurants = foodsManager.GetAllRestaurants();
            return View();
        }




























        //-------------------------------------User-------------------------------------------------------------
        
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterUser user)
        {
            string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
            string extension = Path.GetExtension(user.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmddssfff") + extension;
            user.ImagePath = "~/Image/User" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/User"), fileName);
            user.ImageFile.SaveAs(fileName);

            ViewBag.Message = registerUserManager.Save(user);
            return View();
        }
        [HttpGet]
        public ActionResult FoodsView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFoodBySearching(string stri)
        {
            List<Foods> foods = foodsViewManager.GetFoodBySearching(stri);
            return Json(foods);
        }
    }
}