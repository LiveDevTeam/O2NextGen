using NUnit.Framework;
using O2NextGen.CertificateManagement.Application;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

public class BaseConfigTests<TClass> : BaseTests<TClass>
    where TClass : class
{
}

public class UrlsConfigTests : BaseConfigTests<UrlsConfig>
{
    [Test]
    [TestCase("UrlsConfig")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }


    [Test]
    public void SubscriptionEntityTests_PropertyIdentityUrl_IsType()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistPropertyOfType("IdentityUrl", typeof(string)));
    }

    [Test]
    public void SubscriptionEntityTests_ExistProperty_IdentityUrl()
    {
        Assert.IsTrue(BaseHelper<UrlsConfig>.It_CheckExistProperty("IdentityUrl"));
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
}