using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.ESender.Api.Extensions;
using O2NextGen.ESender.Business.Models;
using O2NextGen.Sdk.NetCore.Models.e_sender;

namespace O2NextGen.ESender.Api.Mappings
{
    public class BaseMappings<TViewModel, TModel>
        where TViewModel : class, IViewModel
        where TModel : class, IBaseModel
    {
        public TViewModel ToViewModel(TModel model)
        {
            if (model == null)
                return null;

            var returnViewModel = Activator.CreateInstance<TViewModel>();

            returnViewModel.Id = model.Id;
            returnViewModel.ExternalId = model.ExternalId;
            returnViewModel.AddedDate = model.AddedDate;
            returnViewModel.ModifiedDate = model.ModifiedDate;
            returnViewModel.DeletedDate = model.DeletedDate;
            returnViewModel.IsDeleted = model.IsDeleted;

            return returnViewModel;
        }

        public TModel ToServiceModel(TViewModel viewModel)
        {
            //Todo: return not null
            if (viewModel == null)
                return null;

            var model = Activator.CreateInstance<TModel>();

            model.Id = viewModel.Id;
            model.ExternalId = viewModel.ExternalId;
            model.AddedDate = viewModel.AddedDate ?? default(long);
            model.ModifiedDate = viewModel.ModifiedDate ?? default(long);
            model.DeletedDate = viewModel.DeletedDate ?? DateTime.Now.ConvertToUnixTime();
            model.IsDeleted = viewModel.IsDeleted ?? default(bool);

            return model;
        }

        public IReadOnlyCollection<TViewModel> ToViewModel(IReadOnlyCollection<TModel> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<TViewModel>();
            }

            var subscription = new TViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<TViewModel>(subscription);
        }
    }
}