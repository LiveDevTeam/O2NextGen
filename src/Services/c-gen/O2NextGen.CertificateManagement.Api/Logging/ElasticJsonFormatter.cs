using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Json;
using System.IO;

namespace O2NextGen.CertificateManagement.Api.Logging
{
    public class ElasticJsonFormatter : ITextFormatter
    {
        private const string Prefix = "[ELASTIC]";

        private readonly NamingStrategy namingStrategy;
        private readonly JsonValueFormatter formatter;
        private readonly string type;

        public ElasticJsonFormatter(NamingStrategy namingStrategy, JsonValueFormatter formatter, string type)
        {
            this.namingStrategy = namingStrategy;
            this.formatter = formatter;
            this.type = type;
        }

        public ElasticJsonFormatter()
            : this(new CamelCaseNamingStrategy(), new JsonValueFormatter("$type"), "o2nextgen")
        {
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            output.Write(Prefix);
            FormatBody(logEvent, output);
            output.WriteLine();
        }

        private void FormatBody(LogEvent logEvent, TextWriter output)
        {
            // add json body
            var writer = new JsonTextWriter(output);
            writer.WriteStartObject();

            // write level
            writer.WritePropertyName("level");
            writer.WriteValue(FormatLogLevel(logEvent.Level));

            // write type
            writer.WritePropertyName("type");
            writer.WriteValue(type);

            // write timestamp
            writer.WritePropertyName("timestamp");
            writer.WriteValue(logEvent.Timestamp.UtcDateTime);

            // write message
            writer.WritePropertyName("message");
            writer.WriteValue(logEvent.RenderMessage());

            // write exception if exists
            if (logEvent.Exception != null)
            {
                writer.WritePropertyName("exception");
                writer.WriteValue(logEvent.Exception.ToString());
            }

            // write properties
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            foreach (var property in logEvent.Properties)
            {
                var propertyName = namingStrategy.GetPropertyName(property.Key, false);
                writer.WritePropertyName(propertyName);

                using (var stringWriter = new StringWriter())
                {
                    formatter.Format(property.Value, stringWriter);
                    writer.WriteRawValue(stringWriter.ToString());
                }
            }

            writer.WriteEndObject();
            writer.Flush();
        }

        private static string FormatLogLevel(LogEventLevel level)
        {
            switch (level)
            {
                case LogEventLevel.Verbose:
                    return "TRACE";
                case LogEventLevel.Debug:
                    return "DEBUG";
                case LogEventLevel.Warning:
                    return "WARNING";
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    return "ERROR";
                default:
                    return "INFO";
            }
        }
    }
}