using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvotorStockManager
{
    class RootItemsJSON
    {
        public List<EvotorProductV2> items { get; set; }
        public RootCursor paging { get; set; }
    }
}
