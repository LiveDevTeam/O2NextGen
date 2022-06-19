using System;
using System.Collections.Generic;
using O2NextGen.MediaBasket.Business.Models;
using O2NextGen.MediaBasket.Data.Entities;

namespace O2NextGen.MediaBasket.Impl.Mappings
{
    internal static class MediaMappings
    {
        public static Media ToService(this MediaEntity entity)
        {
            return entity != null
                ? new Media()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    OriginalName = entity.OriginalName,
                    PublicId = entity.PublicId,
                    AccountId = entity.AccountId,
                    ContentType = entity.ContentType,
                    DateAdded = entity.DateAdded ?? DateTime.Now,
                    Description = entity.Description,
                    Width = entity.Width,
                    Height = entity.Height,
                    ExtType = entity.ExtType,
                    MediaType = entity.MediaType,
                    Url = entity.Url,
                }
                : null;
        }

        public static MediaEntity ToEntity(this Media model)
        {
            return model != null
                ? new MediaEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    OriginalName = model.OriginalName,
                    PublicId = model.PublicId,
                    AccountId = model.AccountId,
                    ContentType = model.ContentType,
                    DateAdded = model.DateAdded,
                    Description = model.Description,
                    Width = model.Width,
                    Height = model.Height,
                    ExtType = model.ExtType,
                    MediaType = model.MediaType,
                    Url = model.Url,
                }
                : null;
        }

        public static IReadOnlyCollection<Media>
            ToService(this IReadOnlyCollection<MediaEntity> entities) =>
            entities.MapCollection(ToService);
    }
}