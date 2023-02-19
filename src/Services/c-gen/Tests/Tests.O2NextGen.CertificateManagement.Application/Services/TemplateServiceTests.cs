using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Services;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class QrCodeServiceTests : BaseServiceTests<QrCodeService>
{
    [Test]
    [TestCase("QrCodeService")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
}

public class CustomerServiceTests : BaseServiceTests<CustomerService>
{
    [Test]
    [TestCase("CustomerService")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
}

public class IdentityServiceTests : BaseServiceTests<IdentityService>
{
    [Test]
    [TestCase("IdentityService")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
}

public class TemplateServiceTests : BaseServiceTests<TemplateService>
{
    [Test]
    [TestCase("TemplateService")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
}