using Common;
using System.Collections.Generic;

namespace Data
{
    public class RateData
    {
        public List<Rate> GetRates() {
            return CreateRates();
        } 

        private List<Rate> CreateRates() {
            var rateList = new List<Rate>();
            rateList.Add(CreateRate("EUR", "USD", (decimal)1.359));
            rateList.Add(CreateRate("CAD", "EUR", (decimal)0.732));
            rateList.Add(CreateRate("USD", "EUR", (decimal)0.736));
            rateList.Add(CreateRate("EUR", "CAD", (decimal)1.366));
            return rateList;
        }

        private Rate CreateRate(string from, string to, decimal rateNum) =>
            new Rate()
            {
                From = from,
                To = to,
                RateNum = rateNum
            };
        
    }
}
