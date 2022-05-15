using FamousQuoteQuiz.Dal.Interfaces;

namespace FamousQuoteQuiz.Dal.Implementations;

public class UserDal : BaseDal, IUserDal
{
    public UserDal(QuizDbContext db) : base(db)
    {
    }
}