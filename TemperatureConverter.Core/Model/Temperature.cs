using TemperatureConverter.Core.Enum;
using System.Text.Json.Serialization;

namespace TemperatureConverter.Core.Model
{
    public class Temperature
    {
        public double TemperatureValue { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TemperatureScale Scale { get; set; }
    }
}
