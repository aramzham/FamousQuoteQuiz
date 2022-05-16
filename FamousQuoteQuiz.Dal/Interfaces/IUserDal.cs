using System.Threading.Tasks;
using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Interfaces;

public interface IUserDal : IBaseDal
{
    Task<User> GetByName(string name);
    Task<User> Add(User user);
}