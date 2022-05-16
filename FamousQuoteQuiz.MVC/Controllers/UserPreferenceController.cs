using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class UserPreferenceController : Controller
{
    private readonly ISqlClient _sqlClient;

    public UserPreferenceController(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }
    
    [HttpGet]
    [Route("/settings")]
    public async Task<IActionResult> Settings()
    {
        if (!HttpContext.Request.Cookies.ContainsKey("userId")) 
            return View(QuestionType.Binary);
        
        var userId = int.Parse(HttpContext.Request.Cookies["userId"]);
        var user = await _sqlClient.UserDal.GetById(userId);

        return View(user.QuestionType);
    }

    [HttpPost]
    [Route("/savesettings")]
    public async Task<IActionResult> SaveSettings(UserPreferenceRequestModel requestModel)
    {
        var user = await _sqlClient.UserDal.GetById(requestModel.UserId);
        if (user is null)
            throw new Exception($"No user exists with specified id: {requestModel.UserId}");

        await _sqlClient.UserDal.UpdatePreference(user, requestModel.QuestionType);

        return Ok();
    }
}