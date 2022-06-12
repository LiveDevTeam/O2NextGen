using System.Collections.Generic;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Data.Entities;

namespace O2NextGen.MediaBasket.Impl.Mappings
{
    internal static class MediaMappings
    {
        public static Media ToService(this MediaEntity entity)
        {
            return entity != null ? new Media()
            {
                Id = entity.Id, 
                Name = entity.Name,
                OriginalName = entity.OriginalName
            } : null;
        }

        public static MediaEntity ToEntity(this Media model)
        {
            return model != null ? new MediaEntity()
            {
                Id = model.Id,
                Name = model.Name,
                OriginalName = model.OriginalName
            } : null;
        }

        public static IReadOnlyCollection<Media>
            ToService(this IReadOnlyCollection<MediaEntity> entities) =>
            entities.MapCollection(ToService);
    }
}