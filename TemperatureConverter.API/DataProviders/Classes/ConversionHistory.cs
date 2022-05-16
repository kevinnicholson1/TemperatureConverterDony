using System.Collections.Generic;
using TemperatureConverter.Core.Model;

namespace TemperatureConverter.API.DataProviders
{
    public class ConversionHistory : IConversionHistory
    {
        private List<ConversionHistoryItem> _conversionHistory;

        public ConversionHistory()
        {
            _conversionHistory = new List<ConversionHistoryItem>();
        }
        public void Create(ConversionHistoryItem conversionHistoryItem)
        {
            _conversionHistory.Add(conversionHistoryItem);
        }

        public List<ConversionHistoryItem> GetAllConvertionHistory()
        {
            return _conversionHistory;
        }
    }
}
