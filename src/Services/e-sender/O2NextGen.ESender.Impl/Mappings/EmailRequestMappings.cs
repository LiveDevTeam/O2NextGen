using System.Collections.Generic;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Impl.Mappings
{
    public static class EmailRequestMappings 
    {
        private static readonly
            BaseMappings<EmailRequestDbEntity, EmailRequestModel> BaseMappings;
        
        static EmailRequestMappings()
        {
            BaseMappings =
                new BaseMappings<EmailRequestDbEntity, EmailRequestModel>();
            
        }
        public static EmailRequestModel ToModel(this EmailRequestDbEntity dbEntity)
        {
            return dbEntity != null ? new EmailRequestModel()
            {
                Id = dbEntity.Id, From = dbEntity.From, To = dbEntity.To, Body = dbEntity.Body,Subject = dbEntity.Subject
            } : null;
        }
    
        public static EmailRequestDbEntity ToEntity(this EmailRequestModel model)
        {
            return model != null ? new EmailRequestDbEntity()
            {
                Id = model.Id, From = model.From, To = model.To, Body = model.Body,Subject = model.Subject
            } : null;
        }
    
        public static IReadOnlyCollection<EmailRequestModel>
            ToModel(this IReadOnlyCollection<EmailRequestDbEntity> entities) =>
            entities.MapCollection(ToModel);
    }
}