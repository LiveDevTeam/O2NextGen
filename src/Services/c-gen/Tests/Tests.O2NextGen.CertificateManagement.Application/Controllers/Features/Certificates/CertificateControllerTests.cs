using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers.Features.Certificates;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application.Controllers.Features.Certificates;

[TestFixture]
public class CertificateControllerTests
    : BaseControllerTests<CertificatesController>
{
    #region Tests for Attributes

    [Test]
    [TestCase("CertificatesController")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_0()
    {
        Assert.IsTrue(
            Attribute.GetCustomAttributes(typeof(CertificatesController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 0)));
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_1()
    {
        Assert.IsTrue(
            Attribute.GetCustomAttributes(typeof(CertificatesController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 1)));
    }

    #endregion

    #region Test for Methods

    #endregion
}