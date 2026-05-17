using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowController : Controller
    {
        private static List<BorrowRecord> borrowedBooks = new List<BorrowRecord>();

        public ActionResult Index(string bookTitle)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberName = Session["User"].ToString();
            ViewBag.BookTitle = bookTitle;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string memberName, string bookTitle)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            borrowedBooks.Add(new BorrowRecord
            {
                MemberName = Session["User"].ToString(),
                BookTitle = bookTitle,
                BorrowDate = DateTime.Now.ToString("dd MMM yyyy"),
                ReturnDate = "-",
                Status = "Borrowed"
            });

            ViewBag.MemberName = Session["User"].ToString();
            ViewBag.BookTitle = bookTitle;
            ViewBag.Message = "Borrow request submitted successfully.";

            return View();
        }

        public ActionResult MyBooks()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string currentUser = Session["User"].ToString();

            var userBooks = borrowedBooks
                .Where(x => x.MemberName == currentUser)
                .ToList();

            return View(userBooks);
        }

        public ActionResult ReturnBook(string bookTitle)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string currentUser = Session["User"].ToString();

            var book = borrowedBooks.FirstOrDefault(x =>
                x.BookTitle == bookTitle &&
                x.MemberName == currentUser &&
                x.Status == "Borrowed");

            if (book != null)
            {
                book.Status = "Returned";
                book.ReturnDate = DateTime.Now.ToString("dd MMM yyyy");
            }

            TempData["Message"] = "Book returned successfully.";

            return RedirectToAction("MyBooks");
        }
    }

    public class BorrowRecord
    {
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
        public string Status { get; set; }
    }
}