using System.Runtime.Serialization;

namespace O2.Tracker.DbUtility
{
    [DataContract]
    public sealed class GeoLocation
    {
        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public Point Point { get; set; }

        public override string ToString()
        {
            var lat = Format(nameof(Point.lat), Point?.lat);
            var lon = Format(nameof(Point.lon), Point?.lon);

            return $"Country={Country}, City={City}{lat}{lon}";
        }

        private static string Format(string name, double? value)
        {
            if (!value.HasValue)
                return null;

            var result = ", " + name + "=" + value.Value;
            return result;
        }
    }
}