using FluentAssertions;
using Moq;
using O2NextGen.CertificateManagement.Application.Features.Categories;
using Xunit;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class CreateCategoryModelTests
{
    #region Tests of CategoryName Property

    [Fact]
    public void CreateCategoryModel_CheckPropertySetCategoryName_Test()
    {
        // Arrange
        var mock = new Mock<ICreateCategoryModel>();
        // Act
        mock.SetupProperty(m => m.CategoryName, "CategoryName");
        // Assert
        mock.Object.CategoryName.Should().Be("CategoryName");
    }

    #endregion

    #region Tests of CategoryDescription Property

    [Fact]
    public void CreateCategoryModel_CheckPropertySetCategoryDescription_Test()
    {
        // Arrange
        var mock = new Mock<ICreateCategoryModel>();
        // Act
        mock.SetupProperty(m => m.CategoryDescription, "CategoryDescription");
        // Assert
        mock.Object.CategoryDescription.Should().Be("CategoryDescription");
    }

    #endregion

    #region Tests of CategorySeries Property

    [Fact]
    public void CreateCategoryModel_CheckPropertySetCategorySeries_Test()
    {
        // Arrange
        var mock = new Mock<ICreateCategoryModel>();
        // Act
        mock.SetupProperty(m => m.CategorySeries, "CategorySeries");
        // Assert
        mock.Object.CategorySeries.Should().Be("CategorySeries");
    }

    #endregion
    
    #region Tests of CustomerId Property

    [Fact]
    public void CreateCategoryModel_CheckPropertySetCustomerId_Test()
    {
        // Arrange
        var mock = new Mock<ICreateCategoryModel>();
        // Act
        mock.SetupProperty(m => m.CustomerId, "CustomerId");
        // Assert
        mock.Object.CustomerId.Should().Be("CustomerId");
    }

    #endregion
}