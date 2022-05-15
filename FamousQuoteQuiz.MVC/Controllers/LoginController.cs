using FamousQuoteQuiz.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class LoginController : Controller
{
    [HttpPost]
    public IActionResult Login(LoginModel loginModel)
    {
        return View();
    }
}