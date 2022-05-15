using FamousQuoteQuiz.Dal.Interfaces;
using FamousQuoteQuiz.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Dal.Implementations;

public class AuthorDal : BaseDal, IAuthorDal
{
    public AuthorDal(QuizDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<Author>> GetAnswers(int correctAuthorId, int numberOfOtherAnswers)
    {
        var count = await _db.Author.CountAsync();
        var correctAnswer = await _db.Author.FirstAsync(x => x.Id == correctAuthorId);
        var otherAnswers = await _db.Author.Skip(_random.Next(0, count)).Take(2).ToListAsync();

        return otherAnswers.Concat(new[] { correctAnswer });
    }
}