using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Impl.Mappings
{
    public class BaseMappings<TViewModel, TModel>
        where TViewModel : class, IDbEntity
        where TModel : class, IBaseModel
    {
        public TViewModel ToViewModel(TModel model)
        {
            if (model == null)
                return null;

            var returnViewModel = Activator.CreateInstance<TViewModel>();

            returnViewModel.Id = model.Id;
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
            model.AddedDate = viewModel.AddedDate;
            model.ModifiedDate = viewModel.ModifiedDate;
            model.DeletedDate = viewModel.DeletedDate;
            model.IsDeleted = viewModel.IsDeleted;

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