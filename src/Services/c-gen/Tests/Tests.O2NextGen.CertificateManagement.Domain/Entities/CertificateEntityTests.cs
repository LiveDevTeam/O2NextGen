using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace Tests.O2NextGen.CertificateManagement.Domain.Entities
{
    [TestFixture]
    public class CertificateEntityTests : BaseEntityTests<CertificateEntity>
    {
        #region Check for Class Name

        [Test]
        [TestCase("CertificateEntity")]
        public override void It_CheckClassName(string name = "")
        {
            base.It_CheckClassName(name);
        }

        #endregion
    }
}