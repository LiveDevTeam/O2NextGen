using System.Runtime.Serialization;

namespace O2NextGen.CertificateManagement.Application.Controllers.ViewModels.Base;

[DataContract]
public abstract class BaseViewModel : IViewModel
{
    [DataMember(Name = "id")] 
    public long? Id { get; set; }
    [DataMember(Name = "externalId")] 
    public string ExternalId { get; set; }
    [DataMember(Name = "modifiedDate")] 
    public long? ModifiedDate { get; set; }
    [DataMember(Name = "addedDate")] 
    public long? AddedDate { get; set; }
    [DataMember(Name = "deletedDate")] 
    public long? DeletedDate { get; set; }
    [DataMember(Name = "isDeleted")] 
    public bool? IsDeleted { get; set; }
}