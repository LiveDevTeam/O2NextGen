namespace O2NextGen.ESender.Business.Models
{
    public class EmailRequestModel: IBaseModel
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long AddedDate { get; set; }
        public long DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long ModifiedDate { get; set; }
    }
}