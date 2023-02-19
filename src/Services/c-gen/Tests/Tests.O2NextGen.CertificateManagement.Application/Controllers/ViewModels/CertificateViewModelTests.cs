using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers.ViewModels;
using O2NextGen.CertificateManagement.Domain.Entities;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

[TestFixture]
public class CertificateViewModelTests : BaseViewModelTests<CertificateViewModel>
{
    [SetUp]
    public new void Setup()
    {
        ViewModel = new CertificateViewModel
        {

        };
    }
    private static Mock<ICertificateViewModel> MockCertificateViewModel()
    {
        var model = new Mock<ICertificateViewModel>();
        model.SetupAllProperties();
        return model;
    }
#pragma warning disable CS8618
    private ICertificateViewModel ViewModel { get; set; }
#pragma warning restore CS8618

    [Test]
    [TestCase("CertificateViewModel")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
    
    #region Tests for Properties

    #region Tests for Property TimeLifeInDays

    [Test]
    public void CreateCertificateModel_PropertyOwnerAccountId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("OwnerAccountId",
                typeof(string)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_OwnerAccountId()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("OwnerAccountId"));
    }

    #endregion

    #region Tests for Property CategoryName

    [Test]
    public void CreateCertificateModel_PropertyExpiredDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("ExpiredDate",
                typeof(long)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_ExpiredDate()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("ExpiredDate"));
    }

    #endregion

    #region Tests for Property CategoryDescription

    [Test]
    public void CreateCertificateModel_PropertyPublishDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("PublishDate",
                typeof(long)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_PublishDate()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("PublishDate"));
    }

    #endregion

    #region Tests for Property CategorySeries

    [Test]
    public void CreateCertificateModel_PropertyCreatorId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("CreatorId",
                typeof(string)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_CreatorId()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("CreatorId"));
    }

    #endregion

    #region Tests for Property CustomerId

    [Test]
    public void CreateCertificateModel_PropertyCustomerId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("CustomerId",
                typeof(string)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_CustomerId()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("CustomerId"));
    }

    #endregion

    #region Tests for Property PublishCode

    [Test]
    public void CreateCertificateModel_PropertyPublishCode_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("PublishCode",
                typeof(string)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_PublishCode()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("PublishCode"));
    }

    #endregion

    #region Tests for Property QuantityPublishCode

    [Test]
    public void CreateCertificateModel_PropertyIsVisible_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("IsVisible",
                typeof(bool)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_IsVisible()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("IsVisible"));
    }

    #endregion
    #region Tests for Property CategoryEntity

    [Test]
    public void CreateCertificateModel_PropertyCategoryEntity_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("CategoryEntity",
                typeof(CategoryEntity)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_CategoryEntity()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("CategoryEntity"));
    }

    #endregion
    #region Tests for Property CategoryEntity

    [Test]
    public void CreateCertificateModel_PropertyLock_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("Lock",
                typeof(bool)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_Lock()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("Lock"));
    }

    #endregion
    #region Tests for Property CategoryEntity

    [Test]
    public void CreateCertificateModel_PropertyLockedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("LockedDate",
                typeof(long)));
    }

    [Test]
    public void CreateCertificateModel_ExistProperty_LockedDate()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("LockedDate"));
    }

    #endregion
    
    #region Tests for Property LockInfo

    [Test]
    public void CreateCertificateModel_PropertyLockInfo_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("LockInfo",
                typeof(string)));
    }
    
    [Test]
    public void CreateCertificateModel_ExistProperty_LockInfo()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("LockInfo"));
    }

    #endregion
    
    #region Tests for Property LanguageInfos

    [Test]
    public void CreateCertificateModel_PropertyLanguageInfos_IsType()
    {
        Assert.IsTrue(
            BaseHelper<CertificateViewModel>.It_CheckExistPropertyOfType("LanguageInfos",
                typeof(ICollection<LanguageInfoEntity>)));
    }
    
    [Test]
    public void CreateCertificateModel_ExistProperty_LanguageInfos()
    {
        Assert.IsTrue(BaseHelper<CertificateViewModel>.It_CheckExistProperty("LanguageInfos"));
    }

    #endregion
    #endregion
}