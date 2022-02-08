using System;
namespace O2NextGen.ESender.Api.Models
{
    public class MailRequestViewModel
    {
        public long Id { get;  set; }
        public string From { get;  set; }
        public string To { get;  set; }
        public string Body { get;  set; }
        public string Subject { get;  set; }
    }
}

