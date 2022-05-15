namespace FamousQuoteQuiz.MVC.Models;

public class QuestionViewModel
{
    public QuoteViewModel Quote { get; set; }
    public AuthorViewModel CorrectAnswer { get; set; }
    public IEnumerable<AuthorViewModel> Answers { get; set; }
    public int UserId { get; set; }
}