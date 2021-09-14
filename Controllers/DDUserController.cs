﻿using DesireDelivery.Manager.User;
using DesireDelivery.Models;
using DesireDelivery.Models.OwnersA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace DesireDelivery.Controllers
{
    public class DDUserController : Controller
    {
        private RegisterUserManager registerUserManager;
        private FoodsViewManager foodsViewManager;

        public DDUserController()
        {
            registerUserManager = new RegisterUserManager();
            foodsViewManager = new FoodsViewManager();
        }

        // GET: DDUser
        public ActionResult Index()
        {
            return View();
        }
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
        //[HttpPost]
        //public ActionResult FoodsView()
        //{
        //    return View();
        //}
    }
}