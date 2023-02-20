using System;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Services;

namespace Tests.O2NextGen.CertificateManagement.Application.Services;

public class CustomerServiceTests : BaseServiceTests<CustomerService>
{
    
    [SetUp]
    public new void Setup()
    {
        var mock = new Mock<IHttpContextAccessor>();
        Service = new CustomerService(mock.Object);
    }
    private static Mock<ICustomerService> GetMock()
    {
        var model = new Mock<ICustomerService>();
        model.SetupAllProperties();
        return model;
    }
#pragma warning disable CS8618
    private ICustomerService Service { get; set; }
#pragma warning restore CS8618
    
    [Test]
    [TestCase("CustomerService")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
    
    
    [Test]
    public void CreateCategoryModel_Property_CustomerId_Test()
    {
        var model = GetMock();

        model.Object.CustomerId = Service.CustomerId;

        Assert.That(model.Object.CustomerId, Is.EqualTo(Service.CustomerId));
    }
    
    [Test]
    public void CreateCategoryModel_Property_CustomerDescription_Test()
    {
        var model = GetMock();

        model.Object.CustomerDescription = Service.CustomerDescription;

        Assert.That(model.Object.CustomerDescription, Is.EqualTo(Service.CustomerDescription));
    }
    [Test]
    public void CreateCategoryModel_Property_AccountLink_Test()
    {
        var model = GetMock();

        model.Object.AccountLink = Service.AccountLink;

        Assert.That(model.Object.AccountLink, Is.EqualTo(Service.AccountLink));
    }
    
    [Test]
    public void CreateCategoryModel_Property_RegisterLink_Test()
    {
        var model = GetMock();
        model.Object.RegisterLink = Service.RegisterLink;

        Assert.That(model.Object.RegisterLink, Is.EqualTo(Service.RegisterLink));
    }
}