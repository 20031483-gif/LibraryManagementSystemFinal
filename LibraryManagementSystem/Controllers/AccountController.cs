using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private static List<UserAccount> users = new List<UserAccount>
        {
            new UserAccount
            {
                Username = "admin",
                Email = "admin@library.com",
                Password = "1234",
                Role = "Librarian"
            }
        };

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);

            if (user != null)
            {
                Session["User"] = user.Username;
                Session["Role"] = user.Role;

                if (user.Role == "Librarian")
                {
                    return RedirectToAction("Dashboard", "Librarian");
                }

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
            if (password != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match.";
                return View();
            }

            users.Add(new UserAccount
            {
                Username = username,
                Email = email,
                Password = password,
                Role = "Member"
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
        public string Role { get; set; }
    }
}