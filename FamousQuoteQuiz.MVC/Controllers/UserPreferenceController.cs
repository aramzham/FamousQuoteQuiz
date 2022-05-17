using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models.UpdateModels;
using FamousQuoteQuiz.MVC.Models.RequestModels;
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
    public IActionResult Settings()
    {
        return View();
    }

    [HttpPost]
    [Route("/savesettings")]
    public async Task<IActionResult> SaveSettings(UserPreferenceRequestModel requestModel)
    {
        await _sqlClient.UserDal.Update(requestModel.UserId, new UserUpdateModel() { QuestionType = requestModel.QuestionType });

        return Ok();
    }
}