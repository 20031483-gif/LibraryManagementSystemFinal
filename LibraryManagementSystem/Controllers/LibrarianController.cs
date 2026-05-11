using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class LibrarianController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ManageLibraryInfo()
        {
            return View();
        }

        public ActionResult BorrowingRules()
        {
            return View();
        }
    }
}