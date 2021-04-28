using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouggySWLib.BackOffice;
using YouggySWLib.Business;
using YouggySWLib.Model;
using YouggySWLib.Model.API;

namespace YouggySW.Core
{
    public class GetStockDataCore
    {
        const int limitationForAPage = 1000;

        private List<ValueWatching> valuesWatching = null;

        private ExchangeBackOfficeMarketStack exchangeBackOfficeMarketStack = new ExchangeBackOfficeMarketStack(limitationForAPage);

        private DayValuesBusiness dayValuesBusiness = new DayValuesBusiness();

        public void StartGetData()
        {
            List<ValueWatching> valuesWatched = GetValuesWatching();

            foreach (ValueWatching valueWatched in valuesWatched)
            {
                DateTime? lastDate = dayValuesBusiness.GetLastDateValueInserted(valueWatched.IdSymbol);

                if (!lastDate.HasValue || lastDate.Value.Date < DateTime.Now.Date)
                {
                    if (DateTime.Now.Date.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.Date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        GetDailyDataAndInsertForWatchedValues(valueWatched, lastDate);
                    }
                }
            }

            //FillSymbols(0);
        }

        private void GetDailyDataAndInsertForWatchedValues(ValueWatching valueWatched, DateTime? lastDate)
        {
            YouggySWLib.Model.Symbol symbol = new SymbolBusiness().GetSymbolById(valueWatched.IdSymbol).FirstOrDefault();

            YouggySWLib.Model.Exchange exchange = new ExchangeBusiness().GetExchangeById(symbol.IdExchange);

            if (symbol != null)
            {
                List<Value> valuesForStock = exchangeBackOfficeMarketStack.GetDailyValues(symbol.SymbolText, exchange.Mic);

                if (lastDate.HasValue)
                {
                    valuesForStock = valuesForStock.Where(x => x.DateValue.Date > lastDate.Value.Date).ToList();
                }

                foreach (Value valueForStock in valuesForStock)
                {
                    dayValuesBusiness.InsertDayValue(valueForStock);
                }
            }
        }


        private void FillSymbols(int numberOfpage)
        {
            Tickers tickers = exchangeBackOfficeMarketStack.GetSymbolsInformation(numberOfpage);

            double nbPage = (int)Math.Ceiling((decimal)tickers.Pagination.Total / limitationForAPage);

            SymbolBusiness symbolBusiness = new SymbolBusiness();
            ExchangeBusiness exchangeBusiness = new ExchangeBusiness();

            foreach (YouggySWLib.Model.API.Symbol data in tickers.Data)
            {
                YouggySWLib.Model.Exchange exchangeModel = exchangeBusiness.GetExchange(data.StockExchange.Mic);
                int idExchange = -1;

                if (exchangeModel == null)
                {
                    idExchange = exchangeBusiness.InsertExchange(new Exchange()
                    {
                        Acronym = data.StockExchange.Acronym,
                        City = data.StockExchange.City,
                        Country = data.StockExchange.Country,
                        Country_Code = data.StockExchange.CountryCode,
                        Mic = data.StockExchange.Mic,
                        Name = data.StockExchange.Name,
                        Website = data.StockExchange.Website
                    });
                }
                else
                {
                    idExchange = exchangeModel.IdExchange;
                }

                YouggySWLib.Model.Symbol symbol = symbolBusiness.GetSymbol(data.StockExchange.Mic, data.SymbolText).FirstOrDefault();

                if (symbol == null)
                {
                    symbolBusiness.InsertSymbol(new YouggySWLib.Model.Symbol()
                    {
                        Has_EodMSack = data.HasEod,
                        Has_IntradayMSack = data.HasIntraday,
                        IdExchange = idExchange,
                        Name = data.Name,
                        SymbolText = data.SymbolText
                    });
                }
            }

            if (numberOfpage == 0)
            {
                for (int i = 1; i <= nbPage; i++)
                {
                    FillSymbols(i);
                }
            }
        }

        private List<ValueWatching> GetValuesWatching()
        {
            if (this.valuesWatching == null)
            {
                ValueWatchingBusiness valueWatchingBusiness = new ValueWatchingBusiness();
                this.valuesWatching = valueWatchingBusiness.GetAllValueWatchings();
            }

            return this.valuesWatching;
        }
    }
}
