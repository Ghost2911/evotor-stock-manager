using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvotorStockManager
{
    class StatusTask
    {
        public string id { get; set; }
        public string modified_at { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string[] details { get; set; }
    }
}
