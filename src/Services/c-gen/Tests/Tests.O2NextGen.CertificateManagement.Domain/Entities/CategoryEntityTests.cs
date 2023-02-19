using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Controllers.Features.Categories;
using O2NextGen.CertificateManagement.Domain.Entities;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Domain.Entities
{
    [TestFixture]
    public class CategoryEntityTests : BaseEntityTests<CategoryEntity>
    {
        [SetUp]
        public new void Setup()
        {
            CategoryEntity = new CategoryEntity
            {
                TimeLifeInDays = 9,
                CategoryName = "CategoryName",
                CategorySeries = "CategorySeries",
                CustomerId = "CustomerId",
                QuantityCertificates = 9,
                CategoryDescription = "CategoryDescription"
            };
        }
        private static Mock<ICategoryEntity> MockCategoryViewModel()
        {
            var model = new Mock<ICategoryEntity>();
            model.SetupAllProperties();
            return model;
        }
#pragma warning disable CS8618
        private CategoryEntity CategoryEntity { get; set; }
#pragma warning restore CS8618

        [Test]
        [TestCase("CategoryEntity")]
        public override void It_CheckClassName(string name = "")
        {
            base.It_CheckClassName(name);
        }

        #region Tests for Properties

        #region Tests for Property TimeLifeInDays

        [Test]
        public void CreateCategoryModel_PropertyTimeLifeInDays_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("TimeLifeInDays",
                    typeof(int)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_TimeLifeInDays()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("TimeLifeInDays"));
        }

        #endregion

        #region Tests for Property CategoryName

        [Test]
        public void CreateCategoryModel_PropertyCategoryName_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("CategoryName",
                    typeof(string)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_CategoryName()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("CategoryName"));
        }

        #endregion

        #region Tests for Property CategoryDescription

        [Test]
        public void CreateCategoryModel_PropertyCategoryDescription_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("CategoryDescription",
                    typeof(string)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_CategoryDescription()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("CategoryDescription"));
        }

        #endregion

        #region Tests for Property CategorySeries

        [Test]
        public void CreateCategoryModel_PropertyCategorySeries_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("CategorySeries",
                    typeof(string)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_CategorySeries()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("CategorySeries"));
        }

        #endregion

        #region Tests for Property CustomerId

        [Test]
        public void CreateCategoryModel_PropertyCustomerId_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("CustomerId",
                    typeof(string)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_CustomerId()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("CustomerId"));
        }

        #endregion

        #region Tests for Property QuantityCertificates

        [Test]
        public void CreateCategoryModel_PropertyQuantityCertificates_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("QuantityCertificates",
                    typeof(int)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_QuantityCertificates()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("QuantityCertificates"));
        }

        #endregion

        #region Tests for Property QuantityPublishCode

        [Test]
        public void CreateCategoryModel_PropertyQuantityPublishCode_IsType()
        {
            Assert.IsTrue(
                BaseHelper<CategoryEntity>.It_CheckExistPropertyOfType("QuantityPublishCode",
                    typeof(int)));
        }

        [Test]
        public void CreateCategoryModel_ExistProperty_QuantityPublishCode()
        {
            Assert.IsTrue(BaseHelper<CategoryEntity>.It_CheckExistProperty("QuantityPublishCode"));
        }

        #endregion

        #endregion

        #region Test GET / SET for Properties

        [Test]
        public void CategoryViewModel_Property_TimeLifeInDays_Test()
        {
            var model = new Mock<ICategoryViewModel>();

            model.SetupAllProperties();

            model.Object.TimeLifeInDays = CategoryEntity.TimeLifeInDays;

            Assert.That(model.Object.TimeLifeInDays, Is.EqualTo(CategoryEntity.TimeLifeInDays));
        }

        [Test]
        public void CreateCategoryModel_Property_CategoryName_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.CategoryName = CategoryEntity.CategoryName;

            Assert.That(model.Object.CategoryName, Is.EqualTo(CategoryEntity.CategoryName));
        }

        [Test]
        public void CreateCategoryModel_Property_CategoryDescription_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.CategoryDescription = CategoryEntity.CategoryDescription;

            Assert.That(model.Object.CategoryDescription, Is.EqualTo(CategoryEntity.CategoryDescription));
        }
    
        [Test]
        public void CreateCategoryModel_Property_CategorySeries_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.CategorySeries = CategoryEntity.CategorySeries;

            Assert.That(model.Object.CategorySeries, Is.EqualTo(CategoryEntity.CategorySeries));
        }


        [Test]
        public void CreateCategoryModel_Property_CustomerId_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.CustomerId = CategoryEntity.CustomerId;

            Assert.That(model.Object.CustomerId, Is.EqualTo(CategoryEntity.CustomerId));
        }

        [Test]
        public void CreateCategoryModel_Property_QuantityCertificates_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.QuantityCertificates = CategoryEntity.QuantityCertificates;

            Assert.That(model.Object.QuantityCertificates, Is.EqualTo(CategoryEntity.QuantityCertificates));
        }

        [Test]
        public void CreateCategoryModel_Property_QuantityPublishCode_Test()
        {
            var model = MockCategoryViewModel();

            model.Object.QuantityPublishCode = CategoryEntity.QuantityPublishCode;

            Assert.That(model.Object.QuantityPublishCode, Is.EqualTo(CategoryEntity.QuantityPublishCode));
        }

        #endregion
    }
}