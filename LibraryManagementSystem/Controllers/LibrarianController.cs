using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class LibrarianController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (Session["Role"] == null || Session["Role"].ToString() != "Librarian")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}