using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private static List<UserAccount> users = new List<UserAccount>
        {
            new UserAccount { Username = "admin", Email = "admin@library.com", Password = "1234" }
        };

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                Session["User"] = user.Username;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.Message = "Please fill all fields.";
                return View();
            }

            if (password != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match.";
                return View();
            }

            if (users.Any(u => u.Username == username))
            {
                ViewBag.Message = "Username already exists.";
                return View();
            }

            users.Add(new UserAccount
            {
                Username = username,
                Email = email,
                Password = password
            });

            ViewBag.Message = "Registration completed successfully!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }

    public class UserAccount
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}