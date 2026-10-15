
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using practical_07.Models;

namespace practical_07.Controllers
{
    public class FeedbackController : Controller
    {
        // Temporary storage for submitted feedback
        private static List<Feedback> feedbackList =
            new List<Feedback>();

        // Display the feedback form
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Process the submitted feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbackList.Count + 1;
                feedback.SubmittedAt = DateTime.Now;

                feedbackList.Add(feedback);

                TempData["SuccessMessage"] =
                    "Feedback submitted successfully!";

                return RedirectToAction("Create");
            }

            return View(feedback);
        }
    }
}
