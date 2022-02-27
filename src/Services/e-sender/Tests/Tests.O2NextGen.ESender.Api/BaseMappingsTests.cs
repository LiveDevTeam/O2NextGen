using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using O2NextGen.ESender.Api.Extensions;

namespace UnitTests.O2NextGen.ESender.Api
{
    public class BaseMappingsTests
    {
        private static readonly BaseMappings<FakeViewModel, FakeModel> BaseMappings =
            new BaseMappings<FakeViewModel, FakeModel>();

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_Id()
        {
            var expected = 1;
            var viewModel = new FakeViewModel { Id = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.Id);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_Id()
        {
            var expected = 2;
            var model = new FakeModel { Id = expected };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(expected, serviceModel.Id);
        }

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_ExternalId()
        {
            var expected = KeyGenerator.Generate(10);
            var viewModel = new FakeViewModel { ExternalId = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.ExternalId);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_ExternalIdd()
        {
            var expected = KeyGenerator.Generate(10);
            var model = new FakeModel { ExternalId = expected };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(expected, serviceModel.ExternalId);
        }

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_AddedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var viewModel = new FakeViewModel { AddedDate = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.AddedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_AddedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var model = new FakeModel { AddedDate = expected };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(expected, serviceModel.AddedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_DeletedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var viewModel = new FakeViewModel { DeletedDate = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.DeletedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_DeletedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var model = new FakeModel { DeletedDate = expected };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(expected, serviceModel.DeletedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_IsDeleted()
        {
            const bool expected = true;
            var viewModel = new FakeViewModel { IsDeleted = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.IsDeleted);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_IsDeleted()
        {
            var model = new FakeModel { IsDeleted = true };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(true, serviceModel.IsDeleted);
        }

        [Test]
        public void BaseMappingsTests_Map_ViewModelToModel_ModifiedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var viewModel = new FakeViewModel { ModifiedDate = expected };

            var model = BaseMappings.ToModel(viewModel);

            Assert.AreEqual(expected, model.ModifiedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ModelToViewModel_ModifiedDate()
        {
            var expected = DateTime.UtcNow.ConvertToUnixTime();
            var model = new FakeModel { ModifiedDate = expected };
            var serviceModel = BaseMappings.ToViewModel(model);
            Assert.AreEqual(expected, serviceModel.ModifiedDate);
        }

        [Test]
        public void BaseMappingsTests_Map_ReadOnlyCollection_ModelToViewModel_ModifiedDate()
        {
            var expectedId = KeyGenerator.Generate(10);

            var list = new List<FakeViewModel>
            {
                new FakeViewModel
                {
                    ExternalId = expectedId
                    // AddedDate = expectedAddedDate
                }
            };
            var expected = new ReadOnlyCollection<FakeViewModel>(list);

            var mList = new List<FakeModel>
            {
                new FakeModel
                {
                    ExternalId = expectedId
                    // AddedDate = expectedAddedDate
                }
            };
            var model = mList;
            var serviceModels = BaseMappings.ToViewModel(model);

            for (var i = 0; i < serviceModels.Count; i++)
                Assert.AreEqual(expected[i].Id,
                    ((ReadOnlyCollection<FakeViewModel>)serviceModels)[i].Id);
        }
    }
}