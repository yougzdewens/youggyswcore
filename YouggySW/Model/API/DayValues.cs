using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySW.Model.API
{
    public class DayValues
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
}