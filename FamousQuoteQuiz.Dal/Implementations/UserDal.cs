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

    public Task<User> GetById(int id)
    {
        return _db.User.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdatePreference(User user, QuestionType questionType)
    {
        user.QuestionType = questionType;
        return _db.SaveChangesAsync();
    }
}