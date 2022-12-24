using System.Collections.Generic;
using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Data.Entities;

namespace O2NextGen.CertificateManagement.Impl.Mappings
{
    internal static class CategoryMappings
    {
        public static Category ToService(this CategoryEntity entity)
        {
            return entity != null ? new Category() { Id = entity.Id, Name = entity.Name } : null;
        }

        public static CategoryEntity ToEntity(this Category model)
        {
            return model != null ? new CategoryEntity() { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<Category>
            ToService(this IReadOnlyCollection<CategoryEntity> entities) =>
            entities.MapCollection(ToService);
    }
}