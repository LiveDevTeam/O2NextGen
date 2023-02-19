using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Entities;

namespace O2NextGen.CertificateManagement.Infrastructure.Data;

public interface ICertificateDataContext : IDataContext
{
    //DbSet<LanguageInfoDbEntity> LanguageInfos { get; set; }
    DbSet<CertificateEntity> Certificates { get; set; }

    DbSet<CategoryEntity> Categories { get; set; }
    //DbSet<CertificateManagementHistoryDbEntity>  CertificateManagementHistories { get; set; }
}