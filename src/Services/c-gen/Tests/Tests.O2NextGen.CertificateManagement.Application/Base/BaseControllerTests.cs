using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

// [TestFixture]
public class BaseControllerTests<TClass> : BaseTests<TClass>
    where TClass : class
{
    [Test]
    public void ControllerBaseTests_AttributeApiController()
    {
        Assert.IsNotNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(ApiControllerAttribute)));
    }

    [Test]
    public void ControllerBaseTests_AttributeRoute()
    {
        Assert.IsNotNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(RouteAttribute)));
    }

    [Test]
    public void ControllerBaseTests_NotAttributeAuthorize()
    {
        Assert.IsNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(AuthorizeAttribute)));
    }

    [Test]
    public void ControllerBaseTests_AttributeApiVersion()
    {
        Assert.IsNotNull(Attribute.GetCustomAttributes(typeof(TClass), typeof(ApiVersionAttribute)));
    }

    [Test]
    public void ControllerBaseTests_BaseClass()
    {
        Assert.IsTrue(typeof(ControllerBase).IsAssignableFrom(typeof(TClass)));
    }

    [Test]
    public void ControllerBaseTests_NameContainController()
    {
        Assert.IsTrue(typeof(TClass).Name.Contains("Controller"));
    }

    [Test]
    public void Methods_MarkerAttributePostOrGetOrDelete()
    {
        var result = typeof(TClass)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Count(p =>
                p.GetCustomAttribute(typeof(HttpGetAttribute), false) == null
                &&
                p.GetCustomAttribute(typeof(HttpPostAttribute), false) == null
                &&
                p.GetCustomAttribute(typeof(HttpDeleteAttribute), false) == null
                &&
                p.GetCustomAttribute(typeof(HttpPutAttribute), false) == null
            );
        Assert.IsTrue(result == 0);
    }
}