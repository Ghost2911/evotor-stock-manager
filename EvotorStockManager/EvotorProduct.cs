using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvotorStockManager
{
    class EvotorProduct
    {
        public string uuid { get; set; }
        public bool? group { get; set; }
        public bool? hasVariant { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string[] barcodes { get; set; }
        public float? price { get; set; }
        public float? costPrice { get; set; }
        public float? quantity { get; set; }
        public string measureName { get; set; }
        public string tax { get; set; }
        public bool? allowToSell { get; set; }
        public string description { get; set; }
        public string articleNumber { get; set; }
        public string parentUuid { get; set; }
        public string[] alcoCodes { get; set; }
        public string alcoholByVolume { get; set; }
        public string alcoholProductKindCode { get; set; }
        public string tareVolume { get; set; }
        public string classificationCode { get; set; }

    }
}
