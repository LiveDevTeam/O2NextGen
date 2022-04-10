using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.CertificateManagement.Api.Models.CGen;
using O2NextGen.CertificateManagement.Business.Models;

namespace O2NextGen.CertificateManagement.Api.Mappings
{
    public static class CertificateMappings
    {
        public static CertificateViewModel ToViewModel(this Certificate model)
        {
            if (model == null)
                return null;

            var viewModel = new CertificateViewModel();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;

            return viewModel;
        }

        public static Certificate ToModel(this CertificateViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = new Certificate();

            //Bindings
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;

            return model;
        }

        public static IReadOnlyCollection<CertificateViewModel> ToViewModel(
            this IReadOnlyCollection<Certificate> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<CertificateViewModel>();
            }

            var subscription = new CertificateViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<CertificateViewModel>(subscription);
        }
    }
}