namespace SharedData.Validators
{
    //public class ItemMustExistValidator<TEntity> : AbstractValidator<int> where TEntity : SoftDeleteBaseEntity
    //{
    //    private readonly ModuleDbContext _appDbContext;

    //    public ItemMustExistValidator(ModuleDbContext appDbContext, string errorCode, string errorMessage)
    //    {
    //        _appDbContext = appDbContext;

    //        RuleFor(x => x).Custom((id, c) => ExistentRecord(id, errorCode, errorMessage, c));
    //    }

    //    private void ExistentRecord(int id, string errorCode, string errorMessage, CustomContext context)
    //    {
    //        DbSet<TEntity> collections = _appDbContext.Set<TEntity>();

    //        var existent = collections.Any(x => x.Id == id);

    //        if (!existent)
    //        {
    //            context.AddFailure(new ValidationFailure($"{context.PropertyName}", errorMessage)
    //            {
    //                ErrorCode = errorCode
    //            });
    //        }
    //    }
    //}
}
