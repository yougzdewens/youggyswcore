using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySW.Model
{
    public class ValueWatching
    {
        public int Id { get; set; }

        public string Exchange { get; set; }

        public string Symbol { get; set; }

        public string BuyOrSell { get; set; }

        public DateTime DateCreation { get; set; }
    }
}
