using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class FeedbackController : Controller
    {
        // FEEDBACK PAGE
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberName = Session["User"].ToString();

            return View();
        }

        // FEEDBACK SUBMIT
        [HttpPost]
        public ActionResult Index(string memberName, string message)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberName = Session["User"].ToString();
            ViewBag.Success = "Feedback submitted successfully.";

            return View();
        }
    }
}