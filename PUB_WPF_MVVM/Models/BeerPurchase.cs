using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUB_WPF_MVVM.Models
{
    public class BeerPurchase
    {
        public string BeerName { get; set; }
        public string BeerPath { get; set; }
        public double BeerVolume { get; set; }
        public string OrderCount { get; set; }
        public string total_price { get; set; }
        public DateTime Date { get; set; }

    }
}
