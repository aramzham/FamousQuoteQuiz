namespace FamousQuoteQuiz.MVC.Models;

public class LogRequestModel
{
    public int QuoteId { get; set; }
    public int UserId { get; set; }
    public bool IsAnsweredCorrectly { get; set; }
}