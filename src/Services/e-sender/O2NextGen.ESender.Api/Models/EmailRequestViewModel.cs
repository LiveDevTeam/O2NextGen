namespace O2NextGen.ESender.Api.Models
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
    public class EmailRequestViewModel: IViewModel
    {
        public long Id { get;  set; }
        public string ExternalId { get; set; }
        public long? ModifiedDate { get; set; }
        public long? AddedDate { get; set; }
        public long? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string From { get;  set; }
        public string To { get;  set; }
        public string Body { get;  set; }
        public string Subject { get;  set; }
    }
}

