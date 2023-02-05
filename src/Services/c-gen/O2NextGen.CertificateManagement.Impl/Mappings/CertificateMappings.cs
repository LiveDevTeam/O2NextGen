using O2NextGen.CertificateManagement.Business.Models;
using O2NextGen.CertificateManagement.Data.Entities;
using System.Collections.Generic;

namespace O2NextGen.CertificateManagement.Impl.Mappings
{
    internal static class CertificateMappings
    {
        public static Certificate ToService(this CertificateEntity entity)
        {
            return entity != null ? new Certificate() { Id = entity.Id, Name = entity.Name } : null;
        }

        public static CertificateEntity ToEntity(this Certificate model)
        {
            return model != null ? new CertificateEntity() { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<Certificate>
            ToService(this IReadOnlyCollection<CertificateEntity> entities) =>
            entities.MapCollection(ToService);
    }
}