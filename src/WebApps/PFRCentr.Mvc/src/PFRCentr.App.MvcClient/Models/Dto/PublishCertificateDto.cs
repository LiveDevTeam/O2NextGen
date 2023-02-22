namespace PFRCentr.App.MvcClient.Models.Dto;

public class Catalog
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public List<PublishCertificateDto> Data { get; set; }
}
public class PublishCertificateDto
{
    public string OwnerAccountId { get; set; }
    public string CustomerId { get; set; }
    public long ExpiredDate { get; set; }
    public long PublishDate { get; set; }
    public string CreatorId { get; set; }
    public string PublishCode { get; set; }
    public bool IsVisible { get; set; }

    public long CategoryId { get; set; }
    public long Id { get; set; }
}