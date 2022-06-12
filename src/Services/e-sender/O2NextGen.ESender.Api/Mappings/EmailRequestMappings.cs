using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.ESender.Business.Models;
using O2NextGen.Sdk.NetCore.Models.e_sender;

namespace O2NextGen.ESender.Api.Mappings
{
    public static class EmailRequestMappings
    {
        private static readonly
            BaseMappings<EmailRequestViewModel, EmailRequestModel> BaseMappings;
        
        static EmailRequestMappings()
        {
            BaseMappings =
                new BaseMappings<EmailRequestViewModel, EmailRequestModel>();
        }
        
        public static EmailRequestViewModel ToViewModel(this EmailRequestModel model)
        {
            if (model == null)
                return null;

            var viewModel = BaseMappings.ToViewModel(model);

            //Bindings
            viewModel.From = model.From;
            viewModel.To = model.To;
            viewModel.Subject = model.Subject;
            viewModel.Body = model.Body;
            
            return viewModel;
        }

        public static EmailRequestModel ToModel(this EmailRequestViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = BaseMappings.ToServiceModel(viewModel);

            //Bindings
            model.From = viewModel.From;
            model.To = viewModel.To;
            model.Subject = viewModel.Subject;
            model.Body = viewModel.Body;

            return model;
        }

        public static IReadOnlyCollection<EmailRequestViewModel> ToViewModel(
            this IReadOnlyCollection<EmailRequestModel> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<EmailRequestViewModel>();
            }

            var subscription = new EmailRequestViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<EmailRequestViewModel>(subscription);
        }
        
        public static IReadOnlyCollection<EmailRequestModel> ToModel(
            this IReadOnlyCollection<EmailRequestViewModel> models)
        {
            if (models.Count == 0) return Array.Empty<EmailRequestModel>();

            var subscription = new EmailRequestModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToModel(model);
                ++i;
            }

            return new ReadOnlyCollection<EmailRequestModel>(subscription);
        }
    }
}