using O2Bionics.Services.IdPortal.Models;
using O2Bionics.Services.IdPortal.ViewModels;

namespace O2Bionics.Services.IdPortal.Mappings;

public static class UserMappings
{
    public static User ToService(this ApplicationUser entity)
        {
            if (entity == null)
                return null;

            var viewModel = new User();
            viewModel.Id = entity.Id;
            viewModel.UserName = entity.UserName;
            viewModel.FirstName = entity.FirstName;
            viewModel.LastName = entity.LastName;
            viewModel.Email = entity.Email;
            viewModel.LockoutEnabled = entity.LockoutEnabled;
            viewModel.PhoneNumber = entity.PhoneNumber;
            viewModel.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
            viewModel.EmailConfirmed = entity.EmailConfirmed;
            viewModel.AccessFailedCount = entity.AccessFailedCount;
            // var viewModel = BaseDataMappings.ToService(entity);
            // viewModel.AccountId = entity.AccountId;
            // viewModel.CustomerId = entity.CustomerId;
            // viewModel.CreatorId = entity.CreatorId;
            // viewModel.PublishCode = entity.PublishCode;
            // viewModel.IsVisible = entity.IsVisible;
            // viewModel.AccountId = entity.AccountId;
            // viewModel.PublishDate = entity.PublishDate;
            // viewModel.ExpiredDate = entity.ExpiredDate;
            // viewModel.CategoryId = entity.CategoryId;
            // viewModel.Lock = entity.Lock;
            // viewModel.LockedDate = entity.LockedDate;
            // viewModel.LockInfo = entity.LockInfo;
            // viewModel.CategoryModel = entity.Category.ToService();
            // viewModel.LanguageInfos = entity.LanguageInfos.ToList().ToService();
            return
                viewModel;
        }

        public static ApplicationUser ToEntity(this User model)
        {
            if (model == null)
                return null;
            var dbEntity = new ApplicationUser();
            dbEntity.Id = model.Id;
            dbEntity.UserName = model.UserName;
            dbEntity.FirstName = model.FirstName;
            dbEntity.LastName = model.LastName;
            dbEntity.Email = model.Email;
            dbEntity.LockoutEnabled = model.LockoutEnabled;
            dbEntity.PhoneNumber = model.PhoneNumber;
            dbEntity.LockoutEnd = model.LockoutEnd;
            dbEntity.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            dbEntity.EmailConfirmed = model.EmailConfirmed;
            dbEntity.AccessFailedCount = model.AccessFailedCount;
            // var dbEntity = BaseDataMappings.ToEntity(model);
            // dbEntity.CustomerId = model.CustomerId;
            // dbEntity.CreatorId = model.CreatorId;
            // dbEntity.IsVisible = model.IsVisible;
            // dbEntity.PublishCode = model.PublishCode;
            // dbEntity.AccountId = model.AccountId;
            // dbEntity.PublishDate = model.PublishDate;
            // dbEntity.ExpiredDate = model.ExpiredDate;
            // dbEntity.CategoryId = model.CategoryId;
            // dbEntity.Lock = model.Lock;
            // dbEntity.LockedDate = model.LockedDate;
            // dbEntity.LockInfo = model.LockInfo;
            // dbEntity.Category = model.CategoryModel.ToEntity();
            // dbEntity.LanguageInfos = model.LanguageInfos.ToEntity().ToList();
            return
                dbEntity;
        }
    public static IReadOnlyCollection<User> ToService(this IReadOnlyCollection<ApplicationUser> entities)
        => (IReadOnlyCollection<User>)entities.MapCollection(ToService);

    public static IReadOnlyCollection<ApplicationUser> ToEntity(this IReadOnlyCollection<User> entities)
        => (IReadOnlyCollection<ApplicationUser>)entities.MapCollection(ToEntity);
}