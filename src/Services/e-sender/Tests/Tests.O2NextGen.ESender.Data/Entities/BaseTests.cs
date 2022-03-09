using NUnit.Framework;

namespace UnitTests.O2NextGen.ESender.Data.Entities
{
    public class BaseTests<TClass>
        where TClass : class
    {
        #region Check the code style

        [TestCase("BaseTests")]
        public virtual void It_CheckClassName(string name = "")
        {
            Assert.AreEqual(name, typeof(TClass).Name);
        }
        #endregion

    }
}