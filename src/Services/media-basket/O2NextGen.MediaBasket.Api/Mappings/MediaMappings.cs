using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.Sdk.NetCore.Models.media_basket;


namespace O2NextGen.MediaBasket.Api.Mappings
{
    public static class MediaMappings
    {
        public static MediaViewModel ToViewModel(this Media model)
        {
            if (model == null)
                return null;

            var viewModel = new MediaViewModel();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.OriginalName = model.OriginalName;
            viewModel.PublicId = model.PublicId;
            viewModel.AccountId = model.AccountId;
            viewModel.ContentType = model.ContentType;
            viewModel.DateAdded = model.DateAdded;
            viewModel.Description = model.Description;
            viewModel.Width = model.Width;
            viewModel.Height = model.Height;
            viewModel.ExtType = model.ExtType;
            viewModel.MediaType = model.MediaType;
            viewModel.Url = model.Url;

            return viewModel;
        }

        public static Media ToModel(this MediaViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var model = new Media();

            //Bindings
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;
            model.OriginalName = viewModel.OriginalName;
            model.PublicId = viewModel.PublicId;
            model.AccountId = viewModel.AccountId;
            model.ContentType = viewModel.ContentType;
            model.DateAdded = viewModel.DateAdded;
            model.Description = viewModel.Description;
            model.Width = viewModel.Width ?? 0;
            model.Height = viewModel.Height ?? 0;
            model.ExtType = viewModel.ExtType;
            model.MediaType = viewModel.MediaType;
            model.Url = viewModel.Url;

            return model;
        }

        public static IReadOnlyCollection<MediaViewModel> ToViewModel(
            this IReadOnlyCollection<Media> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<MediaViewModel>();
            }

            var subscription = new MediaViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<MediaViewModel>(subscription);
        }
    }
}