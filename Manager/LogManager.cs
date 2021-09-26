using DesireDelivery.Gateway;
using DesireDelivery.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DesireDelivery.Manager
{
    public class LogManager
    {
        private LogGateway logGetway;

        public LogManager()
        {
            logGetway = new LogGateway();
        }
        public List<SelectListItem> GetListForLogIn()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "1", Text = "Student"},
                new SelectListItem(){Value = "2", Text = "Teacher"}
            };
            return listItems;
        }

        public async Task<SignInStatus> LogIn(string email, string password, int loginAs, bool isPersistent, bool shouldLockout)
        {
            LoginViewModel user = new LoginViewModel() { Email = email, Password = password, LogInAs = loginAs, RememberMe = isPersistent };

            if (logGetway.isUserAvailable(user))
            {
                return SignInStatus.Success;
            }
            else
            {
                return SignInStatus.Failure;
            }
        }
    }
}