using NUnit.Framework;
using O2NextGen.ESender.Api.Mappings;
using O2NextGen.ESender.Business.Models;
using O2NextGen.Sdk.NetCore.Models.e_sender;

namespace UnitTests.O2NextGen.ESender.Api
{
    public class EmailRequestMappingsTests
    {
        private static readonly EmailRequestViewModel ViewModel = new EmailRequestViewModel();
        private static readonly EmailRequestModel Model = new EmailRequestModel();
        
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_To()
        {
            var expected = "To";
            Model.To = expected;
            var packageViewModel = Model.ToViewModel();
            Assert.AreEqual(expected, packageViewModel.To);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_To()
        {
            var expected = "To";
            ViewModel.To = expected;
            var serviceModel = ViewModel.ToModel();
            Assert.AreEqual(expected, serviceModel.To);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_Body()
        {
            var expected = "Body";
            Model.Body = expected;
            var packageViewModel = Model.ToViewModel();
            Assert.AreEqual(expected, packageViewModel.Body);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_Body()
        {
            var expected = "Body";
            ViewModel.Body = expected;
            var serviceModel = ViewModel.ToModel();
            Assert.AreEqual(expected, serviceModel.Body);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_From()
        {
            var expected = "From";
            Model.From = expected;
            var packageViewModel = Model.ToViewModel();
            Assert.AreEqual(expected, packageViewModel.From);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_From()
        {
            var expected = "From";
            ViewModel.From = expected;
            var serviceModel = ViewModel.ToModel();
            Assert.AreEqual(expected, serviceModel.From);
        }
        
        [Test]
        public void EmailRequestMappingsTests_Map_ModelToViewModel_Subject()
        {
            var expected = "Subject";
            Model.Subject = expected;
            var packageViewModel = Model.ToViewModel();
            Assert.AreEqual(expected, packageViewModel.Subject);
        }

        [Test]
        public void EmailRequestMappingsTests_Map_ViewModelToModel_Subject()
        {
            var expected = "Subject";
            ViewModel.Subject = expected;
            var serviceModel = ViewModel.ToModel();
            Assert.AreEqual(expected, serviceModel.Subject);
        }
    }
}