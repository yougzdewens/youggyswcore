using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using YouggySW.Model;
using YouggySW.Model.API;

namespace YouggySW.BackOffice
{
    public class DayValuesBackOffice
    {
        public List<Value> GetDailyValues(string symbole, string exchange)
        {
            List<Value> values = new List<Value>();

            string responseJson = string.Empty;
            string url = @"http://api.marketstack.com/v1/eod?access_key=7c9be28ac9614e34f9278208dfb28f31&symbols=" + symbole + "&exchange=" + exchange;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseJson = reader.ReadToEnd();
            }

            DayValues dayValues = JsonConvert.DeserializeObject<DayValues>(responseJson);

            foreach (Datum datum in dayValues.Data)
            {
                Value value = new Value();
                value.CloseValue = float.Parse(datum.Close.ToString());
                value.OpenValue = float.Parse(datum.Open.ToString());
                value.LowValue = float.Parse(datum.Low.ToString());
                value.HighValue = float.Parse(datum.High.ToString());
                value.Exchange = datum.Exchange;
                value.Symbol = datum.Symbol;
                value.DateValue = datum.Date;

                values.Add(value);
            }

            return values;
        }
    }
}
