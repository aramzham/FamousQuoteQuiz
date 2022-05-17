using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class LoginController : Controller
{
    private readonly ISqlClient _sqlClient;

    public LoginController(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    [HttpGet]
    [Route("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> LoginAction(LoginRequestModel loginRequestModel)
    {
        var user = await _sqlClient.UserDal.GetByName(loginRequestModel.Name);
        if (user is null)
            user = await _sqlClient.UserDal.Add(new User() { Name = loginRequestModel.Name, CreatedAt = DateTime.Now });

        HttpContext.Response.Cookies.Append("userId", user.Id.ToString());
        HttpContext.Response.Cookies.Append("userPreference", user.QuestionType.ToString());

        return Redirect("/quote");
    }

    [HttpGet]
    [Route("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("userId");
        HttpContext.Response.Cookies.Delete("userPreference");

        return Redirect("/login");
    }
}