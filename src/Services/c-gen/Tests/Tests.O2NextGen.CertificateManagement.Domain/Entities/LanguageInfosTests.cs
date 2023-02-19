using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Entities;
using Tests.O2NextGen.CertificateManagement.Application.Controllers.ViewModels;

namespace Tests.O2NextGen.CertificateManagement.Domain.Entities;

[TestFixture]
public class LanguageInfosTests: BaseEntityTests<LanguageInfoEntity>
{
    #region Check for Class Name

    [Test]
    [TestCase("LanguageInfoEntity")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }

    #endregion
}