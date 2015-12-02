using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebMatrix.WebData;
using YHAdmin.Models;

namespace YHAdmin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(loginCredentials.Username, loginCredentials.Password))
                {
                    //Exakt vad som händer när en användare lyckas logga in kan ändras i ett senare skede.
                    return RedirectToAction("Index", "Home");
                }
                    ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
                    return View(loginCredentials);
            }
            return View(loginCredentials);
        }

        public ActionResult SendRegistrationEmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendRegistrationEmail(RegisterViewModel model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(model.Email));
            message.Subject = "Your email subject";
            message.Body = string.Format(body, "teamtiger", "teamtiger@gmail.com", "Hej på dig!");
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                smtp.Send(message);
                return View("Sent");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
