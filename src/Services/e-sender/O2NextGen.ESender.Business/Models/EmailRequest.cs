namespace O2NextGen.ESender.Business.Models
{
    public class EmailRequest
    {
        public long Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}