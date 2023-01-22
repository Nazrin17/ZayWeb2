using FluentValidation;
using ZayWebSite.Dtos.SettingDto;

namespace ZayWebSite.Validators.Setting
{
    public class SettingUpdateDtoValidation:AbstractValidator<SettingPostDto>
    {
        public SettingUpdateDtoValidation()
        {
            RuleFor(s => s.Email)
                .EmailAddress();
            RuleFor(s => s.Phone)
                .MaximumLength(18);
            RuleFor(s => s.Logo)
                .NotNull()
                .NotEmpty();
        }
    }
}
