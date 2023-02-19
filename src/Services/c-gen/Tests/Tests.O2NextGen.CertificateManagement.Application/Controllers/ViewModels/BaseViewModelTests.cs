using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

[TestFixture]
public class BaseViewModelTests<TClass>: BaseTests<TClass>
    where TClass : class
{
    #region Helper
    
    private static Mock<IViewModel> MockCategoryViewModel()
    {
        var model = new Mock<IViewModel>();
        model.SetupAllProperties();
        return model;
    }

    private class StubBaseViewModel : BaseViewModel
    {
        public StubBaseViewModel(long? id, string externalId,
            long? modifiedDate, long? addedDate,long? deletedDate,bool? isDeleted)
        {
            Id = id;
            ExternalId = externalId;
            ModifiedDate = modifiedDate;
            AddedDate = addedDate;
            DeletedDate = deletedDate;
            IsDeleted = isDeleted;
        }

        public StubBaseViewModel()
        {
            
        }
    }
    [SetUp]
    public void Setup()
    {
        ViewModel = new StubBaseViewModel
        {
            Id = 9,
            ExternalId = "ExternalId",
            AddedDate = 9,
            DeletedDate = 9,
            IsDeleted = true,
            ModifiedDate = 9
        };
    }

    private StubBaseViewModel ViewModel { get; set; }

    #endregion

    #region Check for Class Name

    [Test]
    [TestCase("BaseViewModel")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    #endregion

    #region Tests Properties

    #region Tests fro Property Id

    [Test]
    public void BaseViewModel_PropertyId_IsType_Test()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("Id",
                typeof(long)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_Id()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("Id"));
    }

    #endregion

    #region Tests for Property ExternalId

    [Test]
    public void BaseViewModel_PropertyExternalId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ExternalId",
                typeof(string)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_ExternalId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ExternalId"));
    }


    #endregion

    #region Tests for Property ModifiedDate

    [Test]
    public void BaseViewModel_PropertyModifiedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ModifiedDate",
                typeof(long)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_ModifiedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ModifiedDate"));
    }

    #endregion

    #region Tests for Property AddedDate

    [Test]
    public void BaseViewModel_PropertyAddedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("AddedDate",
                typeof(long)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_AddedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("AddedDate"));
    }

    #endregion

    #region Tests for Property DeletedDate

    [Test]
    public void BaseViewModel_PropertyDeletedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("DeletedDate",
                typeof(long?)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_DeletedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("DeletedDate"));
    }

    #endregion

    #region Tests for Property IsDaleted

    [Test]
    public void BaseViewModel_PropertyIsDeleted_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("IsDeleted",
                typeof(bool?)));
    }

    [Test]
    public void BaseViewModel_ExistProperty_IsDeleted()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("IsDeleted"));
    }

#endregion

    #endregion

    #region Test GET / SET for Properties

    [Test]
    public void BaseViewModel_Property_Id_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.Id = ViewModel.Id;

        Assert.That(model.Object.Id, Is.EqualTo(ViewModel.Id));
    }

    [Test]
    public void BaseViewModel_Property_ExternalId_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.ExternalId = ViewModel.ExternalId;

        Assert.That(model.Object.ExternalId, Is.EqualTo(ViewModel.ExternalId));
    }

  

    [Test]
    public void BaseViewModel_Property_ModifiedDate_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.ModifiedDate = ViewModel.ModifiedDate;

        Assert.That(model.Object.ModifiedDate, Is.EqualTo(ViewModel.ModifiedDate));
    }

    [Test]
    public void BaseViewModel_Property_AddedDate_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.AddedDate = ViewModel.AddedDate;

        Assert.That(model.Object.AddedDate, Is.EqualTo(ViewModel.AddedDate));
    }

    [Test]
    public void BaseViewModel_Property_DeletedDate_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.DeletedDate = ViewModel.DeletedDate;

        Assert.That(model.Object.DeletedDate, Is.EqualTo(ViewModel.DeletedDate));
    }

    [Test]
    public void BaseViewModel_Property_IsDeleted_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.IsDeleted = ViewModel.IsDeleted;

        Assert.That(model.Object.IsDeleted, Is.EqualTo(ViewModel.IsDeleted));
    }

    #endregion
}