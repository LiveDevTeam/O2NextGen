using O2NextGen.CertificateManagement.Domain.Data;

namespace O2NextGen.CertificateManagement.Domain.Entities;

public class LanguageInfoEntity: BaseEntity
{
    public long CertificateId { get; set; }
    public int LanguageId { get; set; }
    public CertificateEntity CertificateEntity { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string MiddleName { get; set; }
}