﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using MaxMind.Db;
using O2NextGen.OnTracker.Api.Setup;
using O2NextGen.Tracker.DbUtility;

namespace O2NextGen.OnTracker.Api
{
    public sealed class MaxMindLocalGeoIpAddressResolver : IGeoIpAddressResolver
    {
        public MaxMindLocalGeoIpAddressResolver()
        {
            
        }
        private const string DefaultLang = "en";

        private const FileAccessMode AccessMode = FileAccessMode.Memory;

        // private static readonly ILog m_log = LogManager.GetLogger(typeof(MaxMindLocalGeoIpAddressResolver));

        private readonly Reader m_reader;

        public MaxMindLocalGeoIpAddressResolver(GeoDatabase setting)
        {
            // var path =  geoDbSetting;
            var path = Environment.CurrentDirectory + setting.ConnectionDb;//+ "/geoip/" + "GeoLite2-City.mmdb";
            if (string.IsNullOrWhiteSpace(path))
                throw new Exception("MaxMind local database path is not configured");

            m_reader = new Reader(path);
            // if (m_log.IsDebugEnabled)
            //     m_log.Debug($"{nameof(settings.MaxMindGeoIpDatabasePath)}='{path}'.");

            m_reader = new Reader(path, AccessMode);
        }

        public GeoLocation ResolveAddress(IPAddress ip)
        {
            var all = m_reader.FindAll<GeoLocationData>();
            var response = m_reader.Find<GeoLocationData>(ip);
            if (response == null)
                return null;

            var result = new GeoLocation
            {
                Country = response.Country?.Names[DefaultLang],
                City = response.City?.Names[DefaultLang]
            };
            var location = response.Location;
            if (location?.HasCoordinates == true)
                result.Point = new Point
                {
                    lat = location.Latitude.Value,
                    lon = location.Longitude.Value
                };

            return result;
        }

        private class NamedEntity
        {
            [Constructor]
            protected NamedEntity(
                IDictionary<string, string> names = null)
            {
                Names = names != null ? new Dictionary<string, string>(names) : new Dictionary<string, string>();
            }

            public IReadOnlyDictionary<string, string> Names { get; }
        }

        private sealed class Country : NamedEntity
        {
            [Constructor]
            public Country(
                IDictionary<string, string> names = null)
                : base(names)
            {
            }
        }

        private sealed class Location
        {
            [Constructor]
            public Location(
                double? latitude = null,
                double? longitude = null)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            public bool HasCoordinates => Latitude.HasValue && Longitude.HasValue;

            public double? Latitude { get; }

            public double? Longitude { get; }
        }

        private sealed class GeoLocationData
        {
            [Constructor]
            public GeoLocationData(
                Country country,
                NamedEntity city,
                Location location)
            {
                Country = country;
                City = city;
                Location = location;
            }

            public Country Country { get; }
            public NamedEntity City { get; }
            public Location Location { get; }
        }

        public void Dispose()
        {
            m_reader.Dispose();
        }
    }
}


