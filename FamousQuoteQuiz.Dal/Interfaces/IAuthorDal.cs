﻿using FamousQuoteQuiz.Dal.Models;

namespace FamousQuoteQuiz.Dal.Interfaces;

public interface IAuthorDal : IBaseDal
{
    Task<IEnumerable<Author>> GetAnswers(int correctAuthorId, int numberOfOtherAnswers);
}