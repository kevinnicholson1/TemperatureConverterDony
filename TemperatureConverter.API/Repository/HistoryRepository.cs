using System.Collections.Generic;
using TemperatureConverter.API.DataProviders;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IConversionHistory _temperatureHistory;

        public HistoryRepository(IConversionHistory temperatureHistory)
        {
            _temperatureHistory = temperatureHistory;
        }

        public List<ConversionHistoryItem> GetAllConvertionHistory()
        {
            return _temperatureHistory.GetAllConvertionHistory(); 
        }

    }
}
