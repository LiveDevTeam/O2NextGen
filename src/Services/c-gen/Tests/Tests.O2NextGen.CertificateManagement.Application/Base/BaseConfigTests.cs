using NUnit.Framework;

namespace Tests.O2NextGen.CertificateManagement.Application.Base;

[TestFixture]
public abstract class BaseConfigTests<TClass> : BaseTests<TClass>
    where TClass : class
{
    // [TestCase("BaseTests")]
    // public virtual void It_CheckClassName(string name = "")
    // {
    //     Assert.AreEqual(name, typeof(TClass).Name);
    // }
}