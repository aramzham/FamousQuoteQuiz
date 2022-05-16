using System.Threading.Tasks;
using FamousQuoteQuiz.Dal.Interfaces;
using FamousQuoteQuiz.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Dal.Implementations;

public class UserDal : BaseDal, IUserDal
{
    public UserDal(QuizDbContext db) : base(db)
    {
    }

    public Task<User> GetByName(string name)
    {
        return _db.User.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<User> Add(User user)
    {
        await _db.User.AddAsync(user);
        await _db.SaveChangesAsync();

        return user;
    }
}