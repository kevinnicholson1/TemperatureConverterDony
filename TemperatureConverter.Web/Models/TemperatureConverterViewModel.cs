using TemperatureConverter.Core.Enum;

namespace TemperatureConverter.Web.Models
{
    public class TemperatureConverterViewModel
    {
        public TemperatureScale ConvertFromScale { get; set; }
        public TemperatureScale ConvertToScale { get; set; }
        public double ConvertFromTemperature { get; set; }
        public double ConvertToTemperature { get; set; }
    }
}
