using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySW.Model.API
{
    public class Datum
    {
        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("adj_high")]
        public double? AdjHigh { get; set; }

        [JsonProperty("adj_low")]
        public double? AdjLow { get; set; }

        [JsonProperty("adj_close")]
        public double? AdjClose { get; set; }

        [JsonProperty("adj_open")]
        public double? AdjOpen { get; set; }

        [JsonProperty("adj_volume")]
        public double? AdjVolume { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
