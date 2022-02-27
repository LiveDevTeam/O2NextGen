using NUnit.Framework;
using O2NextGen.ESender.Data.Entities;

namespace UnitTests.O2NextGen.ESender.Data.Entities
{
    public class BaseEntityTests<TEntityClass> : BaseTests<TEntityClass>
        where TEntityClass : class
    {

        [Test]
        public void BaseDbEntityTests_NameContainDbEntity()
        {
            Assert.IsTrue(typeof(TEntityClass).Name.Contains("DbEntity"));
        }

        [Test]
        public void BaseDbEntityTests_Implement_Test()
        {
            Assert.IsTrue(typeof(IDbEntity).IsAssignableFrom(typeof(TEntityClass)));
        }
        
        #region Check class properties
        [Test]
        public void BaseDbEntityTests_Property_Id_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistProperty("Id"));
        }

        [Test]
        public void BaseDbEntityTests_Property_Id_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistPropertyOfType("Id", typeof(long)));
        }

        [Test]
        public void BaseDbEntityTests_Property_ModifiedDate_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistProperty("ModifiedDate"));
        }

        [Test]
        public void BaseDbEntityTests_Property_ModifiedDate_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistPropertyOfType("ModifiedDate", typeof(long)));
        }

        [Test]
        public void BaseDbEntityTests_Property_AddedDate_ExistProperty_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistProperty("AddedDate"));
        }

        [Test]
        public void BaseDbEntityTests_Property_AddedDate_IsType_Test()
        {
            Assert.IsTrue(BaseHelper<TEntityClass>.It_CheckExistPropertyOfType("AddedDate", typeof(long)));
        }
        #endregion
        
        
        #region Check function Properties

        [Test]
        public void BaseDbEntityTests_Property_Id_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.Id = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.Id);
        }

        [Test]
        public void BaseDbEntityTests_Property_AddedDate_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.AddedDate = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.AddedDate);
        }

        [Test]
        public void BaseDbEntityTests_Property_ModifiedDate_Test()
        {
            var expected = 9;
            var mailRequestEntity = new EmailRequestDbEntity();
            
            mailRequestEntity.ModifiedDate = expected;
            
            Assert.AreEqual(expected,mailRequestEntity.ModifiedDate);
        }

        #endregion
    }
}