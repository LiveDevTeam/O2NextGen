using NUnit.Framework;
using O2NextGen.ESender.Business.Models;

namespace UnitTests.O2NextGen.ESender.Business.Models
{
    public class EmailRequestModelTests :
        BaseModelTests<EmailRequestModel>
    {
        #region Check the code style

        [Test]
        [TestCase("EmailRequestModel")]
        public override void It_CheckClassName(string name = "")
        {
            base.It_CheckClassName(name);
        }

        #endregion


        #region Check class properties

        [Test]
        public void MailRequestEntityTests_Property_From_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistProperty("From"));
        }

        [Test]
        public void MailRequestEntityTests_Property_From_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistPropertyOfType("From", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_To_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistProperty("To"));
        }

        [Test]
        public void MailRequestEntityTests_Property_To_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistPropertyOfType("To", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistProperty("Subject"));
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistPropertyOfType("Subject", typeof(string)));
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistProperty("Body"));
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<EmailRequestModel>.It_CheckExistPropertyOfType("Body", typeof(string)));
        }

        #endregion


        #region Check function Properties

        [Test]
        public void MailRequestEntityTests_Property_To_Test()
        {
            var expected = "some_test_property_to";
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.To = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.To);
        }

        [Test]
        public void MailRequestEntityTests_Property_From_Test()
        {
            var expected = "some_test_property_from";
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.From = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.From);
        }

        [Test]
        public void MailRequestEntityTests_Property_Subject_Test()
        {
            var expected = "some_test_property_subject";
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.Subject = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Subject);
        }

        [Test]
        public void MailRequestEntityTests_Property_Body_Test()
        {
            var expected = "some_test_property_body";
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.Body = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Body);
        }

        #endregion

    }
}