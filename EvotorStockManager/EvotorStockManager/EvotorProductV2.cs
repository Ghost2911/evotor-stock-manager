using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvotorStockManager
{
    public class EvotorProductV2
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string[] barcodes { get; set; }
        public float? price { get; set; }
        public float? cost_price { get; set; }
        public float? quantity { get; set; }
        public string measure_name { get; set; }
        public string tax { get; set; }
        public bool? allow_to_sell { get; set; }
        public string description { get; set; }
        public string article_number { get; set; }
        public string parent_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public EvotorProductV2(string name, string code, string article, string description, float price, float cost_price, float quantity)
        {
            this.id = Guid.NewGuid().ToString();
            this.type = "NORMAL";
            this.tax = "NO_TAX";
            this.measure_name = "шт";
            this.allow_to_sell = true;
            this.name = name;
            this.code = code;
            this.article_number = article;
            this.description = description;
            this.price = price;
            this.cost_price = cost_price;
            this.quantity = quantity;
        }

    }
}
