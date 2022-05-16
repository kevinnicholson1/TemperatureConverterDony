using System.Text.Json.Serialization;
using TemperatureConverter.Core.Enum;

namespace TemperatureConverter.Core.Model
{
    public class ConversionHistoryItem
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TemperatureScale ConvertFromScale { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TemperatureScale ConvertToScale { get; set; }
        public double Temperature { get; set; }
    }
}
