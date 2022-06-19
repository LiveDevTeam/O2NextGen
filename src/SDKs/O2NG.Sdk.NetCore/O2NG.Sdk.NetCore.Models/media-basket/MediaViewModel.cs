using System;
using Microsoft.AspNetCore.Http;

namespace O2NextGen.Sdk.NetCore.Models.media_basket
{
    public class MediaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public string PublicId { get; set; }
        public string AccountId { get; set; }
        public IFormFile File { get; set; }
        public string PreviewUrl { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string ExtType { get; set; }
        public string ContentType { get; set; }
        public string MediaType { get; set; }
        public string OriginalName { get; set; }
    }
}
