using NUnit.Framework;
using O2NextGen.ESender.Business.Models;

namespace UnitTests.O2NextGen.ESender.Business.Models
{
    public class BaseModelTests<TModelClass> : BaseTests<TModelClass>
        where TModelClass : class
    {
        [Test]
        public void BaseModelTests_NameContainDbEntity()
        {
            Assert.IsTrue(typeof(TModelClass).Name.Contains("Model"));
        }
        
        [Test]
        public void BaseModelTests_Implement_Test()
        {
            Assert.IsTrue(typeof(IBaseModel).IsAssignableFrom(typeof(TModelClass)));
        }
        
        #region Check class properties
        [Test]
        public void BaseModelTests_Property_Id_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistProperty("Id"));
        }

        [Test]
        public void BaseModelTests_Property_Id_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistPropertyOfType("Id", typeof(long)));
        }

        [Test]
        public void BaseModelTests_Property_ModifiedDate_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistProperty("ModifiedDate"));
        }

        [Test]
        public void BaseModelTests_Property_ModifiedDate_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistPropertyOfType("ModifiedDate", typeof(long)));
        }

        [Test]
        public void BaseModelTests_Property_AddedDate_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistProperty("AddedDate"));
        }

        [Test]
        public void BaseModelTests_Property_AddedDate_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TModelClass>.It_CheckExistPropertyOfType("AddedDate", typeof(long)));
        }
        #endregion
        
        
        #region Check function Properties

        [Test]
        public void BaseModelTests_Property_Id_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.Id = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Id);
        }

        [Test]
        public void BaseModelTests_Property_AddedDate_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.AddedDate = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.AddedDate);
        }

        [Test]
        public void BaseModelTests_Property_ModifiedDate_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestModel();
            
            mailRequestEntity.ModifiedDate = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.ModifiedDate);
        }

        #endregion
    }
}