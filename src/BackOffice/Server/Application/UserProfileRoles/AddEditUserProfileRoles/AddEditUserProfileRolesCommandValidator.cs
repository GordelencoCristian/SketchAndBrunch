using FluentValidation;
using Persistance.Contexts;

namespace BackOffice.Server.Application.UserProfileRoles.AddEditUserProfileRoles
{
    public class AddEditUserProfileRolesCommandValidator : AbstractValidator<AddEditUserProfileRolesCommand>
    {
        private readonly AppDbContext _appDbContext;
        public AddEditUserProfileRolesCommandValidator(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            //RuleFor(x => x.RoleModel.Id)
            //    .SetValidator(new ItemMustExistValidator<Bulletin>(appDbContext, ValidationCodes.EMPTY_BULLETIN_EMITTER,
            //        ValidationMessages.InvalidReference));
        }
    }
}
