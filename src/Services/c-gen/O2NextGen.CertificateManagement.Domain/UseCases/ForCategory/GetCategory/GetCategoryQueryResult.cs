namespace O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory
{

    public class GetCategoryQueryResult
    {
        public GetCategoryQueryResult(long id, long modifiedDate, long addedDate, long? deletedDate, bool? isDeleted,
            string customerId)
        {
            Id = id;
            ModifiedDate = modifiedDate;
            AddedDate = addedDate;
            DeletedDate = deletedDate;
            IsDeleted = isDeleted;
            CustomerId = customerId;
        }

        public long Id { get; }
        public long ModifiedDate { get; }
        public long AddedDate { get; }
        public long? DeletedDate { get; }
        public bool? IsDeleted { get; }
        public string CustomerId { get; }
    }
}
