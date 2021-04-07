using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySW.Model
{
    public class Value
    {
        public string Id { get; set; }

        public float OpenValue { get; set; }

        public float CloseValue { get; set; }

        public float LowValue { get; set; }

        public float HighValue { get; set; }

        public string Symbol { get; set; }

        public string Exchange { get; set; }

        public DateTime DateValue { get; set; }
    }
}
