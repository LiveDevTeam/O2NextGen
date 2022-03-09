namespace O2NextGen.ESender.Data.Entities
{
    public class EmailRequestDbEntity: IDbEntity
    {
        public long Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long ModifiedDate { get; set; }
        public long DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long AddedDate { get; set; }
    }
}