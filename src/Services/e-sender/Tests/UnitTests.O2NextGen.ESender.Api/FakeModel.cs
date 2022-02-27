using System;
using O2NextGen.ESender.Business.Models;

namespace UnitTests.O2NextGen.ESender.Api
{
    public class FakeModel : IBaseModel
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public long ModifiedDate { get; set; }
        public long AddedDate { get; set; }
        public long DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        public void CreateEntity()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity()
        {
            throw new NotImplementedException();
        }
    }
}