using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySW.DAL;
using YouggySW.Model;

namespace YouggySW.Business
{
    public class ValueWatchingBusiness
    {
        private ValueWatchingDal valueWatchingDal = new ValueWatchingDal();

        public void Insert(ValueWatching valueWatching)
        {
            valueWatchingDal.Insert(valueWatching);
        }

        public List<ValueWatching> GetAllValueWatchings()
        {
            DataTable getAllValueWatchings = valueWatchingDal.GetAllValueWatchings();

            List<ValueWatching> valuesWatching = new List<ValueWatching>();

            foreach (DataRow valueWatchingRow in getAllValueWatchings.Rows)
            {
                ValueWatching valueWatching = new ValueWatching();
                valueWatching.Id = int.Parse(valueWatchingRow["Id"].ToString());
                valueWatching.Exchange = valueWatchingRow["Exchange"].ToString();
                valueWatching.Symbol = valueWatchingRow["Symbol"].ToString();
                valueWatching.BuyOrSell = valueWatchingRow["BuyOrSell"].ToString();
                valueWatching.DateCreation = DateTime.Parse(valueWatchingRow["DateCreation"].ToString());

                valuesWatching.Add(valueWatching);
            }

            return valuesWatching;
        }

        public ValueWatching GetValueWatching(int id)
        {
            throw new NotImplementedException();
        }
    }
}
