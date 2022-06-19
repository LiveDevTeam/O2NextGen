namespace O2NextGen.Sdk.NetCore.Models.e_sender
{
    public interface IViewModel
    {
        long Id { get; set; }
        string ExternalId { get; set; }
        long? ModifiedDate { get; set; }
        long? AddedDate { get; set; }
        long? DeletedDate { get; set; }
        bool? IsDeleted { get; set; }
    }
}

