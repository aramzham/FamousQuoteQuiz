using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Interfaces;

public interface IQuoteDal : IBaseDal
{
    Task<Quote> GetRandomOne();
}