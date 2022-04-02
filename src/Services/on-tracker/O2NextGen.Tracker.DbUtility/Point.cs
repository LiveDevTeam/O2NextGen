using System.Runtime.Serialization;

namespace O2NextGen.Tracker.DbUtility
{
    [DataContract]
    public sealed class Point
    {
        [DataMember]
        public double lat { get; set; }

        [DataMember]
        public double lon { get; set; }
    }
}