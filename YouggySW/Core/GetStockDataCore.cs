using System;
using System.Collections.Generic;
using System.Text;
using YouggySW.BackOffice;
using YouggySW.Business;
using YouggySW.Model;

namespace YouggySW.Core
{
    public class GetStockDataCore
    {
        private List<ValueWatching> valuesWatching = null;

        private DayValuesBackOffice dayValuesBackOffice = new DayValuesBackOffice();

        private DayValuesBusiness dayValuesBusiness = new DayValuesBusiness();

        public void StartGetData()
        {
            List<ValueWatching> valuesWatched = GetValuesWatching();
            
            foreach (ValueWatching valueWatched in valuesWatched)
            {
                // Récupération de la dernière date insérée
                DateTime? lastDate = dayValuesBusiness.GetLastDateValueInserted(valueWatched.Exchange, valueWatched.Symbol);

                if (!lastDate.HasValue || lastDate.Value.Date < DateTime.Now.Date)
                {
                    if (DateTime.Now.Date.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.Date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        GetDailyDataAndInsertForWatchedValues(valueWatched);
                    }
                }
            } 
        }

        private void GetDailyDataAndInsertForWatchedValues(ValueWatching valueWatched)
        {       
            List<Value> valuesForStock = dayValuesBackOffice.GetDailyValues(valueWatched.Symbol, valueWatched.Exchange);

            // TODO FILTRER pour n'inserer que ce qui nous interesse par rapport au dernier inséré
            foreach (Value valueForStock in valuesForStock)
            {
                dayValuesBusiness.InsertDayValue(valueForStock);
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
