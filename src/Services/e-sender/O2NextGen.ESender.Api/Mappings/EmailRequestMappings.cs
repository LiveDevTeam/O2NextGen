using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.ESender.Api.Models;
using O2NextGen.ESender.Business.Models;

namespace O2NextGen.ESender.Api.Mappings
{
    public static class EmailRequestMappings
    {
        public static MailRequestViewModel ToViewModel(this EmailRequest model)
        {
            if (model == null)
                return null;

            var viewModel = new MailRequestViewModel();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.From = model.From;
            viewModel.To = model.To;
            viewModel.Subject = model.Subject;
            viewModel.Body = model.Body;
            
            return viewModel;
        }

        public static EmailRequest ToModel(this MailRequestViewModel requestViewModel)
        {
            if (requestViewModel == null)
                return null;

            var model = new EmailRequest();

            //Bindings
            model.Id = requestViewModel.Id;
            model.From = requestViewModel.From;
            model.To = requestViewModel.To;
            model.Subject = requestViewModel.Subject;
            model.Body = requestViewModel.Body;

            return model;
        }

        public static IReadOnlyCollection<MailRequestViewModel> ToViewModel(
            this IReadOnlyCollection<EmailRequest> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<MailRequestViewModel>();
            }

            var subscription = new MailRequestViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<MailRequestViewModel>(subscription);
        }
    }
}