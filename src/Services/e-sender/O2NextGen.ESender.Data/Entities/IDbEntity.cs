namespace O2NextGen.ESender.Data.Entities
{
    public interface IDbEntity
    {
        long Id { get; set; }
        long AddedDate { get; set; }
        long ModifiedDate { get; set; }
        long DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}