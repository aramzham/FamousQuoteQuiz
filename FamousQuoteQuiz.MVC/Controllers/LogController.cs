using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class LogController : Controller
{
    private readonly ISqlClient _sqlClient;

    public LogController(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }
    
    [HttpPost]
    [Route("/log")]
    public Task AddToLog(LogRequestModel requestModel)
    {
        return _sqlClient.UserAchievementDal.Log(new UserAchievement()
        {
            QuoteId = requestModel.QuoteId,
            UserId = requestModel.UserId,
            IsAnsweredCorrectly = requestModel.IsAnsweredCorrectly
        });
    }
}