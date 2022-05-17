using System.Collections.Generic;
using System.Threading.Tasks;
using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Interfaces;

public interface IQuoteDal : IBaseDal
{
    Task<Quote> GetRandomOne();
    Task Update(int id, string body, string authorName);
    Task Create(string body, string authorName);
    Task<IEnumerable<Quote>> GetAll();
}