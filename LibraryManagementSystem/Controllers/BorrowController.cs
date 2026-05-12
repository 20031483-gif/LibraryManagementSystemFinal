using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowController : Controller
    {
        public ActionResult Index(string bookTitle)
        {
            ViewBag.BookTitle = bookTitle;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string memberName, string bookTitle)
        {
            ViewBag.Message = "Borrow request submitted successfully.";
            ViewBag.BookTitle = bookTitle;

            return View();
        }
    }
}