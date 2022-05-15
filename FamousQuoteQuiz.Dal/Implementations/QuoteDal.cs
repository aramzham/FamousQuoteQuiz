using FamousQuoteQuiz.Dal.Interfaces;
using FamousQuoteQuiz.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Dal.Implementations;

public class QuoteDal : BaseDal, IQuoteDal
{
    public QuoteDal(QuizDbContext db) : base(db)
    {
    }

    public async Task<Quote> GetRandomOne()
    {
        var count = await _db.Quote.CountAsync();
        var randomNumber = _random.Next(0, count);

        return await _db.Quote.Include(x=>x.Author).Skip(randomNumber).FirstAsync();
    }
}