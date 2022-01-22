using System.Collections.Generic;
using O2NextGen.ESender.Business.Models;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Impl.Mappings
{
    internal static class EmailRequestMappings 
    {
        public static EmailRequest ToService(this MailRequestEntity entity)
        {
            return entity != null ? new EmailRequest() {Id = entity.Id, From = entity.From, To = entity.To, Body = entity.Body,Subject = entity.Subject} : null;
        }
    
        public static MailRequestEntity ToEntity(this EmailRequest model)
        {
            return model != null ? new MailRequestEntity() {Id = model.Id, From = model.From, To = model.To, Body = model.Body,Subject = model.Subject} : null;
        }
    
        public static IReadOnlyCollection<EmailRequest>
            ToService(this IReadOnlyCollection<MailRequestEntity> entities) =>
            entities.MapCollection(ToService);
    }
}