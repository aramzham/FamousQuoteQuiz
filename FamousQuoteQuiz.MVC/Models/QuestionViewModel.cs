namespace FamousQuoteQuiz.MVC.Models;

public class QuestionViewModel
{
    public string Quote { get; set; }
    public AuthorViewModel CorrectAnswer { get; set; }
    public IEnumerable<AuthorViewModel> Answers { get; set; }
}