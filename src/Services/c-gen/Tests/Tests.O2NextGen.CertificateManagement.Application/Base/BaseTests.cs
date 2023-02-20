using NUnit.Framework;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

// [TestFixture]
public class BaseTests<TClass>
    where TClass : class
{
    [TestCase("BaseTests")]
    public virtual void It_CheckClassName(string name = "")
    {
        Assert.AreEqual(name, typeof(TClass).Name);
    }
}