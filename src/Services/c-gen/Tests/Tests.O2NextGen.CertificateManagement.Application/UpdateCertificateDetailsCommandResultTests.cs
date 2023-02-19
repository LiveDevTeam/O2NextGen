using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Entities;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class UpdateCertificateTests
    : BaseConfigTests<UpdateCertificate>
{
    [Test]
    [TestCase("UpdateCertificate")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Test]
    public void UpdateCertificateTests_PropertyId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("Id",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_Id()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("Id"));
    }


    [Test]
    public void UpdateCertificateTests_PropertyExternalId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ExternalId",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_ExternalId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ExternalId"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyModifiedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ModifiedDate",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_ModifiedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ModifiedDate"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyAddedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("AddedDate",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_AddedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("AddedDate"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyDeletedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("DeletedDate",
                typeof(long?)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_DeletedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("DeletedDate"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyIsDeleted_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("IsDeleted",
                typeof(bool?)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_IsDeleted()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("IsDeleted"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyOwnerAccountId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("OwnerAccountId",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_OwnerAccountId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("OwnerAccountId"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyCustomerId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("CustomerId",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_CustomerId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("CustomerId"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyExpiredDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ExpiredDate",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_ExpiredDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ExpiredDate"));
    }


    [Test]
    public void UpdateCertificateTests_PropertyPublishDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("PublishDate",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_PublishDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("PublishDate"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyCreatorId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("CreatorId",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_CreatorId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("CreatorId"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyPublishCode_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("PublishCode",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_PublishCode()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("PublishCode"));
    }


    [Test]
    public void UpdateCertificateTests_PropertyIsVisible_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("IsVisible",
                typeof(bool)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_IsVisible()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("IsVisible"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyCategoryId_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("CategoryId",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_CategoryId()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("CategoryId"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyCategory_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("Category",
                typeof(Category)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_Category()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("Category"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyLock_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("Lock",
                typeof(bool)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_Lock()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("Lock"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyLockedDate_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("LockedDate",
                typeof(long)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_LockedDate()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("LockedDate"));
    }

    [Test]
    public void UpdateCertificateTests_PropertyLockInfo_IsType()
    {
        Assert.IsTrue(
            BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("LockInfo",
                typeof(string)));
    }

    [Test]
    public void UpdateCertificateTests_ExistProperty_LockInfo()
    {
        Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("LockInfo"));
    }

    // [Test]
    // public void UpdateCertificateTests_PropertyLanguageInfos_IsType()
    // {
    //     Assert.IsTrue(
    //         BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("LanguageInfos",
    //             typeof(LanguageInfos)));
    // }
    //
    // [Test]
    // public void UpdateCertificateTests_ExistProperty_LanguageInfos()
    // {
    //     Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("LanguageInfos"));
    // }

    // [Test]
    // public void UpdateCertificateTests_Property_Id()
    // {
    //     var model = new Mock<IUpdateCertificateDetailsCommandResult>();
    //     //Arrange
    //     model.Setup(_ => _.Id).Returns(It.IsAny<long>());
    //     
    //     //Act
    //     model.VerifySet(_=>_.Id = It.IsAny<long>());
    // }

    [Test]
    public void UpdateCertificateTests_Property_Id()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.Id).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);
        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getId = nameUser.Id;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.Id, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_ExternalId()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.ExternalId).Returns(It.IsAny<string>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.ExternalId;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.ExternalId, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_Name()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.Name).Returns(It.IsAny<string>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.Name;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.Name, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_ModifiedDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.ModifiedDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.ModifiedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.ModifiedDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_AddedDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.AddedDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.AddedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.AddedDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_DeletedDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.DeletedDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.DeletedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.DeletedDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_IsDeleted()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.IsDeleted).Returns(It.IsAny<bool>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.DeletedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.IsDeleted, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_OwnerAccountId()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.OwnerAccountId).Returns(It.IsAny<string>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.DeletedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.OwnerAccountId, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_CustomerId()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.CustomerId).Returns(It.IsAny<string>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.CustomerId;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.CustomerId, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_ExpiredDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.ExpiredDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.ExpiredDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.ExpiredDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_PublishDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.PublishDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.PublishDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.PublishDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_IsVisible()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.IsVisible).Returns(It.IsAny<bool>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.IsVisible;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.IsVisible, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_CategoryId()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.CategoryId).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.CategoryId;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.CategoryId, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_Category()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.Category).Returns(It.IsAny<Category>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.Category;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.Category, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }


    [Test]
    public void UpdateCertificateTests_Property_Lock()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.Lock).Returns(It.IsAny<bool>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.Lock;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.Lock, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_LockedDate()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.LockedDate).Returns(It.IsAny<long>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.LockedDate;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.LockedDate, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    [Test]
    public void UpdateCertificateTests_Property_LockInfo()
    {
        var model = new Mock<IUpdateCertificate>();

        model.Setup(_ => _.LockInfo).Returns(It.IsAny<string>());

        var nameUser = new UpdateCertificate(
            model.Object.Id,
            model.Object.ExternalId,
            model.Object.ModifiedDate,
            model.Object.AddedDate,
            model.Object.DeletedDate,
            model.Object.IsDeleted,
            model.Object.OwnerAccountId,
            model.Object.CustomerId,
            model.Object.ExpiredDate,
            model.Object.PublishDate,
            model.Object.CreatorId,
            model.Object.PublishCode,
            model.Object.IsVisible,
            model.Object.CategoryId,
            model.Object.Category,
            model.Object.Lock,
            model.Object.LockedDate,
            model.Object.LockInfo,
            model.Object.LanguageInfos);

        //Arrange
        //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
        var getPropertyValue = nameUser.LockInfo;

        //Act
        //model.VerifySet(_=>_.Id = It.IsAny<long>());
        model.VerifyGet(_ => _.LockInfo, Times.Once);
        //Assert.Equals(It.IsAny<long>(),getId);
    }

    // [Test]
    // public void UpdateCertificateTests_Property_LanguageInfos()
    // {
    //     var model = new Mock<IUpdateCertificateDetailsCommandResult>();
    //     
    //     model.Setup(_ => _.LanguageInfos).Returns(It.IsAny<LanguageInfos>());
    //     
    //     var nameUser = new UpdateCertificate(
    //         model.Object.Id,
    //         model.Object.ExternalId,
    //         model.Object.ModifiedDate,
    //         model.Object.AddedDate,
    //         model.Object.DeletedDate,
    //         model.Object.IsDeleted,
    //         model.Object.OwnerAccountId,
    //         model.Object.CustomerId,
    //         model.Object.ExpiredDate,
    //         model.Object.PublishDate,
    //         model.Object.CreatorId,
    //         model.Object.PublishCode,
    //         model.Object.IsVisible,
    //         model.Object.CategoryId,
    //         model.Object.Category,
    //         model.Object.Lock,
    //         model.Object.LockedDate,
    //         model.Object.LockInfo,
    //         model.Object.LanguageInfos);
    //     
    //     //Arrange
    //     //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
    //     var getPropertyValue = nameUser.LanguageInfos;
    //     
    //     //Act
    //     //model.VerifySet(_=>_.Id = It.IsAny<long>());
    //     model.VerifyGet(_=>_.LanguageInfos, Times.Once);
    //     //Assert.Equals(It.IsAny<long>(),getId);
    // }
}