using FluentValidation;
using T.Application.Dtos.Hotels;

namespace T.Application.Validator
{
    public class RegisterHotelValidator : AbstractValidator<RegisterHotelDto>
    {
        public RegisterHotelValidator()
        {
            RuleFor(x => x.PersonalName)
                .NotNull().WithMessage("فیلد نام شما نمی تواند خالی باشد !")
                .NotEmpty().WithMessage("فیلد نام شما نمی تواند خالی باشد !")
                .Length(3, 100).WithMessage("تعداد کاراکتر ها باید بین 3 تا 100 کاراکتر باشد");



        }
    }
}
