using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySW.Model;

namespace YouggySW.DAL
{
    public class DayValuesDal
    {
        /// <summary>
		/// The database manager
		/// </summary>
		private DatabaseSQLServerManagerTools dbManager = new DatabaseSQLServerManagerTools();

        public void InsertDayValue(Value value)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Id", string.Concat(new string[] { value.Exchange, value.Symbol, value.DateValue.ToString() }));
            parameters.Add("OpenValue", value.OpenValue);
            parameters.Add("CloseValue", value.CloseValue);
            parameters.Add("LowValue", value.LowValue);
            parameters.Add("HighValue", value.HighValue);
            parameters.Add("Symbol", value.Symbol);
            parameters.Add("Exchange", value.Exchange);
            parameters.Add("DateValue", value.DateValue);

            dbManager.InsertStoredProcedure("usp_Day_ValuesInsert", parameters);
        }

        public DataTable GetDayValue(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetLastDateValueInserted(string exchange, string symbol)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Exchange", exchange);
            parameters.Add("Symbol", symbol);

            return dbManager.SelectStoredProcedure("usp_Last_Day_ValuesSelect", parameters);
        }

        public DataTable GetDayValues(string exchange, string symbol, DateTime dateMax)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Exchange", exchange);
            parameters.Add("Symbol", symbol);
            parameters.Add("DateMax", dateMax);

            return dbManager.SelectStoredProcedure("usp_Day_ValuesSelection", parameters);
        }

        public List<Value> GetAllDayValues()
        {
            throw new NotImplementedException();
        }
    }
}
