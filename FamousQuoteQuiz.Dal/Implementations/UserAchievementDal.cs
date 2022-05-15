using FamousQuoteQuiz.Dal.Interfaces;
using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Implementations;

public class UserAchievementDal : BaseDal, IUserAchievementDal
{
    public UserAchievementDal(QuizDbContext db) : base(db)
    {
    }

    public async Task Log(UserAchievement userAchievement)
    {
        await _db.UserAchievement.AddAsync(userAchievement);
        await _db.SaveChangesAsync();
    }
}