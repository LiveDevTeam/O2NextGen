using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.UpdateCertificate;
using Tests.O2NextGen.CertificateManagement.Application.Base;
using Assert = NUnit.Framework.Assert;

namespace Tests.O2NextGen.CertificateManagement.Domain.Entities
{
    [TestFixture]
    public class BaseEntityTests<TClass> : BaseTests<TClass>
        where TClass : class
    {
        #region Helper
    
        private static Mock<IEntity> MockBaseEntity()
        {
            var model = new Mock<IEntity>();
            model.SetupAllProperties();
            return model;
        }

        private class StubBaseEntity : BaseEntity
        {
        }
        [SetUp]
        public void Setup()
        {
            StubEntity = new StubBaseEntity
            {
                Id = 9,
                ExternalId = "ExternalId",
                AddedDate = 9,
                DeletedDate = 9,
                IsDeleted = true,
                ModifiedDate = 9
            };
        }

#pragma warning disable CS8618
        private StubBaseEntity StubEntity { get; set; }
#pragma warning restore CS8618

        #endregion

        #region Check for Class Name

        [Test]
        [TestCase("BaseEntity")]
        public override void It_CheckClassName(string name = "")
        {
            base.It_CheckClassName(name);
        }

        #endregion

        #region Tests Properties

        #region Tests fro Property Id

        [Test]
        public void BaseEntity_PropertyId_IsType_Test()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("Id",
                    typeof(long)));
        }

        [Test]
        public void BaseEntity_ExistProperty_Id()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("Id"));
        }

        #endregion

        #region Tests for Property ExternalId

        [Test]
        public void BaseEntity_PropertyExternalId_IsType()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ExternalId",
                    typeof(string)));
        }

        [Test]
        public void BaseEntity_ExistProperty_ExternalId()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ExternalId"));
        }


        #endregion

        #region Tests for Property ModifiedDate

        [Test]
        public void BaseEntity_PropertyModifiedDate_IsType()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("ModifiedDate",
                    typeof(long)));
        }

        [Test]
        public void BaseEntity_ExistProperty_ModifiedDate()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("ModifiedDate"));
        }

        #endregion

        #region Tests for Property AddedDate

        [Test]
        public void BaseEntity_PropertyAddedDate_IsType()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("AddedDate",
                    typeof(long)));
        }

        [Test]
        public void BaseEntity_ExistProperty_AddedDate()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("AddedDate"));
        }

        #endregion

        #region Tests for Property DeletedDate

        [Test]
        public void BaseEntity_PropertyDeletedDate_IsType()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("DeletedDate",
                    typeof(long?)));
        }

        [Test]
        public void BaseEntity_ExistProperty_DeletedDate()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("DeletedDate"));
        }

        #endregion

        #region Tests for Property IsDaleted

        [Test]
        public void BaseEntity_PropertyIsDeleted_IsType()
        {
            Assert.IsTrue(
                BaseHelper<UpdateCertificate>.It_CheckExistPropertyOfType("IsDeleted",
                    typeof(bool?)));
        }

        [Test]
        public void BaseEntity_ExistProperty_IsDeleted()
        {
            Assert.IsTrue(BaseHelper<UpdateCertificate>.It_CheckExistProperty("IsDeleted"));
        }

        #endregion

        #endregion

        #region Test GET / SET for Properties

        [Test]
        public void BaseEntity_Property_Id_Test()
        {
            var model = MockBaseEntity();

            model.Object.Id = StubEntity.Id;

            Assert.That(model.Object.Id, Is.EqualTo(StubEntity.Id));
        }

        [Test]
        public void BaseEntity_Property_ExternalId_Test()
        {
            var model = MockBaseEntity();

            model.Object.ExternalId = StubEntity.ExternalId;

            Assert.That(model.Object.ExternalId, Is.EqualTo(StubEntity.ExternalId));
        }

  

        [Test]
        public void BaseEntity_Property_ModifiedDate_Test()
        {
            var model = MockBaseEntity();

            model.Object.ModifiedDate = StubEntity.ModifiedDate;

            Assert.That(model.Object.ModifiedDate, Is.EqualTo(StubEntity.ModifiedDate));
        }

        [Test]
        public void BaseEntity_Property_AddedDate_Test()
        {
            var model = MockBaseEntity();

            model.Object.AddedDate = StubEntity.AddedDate;

            Assert.That(model.Object.AddedDate, Is.EqualTo(StubEntity.AddedDate));
        }

        [Test]
        public void BaseEntity_Property_DeletedDate_Test()
        {
            var model = MockBaseEntity();

            model.Object.DeletedDate = StubEntity.DeletedDate;

            Assert.That(model.Object.DeletedDate, Is.EqualTo(StubEntity.DeletedDate));
        }

        [Test]
        public void BaseEntity_Property_IsDeleted_Test()
        {
            var model = MockBaseEntity();

            model.Object.IsDeleted = StubEntity.IsDeleted;

            Assert.That(model.Object.IsDeleted, Is.EqualTo(StubEntity.IsDeleted));
        }

        #endregion
    }
}