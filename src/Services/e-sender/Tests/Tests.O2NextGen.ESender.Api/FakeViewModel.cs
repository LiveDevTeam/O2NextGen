using O2NextGen.ESender.Api.Models;

namespace UnitTests.O2NextGen.ESender.Api
{
    public class FakeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public long? ModifiedDate { get; set; }
        public long? AddedDate { get; set; }
        public long? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}