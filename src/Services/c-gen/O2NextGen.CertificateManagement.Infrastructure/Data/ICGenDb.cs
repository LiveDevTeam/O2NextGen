using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data;

public interface ICertificateDataContext : IDataContext
{
    //DbSet<LanguageInfoDbEntity> LanguageInfos { get; set; }
    DbSet<Certificate> Certificates { get; set; }

    DbSet<Category> Categories { get; set; }
    //DbSet<CertificateManagementHistoryDbEntity>  CertificateManagementHistories { get; set; }
}