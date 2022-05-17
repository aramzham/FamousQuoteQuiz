﻿using FamousQuoteQuiz.Dal;
using FamousQuoteQuiz.Dal.Models;
using FamousQuoteQuiz.Dal.Models.UpdateModels;
using FamousQuoteQuiz.MVC.Infrastructure;
using FamousQuoteQuiz.MVC.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.MVC.Controllers;

public class UserController : Controller
{
    private readonly ISqlClient _sqlClient;

    public UserController(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    [HttpGet]
    [Route("/settings")]
    public IActionResult Settings()
    {
        return View();
    }

    [HttpPost]
    [Route("/savesettings")]
    public async Task<IActionResult> SaveSettings(UserPreferenceRequestModel requestModel)
    {
        await _sqlClient.UserDal.Update(requestModel.UserId,
            new UserUpdateModel() { QuestionType = requestModel.QuestionType });

        return Ok();
    }

    [HttpGet]
    [Route("/users")]
    [ServiceFilter(typeof(CheckAdminActionFilter))]
    public async Task<IActionResult> ListOfUsers()
    {
        var users = await _sqlClient.UserDal.GetAll();

        return View(users);
    }

    [HttpPost]
    [Route("/user/add")]
    public async Task<IActionResult> Add(AddUserRequestModel requestModel)
    {
        var newUser = await _sqlClient.UserDal.Add(new User()
            { Name = requestModel.Name, QuestionType = (QuestionType)requestModel.QuestionType });

        return Ok(newUser);
    }

    [HttpPut]
    [Route("/user/update")]
    public async Task<IActionResult> Update(UpdateUserRequestModel requestModel)
    {
        var updatedUser = await _sqlClient.UserDal.Update(requestModel.UserId,
            new UserUpdateModel()
                { Name = requestModel.Name, QuestionType = (QuestionType?)requestModel.QuestionType });

        return Ok(updatedUser);
    }

    [HttpDelete]
    [Route("/user/delete/{userId:int}")]
    public async Task<IActionResult> Delete(int userId)
    {
        await _sqlClient.UserDal.Delete(userId);

        return Ok();
    }
}