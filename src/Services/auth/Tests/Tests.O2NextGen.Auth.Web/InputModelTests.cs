using NUnit.Framework;
using O2NextGen.Auth.Web.Pages;

namespace Tests.O2NextGen.Auth.Web
{
    public class InputModelTests
    {
        [Test]
        public void InputModel_Email_Test()
        {
            RegisterModel.InputModel model = new RegisterModel.InputModel();
            model.Email = "demo@demo.com";
            Assert.AreEqual("demo@demo.com",model.Email);
        }
    }
}
