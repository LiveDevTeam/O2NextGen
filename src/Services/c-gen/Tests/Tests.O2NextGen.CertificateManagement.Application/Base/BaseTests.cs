using Xunit;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

public class BaseTests<TClass>
    where TClass : class
{
    public virtual void It_CheckClassName(string name = "")
    {
        Assert.Equal(name, typeof(TClass).Name);
    }
}