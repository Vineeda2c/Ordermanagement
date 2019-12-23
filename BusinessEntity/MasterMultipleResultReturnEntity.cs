using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class MasterMultipleResultReturnEntity
    {
        public MasterMultipleResultReturnEntity()
        {
            new List<MasterMultipleResultReturnEntity>();
        }

        public List<MultipleResultReturnEntity> multipleResultReturnEntity { get; set; }
    }
    public class MultipleResultReturnEntity
    {
        public string InhouseSerialNo { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
    }

}
