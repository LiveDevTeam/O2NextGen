using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

public class BaseControllerTests<TClass> : BaseTests<TClass>
    where TClass : class
{

    [Fact]
    public void ControllerBaseTests_AttributeApiController()
    {
        Assert.NotNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(ApiControllerAttribute)));
    }

    [Fact]
    public void ControllerBaseTests_AttributeRoute()
    {
        Assert.NotNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(RouteAttribute)));
    }

    [Fact]
    public virtual void ControllerBaseTests_AttributeAuthorize()
    {
        Assert.NotNull(Attribute.GetCustomAttribute(typeof(TClass), typeof(AuthorizeAttribute)));
    }

    [Fact]
    public virtual void ControllerBaseTests_AttributeApiVersion()
    {
        Assert.NotNull(Attribute.GetCustomAttributes(typeof(TClass), typeof(ApiVersionAttribute)));
    }
        
    [Fact]
    public void ControllerBaseTests_BaseClass()
    {
        Assert.True(typeof(ControllerBase).IsAssignableFrom(typeof(TClass)));
    }

    [Fact]
    public void ControllerBaseTests_NameContainController()
    {
        Assert.Contains("Controller", typeof(TClass).Name);
    }

    [Fact]
    public void Methods_MarkerAttributePostOrGetOrDelete()
    {
        var result = typeof(TClass)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Count(p =>
                CustomAttributeExtensions.GetCustomAttribute((MemberInfo) p, typeof(HttpGetAttribute), false) == null
                &&
                CustomAttributeExtensions.GetCustomAttribute((MemberInfo) p, typeof(HttpPostAttribute), false) == null
                &&
                CustomAttributeExtensions.GetCustomAttribute((MemberInfo) p, typeof(HttpDeleteAttribute), false) == null
                &&
                CustomAttributeExtensions.GetCustomAttribute((MemberInfo) p, typeof(HttpPutAttribute), false) == null
            );
        Assert.True(result == 0);
    }
}