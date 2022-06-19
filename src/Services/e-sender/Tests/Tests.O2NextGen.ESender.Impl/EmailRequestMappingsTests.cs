using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using O2NextGen.ESender.Api.Extensions;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Data.Entities;
using O2NextGen.ESender.Impl.Mappings;
using O2NextGen.Sdk.NetCore.Models.e_sender;

namespace UnitTests.O2NextGen.ESender.Impl
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
    public class EmailRequestMappingsTests
    {
        private static readonly EmailRequestDbEntity Entity = new EmailRequestDbEntity();
        private static readonly EmailRequestModel Model = new EmailRequestModel();
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_To()
        {
            var expected = "To";
            Model.To = expected;
            var packageViewModel = Model.ToEntity();
            Assert.AreEqual(expected, packageViewModel.To);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_To()
        {
            var expected = "To";
            Entity.To = expected;
            var serviceModel = Entity.ToModel();
            Assert.AreEqual(expected, serviceModel.To);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_Body()
        {
            var expected = "Body";
            Model.Body = expected;
            var packageViewModel = Model.ToEntity();
            Assert.AreEqual(expected, packageViewModel.Body);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_Body()
        {
            var expected = "Body";
            Entity.Body = expected;
            var serviceModel = Entity.ToModel();
            Assert.AreEqual(expected, serviceModel.Body);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_From()
        {
            var expected = "From";
            Model.From = expected;
            var packageViewModel = Model.ToEntity();
            Assert.AreEqual(expected, packageViewModel.From);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_From()
        {
            var expected = "From";
            Entity.From = expected;
            var serviceModel = Entity.ToModel();
            Assert.AreEqual(expected, serviceModel.From);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_Subject()
        {
            var expected = "Subject";
            Model.Subject = expected;
            var packageViewModel = Model.ToEntity();
            Assert.AreEqual(expected, packageViewModel.Subject);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_Subject()
        {
            var expected = "Subject";
            Entity.Subject = expected;
            var serviceModel = Entity.ToModel();
            Assert.AreEqual(expected, serviceModel.Subject);
        }
    }
}
