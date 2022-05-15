using FamousQuoteQuiz.Dal.Interfaces;

namespace FamousQuoteQuiz.Dal.Implementations;

public class UserAchievementDal : BaseDal, IUserAchievementDal
{
    public UserAchievementDal(QuizDbContext db) : base(db)
    {
    }
}