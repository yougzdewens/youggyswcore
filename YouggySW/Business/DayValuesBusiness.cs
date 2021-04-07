using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySW.DAL;
using YouggySW.Model;

namespace YouggySW.Business
{
    public class DayValuesBusiness
    {
		private DayValuesDal dayValuesDal = new DayValuesDal();

        public void InsertDayValue(Value value)
        {
            dayValuesDal.InsertDayValue(value);
        }

        public DateTime? GetLastDateValueInserted(string exchange, string symbol)
        {
            DataTable table = dayValuesDal.GetLastDateValueInserted(exchange, symbol);

            foreach (DataRow dayValueRow in table.Rows)
            {
                return DateTime.Parse(dayValueRow["DateValue"].ToString());
            }

            return null;
        }

        public Value GetDayValue(string id)
        {
            throw new NotImplementedException();
        }

        public List<Value> GetDayValues(string exchange, string symbol, DateTime dateMax)
        {
            DataTable table = dayValuesDal.GetDayValues(exchange, symbol, dateMax);

            List<Value> values = new List<Value>();

            foreach (DataRow dayValueRow in table.Rows)
            {
                Value value = new Value();
                value.Id = dayValueRow["Id"].ToString();
                value.OpenValue = float.Parse(dayValueRow["OpenValue"].ToString());
                value.CloseValue = float.Parse(dayValueRow["CloseValue"].ToString());
                value.LowValue = float.Parse(dayValueRow["LowValue"].ToString());
                value.HighValue = float.Parse(dayValueRow["HighValue"].ToString());
                value.Symbol = dayValueRow["Symbol"].ToString();
                value.Exchange = dayValueRow["Exchange"].ToString();
                value.DateValue = DateTime.Parse(dayValueRow["DateValue"].ToString());

                values.Add(value);
            }

            return values;
        }

        public List<Value> GetAllDayValues()
        {
            throw new NotImplementedException();
        }
    }
}
