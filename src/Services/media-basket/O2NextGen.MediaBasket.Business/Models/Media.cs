using System;

namespace O2NextGen.MediaBasket.Business.Models
{
    public class Media
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string PublicId { get; set; }
        public string AccountId { get; set; }
        public string ContentType { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ExtType { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }
    }
}