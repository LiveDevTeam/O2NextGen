using O2NextGen.Sdk.NetCore.Models.smalltalk;
using O2NextGen.SmallTalk.Business.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace O2NextGen.SmallTalk.Api.Mappings
{
    public static class ChatMessageMappings
    {
        public static ChatMessage ToViewModel(this ChatMessageModel model)
        {
            if (model == null)
                return null;

            var viewModel = new ChatMessage();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.Message = model.Message;
            viewModel.SenderId = model.SenderId;
            viewModel.RecipientId = model.RecipientId;

            return viewModel;
        }

        public static ChatMessageModel ToModel(this ChatMessage viewModel)
        {
            if (viewModel == null)
                return null;

            var model = new ChatMessageModel();

            //Bindings
            model.Id = viewModel.Id;
            model.Message = viewModel.Message;
            model.SenderId = viewModel.SenderId;
            model.RecipientId = viewModel.RecipientId;

            return model;
        }

        public static IReadOnlyCollection<ChatMessage> ToViewModel(
            this IReadOnlyCollection<ChatMessageModel> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<ChatMessage>();
            }

            var subscription = new ChatMessage[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                subscription[i] = ToViewModel(model);
                ++i;
            }

            return new ReadOnlyCollection<ChatMessage>(subscription);
        }
    }
}
