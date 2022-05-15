﻿using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Interfaces;

public interface IUserAchievementDal : IBaseDal
{
    Task Log(UserAchievement userAchievement);
}