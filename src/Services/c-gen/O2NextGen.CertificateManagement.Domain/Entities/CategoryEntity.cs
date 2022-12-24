using O2NextGen.CertificateManagement.Domain.Data;

namespace O2NextGen.CertificateManagement.Domain.Entities
{
    public class CategoryEntity: IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}