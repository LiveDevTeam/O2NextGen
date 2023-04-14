using System.IO;
using System.Reflection;
using NUnit.Framework;
using O2NextGen.ESender.Api.Controllers.NewCode;
using O2NextGen.ESender.Data.Entities;

namespace UnitTests.O2NextGen.ESender.Api.Controllers
{
    public class EmailTemplateControllerTests :
        BaseControllerTests<EmailTemplateController>
    {
        [Test]
        public void Get()
        {
   
            // Read a file
            //string readText = File.ReadAllText(@"C:\Temp\csc.txt");
        }

        [Test]
        public void GetAll()
        {
        }

        [Test]
        public void Put()
        {
        }

        [Test]
        public void Post()
        {
        }
    }
}