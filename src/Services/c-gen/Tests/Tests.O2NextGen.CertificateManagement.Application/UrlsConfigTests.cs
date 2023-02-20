using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class UrlsConfigTests : BaseConfigTests<UrlsConfig>
{
    private IUrlsConfig config;
    
    [SetUp]
    public new void Setup()
    {
        config = new UrlsConfig
        {
            IdentityUrl = "IdentityUrl",
            CGenUrl = "CGenUrl"
            // TimeLifeInDays = 9,
            // CategoryName = "CategoryName",
            // CategorySeries = "CategorySeries",
            // CustomerId = "CustomerId",
            // QuantityCertificates = 9,
            // CategoryDescription = "CategoryDescription"
        };
    }
    private static Mock<IUrlsConfig> MockCategoryViewModel()
    {
        var model = new Mock<IUrlsConfig>();
        model.SetupAllProperties();
        return model;
    }
    
    [Test]
    [TestCase("UrlsConfig")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }


    [Test]
    public void UrlsConfigTests_PropertyIdentityUrl_IsType()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistPropertyOfType("IdentityUrl", typeof(string)));
    }

    [Test]
    public void UrlsConfigTests_ExistProperty_IdentityUrl()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistProperty("IdentityUrl"));
    }

    [Test]
    public void UrlsConfigTests_PropertyCGenUrl_IsType()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistPropertyOfType("CGenUrl", typeof(string)));
    }

    [Test]
    public void UrlsConfigTests_ExistProperty_CGenUrl()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistProperty("CGenUrl"));
    }

    
    //[Test]
    //public void SubscriptionEntityTests_PropertyTypeNotificationUrl_IsType()
    //{
    //    Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistPropertyOfType("NotificationUrl", typeof(string)));
    //}

    //[Test]
    //public void SubscriptionEntityTests_ExistProperty_NotificationUrl()
    //{
    //    Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistProperty("NotificationUrl"));
    //}
    
   
    
    
    
    [Test]
    public void CreateCategoryModel_Property_IdentityUrl_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.IdentityUrl = config.IdentityUrl;

        Assert.That(model.Object.IdentityUrl, Is.EqualTo(config.IdentityUrl));
    }
    [Test]
    public void CreateCategoryModel_Property_CGenUrl_Test()
    {
        var model = MockCategoryViewModel();

        model.Object.CGenUrl = config.CGenUrl;

        Assert.That(model.Object.CGenUrl, Is.EqualTo(config.CGenUrl));
    }
    
    // [Test]
    // public void UrlsConfigTests_SetProperty_IdentityUrl()
    // {
    //     var model = new Mock<IUrlsConfig>();
    //     
    //     //model.Setup(_ => _.IdentityUrl).Returns(It.IsAny<string>());
    //
    //     var nameUser = new UrlsConfig
    //     {
    //         IdentityUrl = model.Object.IdentityUrl
    //     };
    //
    //     //Arrange
    //     //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
    //     nameUser.IdentityUrl = "IdentityUrl";
    //     
    //     //Act
    //     model.VerifySet(_=>_.IdentityUrl = "IdentityUrl");
    //     //Assert.Equals(It.IsAny<long>(),getId);
    // }
    // [Test]
    // public void UrlsConfigTests_Property_CGenUrl()
    // {
    //     var model = new Mock<IUrlsConfig>();
    //     
    //     model.Setup(_ => _.CGenUrl).Returns(It.IsAny<string>());
    //
    //     var nameUser = new UrlsConfig
    //     {
    //         CGenUrl = "CGenUrl"
    //     };
    //
    //     //Arrange
    //     //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
    //     var getId = nameUser.CGenUrl;
    //     
    //     //Act
    //     //model.VerifySet(_=>_.Id = It.IsAny<long>());
    //     model.VerifyGet(_=>_.CGenUrl, Times.Once);
    //     //Assert.Equals(It.IsAny<long>(),getId);
    // }
    
    // [Test]
    // public void UrlsConfigTests_Property_IdentityUrl()
    // {
    //     var model = new Mock<IUrlsConfig>();
    //     
    //     model.Setup(_ => _.IdentityUrl).Returns(It.IsAny<string>());
    //
    //     var nameUser = new UrlsConfig
    //     {
    //         IdentityUrl = "IdentityUrl"
    //     };
    //
    //     //Arrange
    //     //model.Setup(_ => _.Id).Returns(It.IsAny<long>());
    //     var getId = nameUser.IdentityUrl;
    //     
    //     //Act
    //     //model.VerifySet(_=>_.Id = It.IsAny<long>());
    //     model.VerifyGet(_=>_.IdentityUrl, Times.Once);
    //     //Assert.Equals(It.IsAny<long>(),getId);
    // }
}