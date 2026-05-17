using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<FeedbackRecord> feedbackList = new List<FeedbackRecord>();

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberName = Session["User"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string memberName, string message)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            feedbackList.Add(new FeedbackRecord
            {
                MemberName = Session["User"].ToString(),
                Message = message
            });

            ViewBag.MemberName = Session["User"].ToString();
            ViewBag.Success = "Feedback submitted successfully.";

            return View();
        }

        public ActionResult Review()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (Session["Role"] == null || Session["Role"].ToString() != "Librarian")
            {
                return RedirectToAction("Index", "Home");
            }

            return View(feedbackList);
        }
    }

    public class FeedbackRecord
    {
        public string MemberName { get; set; }
        public string Message { get; set; }
    }
}
