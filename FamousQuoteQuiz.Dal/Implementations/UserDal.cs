using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamousQuoteQuiz.Dal.Interfaces;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.Dal.Models.UpdateModels;
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

    public async Task Update(int id, UserUpdateModel updateModel)
    {
        var user = await _db.User.FirstOrDefaultAsync(x=> x.Id == id);
        if (user is null)
            throw new Exception($"No user exists with specified id: {id}");
        
        if (updateModel.Name != null) user.Name = updateModel.Name;
        if (updateModel.QuestionType.HasValue) user.QuestionType = updateModel.QuestionType.Value;

        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _db.User.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null)
            throw new Exception($"No user found by id: {id}");

        _db.User.Remove(user);

        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.User.ToListAsync();
    }
}