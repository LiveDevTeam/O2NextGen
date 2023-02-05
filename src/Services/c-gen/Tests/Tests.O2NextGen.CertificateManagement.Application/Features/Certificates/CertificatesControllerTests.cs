using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Features.Certificates;
using Tests.O2NextGen.CertificateManagement.Application.Base;
using Xunit;

namespace Tests.O2NextGen.CertificateManagement.Application.Features.Certificates;

public class CertificatesControllerTests: BaseControllerTests<CertificatesController>
{
    [Theory]
    [InlineData("CertificatesController")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Fact]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_0()
    {
        Assert.Contains(Attribute.GetCustomAttributes(typeof(CertificatesController), typeof(ApiVersionAttribute)), att =>
            ((ApiVersionAttribute) att).Versions.Any(x => x is {MajorVersion: 1, MinorVersion: 0}));
    }

    [Fact]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_1()
    {
        Assert.Contains(Attribute.GetCustomAttributes(typeof(CertificatesController), typeof(ApiVersionAttribute)), att =>
            ((ApiVersionAttribute) att).Versions.Any(x => x is {MajorVersion: 1, MinorVersion: 1}));
    }
}