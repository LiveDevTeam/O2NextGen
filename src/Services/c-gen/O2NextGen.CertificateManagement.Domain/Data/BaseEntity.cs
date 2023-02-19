namespace O2NextGen.CertificateManagement.Domain.Data;

public class BaseEntity : IEntity
{
    public long Id { get; set; }
    public string ExternalId { get; set; }
    public long ModifiedDate { get; set; }
    public long AddedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }
}