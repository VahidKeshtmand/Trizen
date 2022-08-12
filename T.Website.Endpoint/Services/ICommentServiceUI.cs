using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Domain.Account;
using T.Domain.Comments;
using T.Website.Endpoint.Models.Comments;

namespace T.Website.Endpoint.Services;

public interface ICommentServiceUI
{
    BaseDto AddComment(AddCommentViewModel model);
}

public class CommentServiceUI : ICommentServiceUI
{
    private readonly IDatabaseContext _databaseContext;
    private readonly UserManager<User> _userManager;
    public CommentServiceUI(IDatabaseContext databaseContext, UserManager<User> userManager)
    {
        _databaseContext = databaseContext;
        _userManager = userManager;
    }

    public BaseDto AddComment(AddCommentViewModel model)
    {
        var isRegister = _userManager.Users.Any(x => x.Email == model.Email);
        if (!isRegister)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "ابتدا باید در سایت ثبت نام کنید !"
            };

        var comment = new Comment
        {
            Email = model.Email,
            FacilityRate = model.FacilityRate,
            LocationRate = model.LocationRate,
            Message = model.Message,
            ServiceRate = model.ServiceRate,
            Name = model.Name,
            ValueForMoneyService = model.ValueForMoneyService,
            HotelId = model.HotelId,
            UserId = model.UserId,
        };
        _databaseContext.Comments.Add(comment);
        _databaseContext.SaveChanges();

        return new BaseDto
        {
            IsSuccess = true,
            Message = "نظر شما با موفقیت ارسال شد. پس از بررسی روی سایت بارگذاری می شود."
        };

    }
}