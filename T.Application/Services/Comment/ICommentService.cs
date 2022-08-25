using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Comments;
using T.Application.Dtos.Common;
using T.Common;
using T.Domain.Account;
using T.Domain.Comments;

namespace T.Application.Services.Comment;

public interface ICommentService
{
    PaginatedItemsDto<CommentListDto> GetList(int pageIndex, int pageCount);
    BaseDto Delete(int commentId);
    BaseDto Confirmed(int commentId);

}


public class CommentService : ICommentService
{
    private readonly IDatabaseContext _databaseContext;
    private readonly UserManager<User> _userManager;

    public CommentService(IDatabaseContext databaseContext, UserManager<User> userManager)
    {
        _databaseContext = databaseContext;
        _userManager = userManager;
    }

    public BaseDto Confirmed(int commentId)
    {
        var comment = _databaseContext.Comments.FirstOrDefault(x => x.Id == commentId);
        if (comment == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "کامنت پیدا نشد !"
            };

        comment.CommentStatus = CommentStatus.Confirmed;
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "نظر با موفقیت حذف شد !"
        };
    }

    public BaseDto Delete(int commentId)
    {
        var comment = _databaseContext.Comments.FirstOrDefault(x => x.Id == commentId);
        if (comment == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "کامنت پیدا نشد !"
            };

        _databaseContext.Comments.Remove(comment);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "نظر با موفقیت حذف شد !"
        };
    }

    public PaginatedItemsDto<CommentListDto> GetList(int pageIndex, int pageSize)
    {
        var rowsCount = 0;
        var comments = _databaseContext.Comments
            .Include(x => x.Hotel)
            .Include(x => x.Flight)
            .ThenInclude(x => x.AirlineCompany)
            .Select(x => new CommentListDto
            {
                Id = x.Id,
                Email = x.Email,
                InsertDate = EF.Property<DateTime>(x, "InsertDate").ToFarsi(),
                Name = x.Name,
                Message = x.Message,
                HotelName = x.Hotel.Name,
                UserId = x.UserId,
                CommentStatus = x.CommentStatus,
                AirlineCompanyName = x.Flight.AirlineCompany.Name,
                Destination = x.Flight.FlyingTo,
                Origin = x.Flight.FlyingFrom,
                TakeOfDate = x.Flight.TakeOffDate.Date.ToString(),
            }).ToPaged(pageIndex, pageSize, out rowsCount).ToList();


        var userNames = new List<string>();
        foreach (var item in comments.Select(x => x.UserId))
        {
            userNames.Add(_userManager.FindByIdAsync(item).Result.UserName);
        }
        var c = 0;
        foreach (var item in comments)
        {
            item.UserName = userNames[c];
            c++;
        }

        return new PaginatedItemsDto<CommentListDto>(pageIndex, pageSize, rowsCount, comments);
    }


}

