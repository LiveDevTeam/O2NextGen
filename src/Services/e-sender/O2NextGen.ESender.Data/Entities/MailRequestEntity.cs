namespace O2NextGen.ESender.Data.Entities
{
    public class MailRequestEntity
    {
        public long Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}