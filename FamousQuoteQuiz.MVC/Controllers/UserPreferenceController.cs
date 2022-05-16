using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class UserPreferenceController : Controller
{
    // GET
    public IActionResult Settings()
    {
        return View();
    }
}