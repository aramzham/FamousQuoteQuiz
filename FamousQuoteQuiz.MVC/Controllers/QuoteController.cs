using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.MVC.Models;
using FamousQuoteQuiz.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class QuoteController : Controller
{
    private readonly ISqlClient _sqlClient;

    public QuoteController(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    [HttpGet]
    [Route("/quote")]
    public async Task<IActionResult> Quote()
    {
        if (!HttpContext.Request.Cookies.ContainsKey("userId"))
            return Redirect("/login");

        var quote = await _sqlClient.QuoteDal.GetRandomOne();
        var authors = await _sqlClient.AuthorDal.GetAnswers(quote.AuthorId, 2);

        // question type
        var userPreference = HttpContext.Request.Cookies.TryGetValue("userPreference", out var up)
            ? up
            : "binary";
        var questionType = Enum.TryParse<QuestionType>(userPreference, true, out var result)
            ? result
            : QuestionType.Binary;
        
        // user id
        var userId = HttpContext.Request.Cookies.TryGetValue("userId", out var ui) ? int.Parse(ui) : 1;

        return View(new QuestionViewModel()
        {
            Quote = new QuoteViewModel()
            {
                Id = quote.Id,
                Body = quote.Body
            },
            Answers = authors.Select(x => new AuthorViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }),
            CorrectAnswer = new AuthorViewModel()
            {
                Id = quote.Author.Id,
                Name = quote.Author.Name
            },
            UserId = userId,
            QuestionType = questionType
        });
    }
}