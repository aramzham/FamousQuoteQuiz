using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

[Route("[controller]")]
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
        var quote = await _sqlClient.QuoteDal.GetRandomOne();
        var authors = await _sqlClient.AuthorDal.GetAnswers(quote.AuthorId, 2);

        return View(new QuestionViewModel()
        {
            Quote = quote.Body,
            Answers = authors.Select(x => new AuthorViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }),
            CorrectAnswer = new AuthorViewModel()
            {
                Id = quote.Author.Id,
                Name = quote.Author.Name
            }
        });
    }
}