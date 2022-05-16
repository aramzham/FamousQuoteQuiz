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

        HttpContext.Response.Headers["x-name"] = user.Id.ToString();

        return Redirect("/quote");
    }

    [HttpGet]
    [Route("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Request.Headers.Remove("x-name");

        return Redirect("/login");
    }
}