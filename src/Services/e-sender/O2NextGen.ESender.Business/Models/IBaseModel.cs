namespace O2NextGen.ESender.Business.Models
{
    public interface IBaseModel
    {
        long Id { get;  set; }
        string ExternalId { get; set; }
        long ModifiedDate { get; set; }
        long AddedDate { get; set; }
        long DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}