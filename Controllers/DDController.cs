using DesireDelivery.Manager;
using DesireDelivery.Models;
using System.Web.Mvc;

namespace DesireDelivery.Controllers
{
    public class DDController : Controller
    {
        // GET: DD
        private RegisterOwnerManager registerOwnerManager;

        public DDController()
        {
            registerOwnerManager = new RegisterOwnerManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterOwner()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterOwner(Owner owner)
        {
            ViewBag.Message = registerOwnerManager.Save(owner);
            return View();
        }
    }
}