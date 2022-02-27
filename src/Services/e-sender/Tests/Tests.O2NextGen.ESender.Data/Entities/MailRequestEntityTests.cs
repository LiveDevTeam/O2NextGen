using NUnit.Framework;
using O2NextGen.ESender.Data.Entities;

namespace UnitTests.O2NextGen.ESender.Data.Entities
{
    public class MailRequestEntityTests :
        BaseEntityTests<EmailRequestDbEntity>
    {
        #region Check the code style

        [Test]
        [TestCase("EmailRequestDbEntity")]
        public override void It_CheckClassName(string name = "")
        {
            base.It_CheckClassName(name);
        }

        #endregion


        #region Check class properties

        [Test]
        public void MailRequestEntityTests_Property_From_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistProperty("From"));
        }

        [Test]
        public void MailRequestEntityTests_Property_From_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistPropertyOfType("From", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_To_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistProperty("To"));
        }

        [Test]
        public void MailRequestEntityTests_Property_To_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistPropertyOfType("To", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistProperty("Subject"));
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistPropertyOfType("Subject", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistProperty("Body"));
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestDbEntity>.It_CheckExistPropertyOfType("Body", typeof(string)));
        }

        #endregion


        #region Check function Properties

        [Test]
        public void MailRequestEntityTests_Property_To_Test()
        {
            var expected = "some_test_property_to";
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.To = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.To);
        }

        [Test]
        public void MailRequestEntityTests_Property_From_Test()
        {
            var expected = "some_test_property_from";
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.From = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.From);
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_Test()
        {
            var expected = "some_test_property_subject";
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.Subject = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Subject);
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_Test()
        {
            var expected = "some_test_property_body";
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.Body = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Body);
        }

        #endregion

    }
}