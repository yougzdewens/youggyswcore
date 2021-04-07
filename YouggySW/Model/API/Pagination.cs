using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySW.Model.API
{
    public class Pagination
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
