using O2NextGen.CertificateManagement.Api.ViewModels;
using O2NextGen.CertificateManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace O2NextGen.CertificateManagement.Api.Mappings
{
    public static class CategoryMappinsg
    {
        public static CategoryViewModel ToViewModel(this Category model)
        {
            if (model == null)
                return null;

            var viewModel = new CategoryViewModel();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;

            return viewModel;
        }

        public static Category ToModel(this CategoryViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = new Category();

            //Bindings
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;

            return model;
        }

        public static IReadOnlyCollection<CategoryViewModel> ToViewModel(
            this IReadOnlyCollection<Category> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<CategoryViewModel>();
            }

            var subscription = new CategoryViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<CategoryViewModel>(subscription);
        }
    }
}
