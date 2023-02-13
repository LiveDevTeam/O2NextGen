using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Features.ImportExport;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application.Features.Categories;

public class ServiceControllerTests
    : BaseControllerTests<ServiceController>
{
    [Test]
    [TestCase("ServiceController")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion_Supported_v1_0()
    {
        Assert.IsTrue(
            Attribute.GetCustomAttributes(typeof(ServiceController), typeof(ApiVersionAttribute)).Any(att =>
                ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 0)));
    }

    // [Test]
    // public void ControllerBaseTests_AttributeApiVersion_Supported_v1_1()
    // {
    //     Assert.IsTrue(
    //         Attribute.GetCustomAttributes(typeof(ServiceController), typeof(ApiVersionAttribute)).Any(att =>
    //             ((ApiVersionAttribute) att).Versions.Any(x => x.MajorVersion == 1 && x.MinorVersion == 1)));
    // }
}