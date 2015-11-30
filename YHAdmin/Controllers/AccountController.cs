using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebMatrix.WebData;

namespace YHAdmin.Controllers
{
    class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginCredentials)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(loginCredentials.UserName, loginCredentials.Password))
                {
                    //Exakt vad som händer när en användare lyckas logga in kan ändras i ett senare skede.
                    return RedirectToAction("Index", "Home");
                }
                    ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
                    return View(loginCredentials);
            }
            return View(loginCredentials);
        }
    }
}
