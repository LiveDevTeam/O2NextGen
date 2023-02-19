namespace O2NextGen.Sdk.NetCore.Models.ESender;

public class EmailRequestViewModel : IViewModel
{
    public string From { get; set; }
    public string To { get; set; }
    public string Body { get; set; }
    public string Subject { get; set; }
    public long Id { get; set; }
    public string ExternalId { get; set; }
    public long? ModifiedDate { get; set; }
    public long? AddedDate { get; set; }
    public long? DeletedDate { get; set; }
    public bool? IsDeleted { get; set; }
}