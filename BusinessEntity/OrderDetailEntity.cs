using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class OrderDetailEntity
    {
        public OrderDetailEntity()
        {
            new List<OrderDetailEntity>();
        }

        public List<ReserverOrderEntity> reserverOrderEntity { get; set; }
    }
    public class ReserverOrderEntity
    {
        public int ReserveId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ProcessorType { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int ProcessorId { get; set; }
        public int OrderQty { get; set; }
        public int OrderNo { get; set; }
        public string SCreatedDate { get; set; }

    }
}
