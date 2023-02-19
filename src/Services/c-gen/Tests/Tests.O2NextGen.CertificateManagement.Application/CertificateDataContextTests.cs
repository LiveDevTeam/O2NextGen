using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class CertificateDataContextTests
{
    [Test]
    public void CertificateDataContextTests_Implement()
    {
        Assert.IsTrue(typeof(ICertificateDataContext).IsAssignableFrom(typeof(CGenDbContext)));
    }

    [Test]
    public void CertificateDataContextTests_Props_Certificates_Test()
    {
        var mock = new Mock<ICertificateDataContext>();
        mock.SetupProperty(p => p.Certificates);
        var obj = mock.Object;
        obj.Certificates = It.IsAny<DbSet<CertificateEntity>>();
        Assert.That(obj.Certificates, Is.EqualTo(It.IsAny<DbSet<CertificateEntity>>()));
    }

    [Test]
    public void CertificateDataContextTests_Props_Categories_Test()
    {
        var mock = new Mock<ICertificateDataContext>();
        mock.SetupProperty(p => p.Categories);
        var obj = mock.Object;
        obj.Categories = It.IsAny<DbSet<CategoryEntity>>();
        Assert.That(obj.Categories, Is.EqualTo(It.IsAny<DbSet<CategoryEntity>>()));
    }

    // [Test]
    // public void CertificateDataContextTests_Props_CertificateManagementHistories_Test()
    // {
    //     var mock = new Mock<ICertificateDataContext>();
    //     mock.SetupProperty(p => p.CertificateManagementHistories);
    //     var obj = mock.Object;
    //     obj.CertificateManagementHistories = It.IsAny<DbSet<CertificateManagementHistoryDbEntity>>();
    //     Assert.That(obj.CertificateManagementHistories,
    //         Is.EqualTo(It.IsAny<DbSet<CertificateManagementHistoryDbEntity>>()));
    // }
    //
    // [Test]
    // public void CertificateDataContextTests_Props_LanguageInfos_Test()
    // {
    //     var mock = new Mock<ICertificateDataContext>();
    //     mock.SetupProperty(p => p.LanguageInfos);
    //     var obj = mock.Object;
    //     obj.LanguageInfos = It.IsAny<DbSet<LanguageInfoDbEntity>>();
    //     Assert.That(obj.LanguageInfos, Is.EqualTo(It.IsAny<DbSet<LanguageInfoDbEntity>>()));
    // }
}