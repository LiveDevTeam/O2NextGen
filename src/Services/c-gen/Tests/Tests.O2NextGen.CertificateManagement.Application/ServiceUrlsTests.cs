using O2NextGen.CertificateManagement.Application;
using Tests.O2NextGen.CertificateManagement.Application.Base;
using Xunit;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class ServiceUrlsTests : BaseConfigTests<ServiceUrls>
{
    [Theory]
    [InlineData("ServiceUrls")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
    
    [Fact]
    public void UrlsConfigTests_PropertyIdentityUrl_IsType()
    {
        Assert.True(BaseHelper<ServiceUrls>.It_CheckExistPropertyOfType("IdentityUrl", typeof(string)));
    }
    
    [Fact]
    public void UrlsConfigTests_PropertyCGenUrl_IsType()
    {
        Assert.True(BaseHelper<ServiceUrls>.It_CheckExistPropertyOfType("CGenUrl", typeof(string)));
    }
}