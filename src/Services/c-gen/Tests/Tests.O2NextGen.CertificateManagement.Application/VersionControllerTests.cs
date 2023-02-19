using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application;

[TestFixture]
public class VersionControllerTests : BaseControllerTests<VersionController>
{
    [Test]
    public void VersionController_GetVersion_Test()
    {
        var moq = new Mock<IWebHostEnvironment>();
        var loggerMoq = new Mock<ILogger<StubVersionController>>();
        var stub = new StubVersionController(moq.Object, loggerMoq.Object)
        {
            VersionString = "1.0.0.0"
        };

        var result = stub.Index();

        // Assert
        Assert.NotNull(result);
    }

    #region Tests for Attributes

    [Test]
    [TestCase("VersionController")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_NotSupported_v1_0()
    {
        Assert.IsFalse(
            Attribute.GetCustomAttributes(typeof(VersionController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x is {MajorVersion: 1, MinorVersion: 0})));
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_NotSupported_v1_1()
    {
        Assert.IsFalse(
            Attribute.GetCustomAttributes(typeof(VersionController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x is {MajorVersion: 1, MinorVersion: 1})));
    }

    #endregion
}