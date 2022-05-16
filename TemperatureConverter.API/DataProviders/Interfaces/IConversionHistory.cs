using System.Collections.Generic;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public interface IConversionHistory
    {
        List<ConversionHistoryItem> GetAllConvertionHistory();
        void Create(ConversionHistoryItem conversionHistory);
    }
}
