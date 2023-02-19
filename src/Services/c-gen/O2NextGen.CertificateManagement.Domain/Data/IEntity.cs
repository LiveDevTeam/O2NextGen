namespace O2NextGen.CertificateManagement.Domain.Data;

public interface IEntity
{
    long Id { get; set; }
    string ExternalId { get; set; }
    long ModifiedDate { get; set; }
    long AddedDate { get; set; }
    long? DeletedDate { get; set; }
    bool? IsDeleted { get; set; }
}