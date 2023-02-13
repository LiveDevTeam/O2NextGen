namespace O2NextGen.CertificateManagement.Domain.Entities;

public class LanguageInfo
{
    public long Id { get; set; }
    public long ModifiedDate { get; set; }
    public long AddedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }

    public long CertificateId { get; set; }
    public int LanguageId { get; set; }
    public Certificate Certificate { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
}