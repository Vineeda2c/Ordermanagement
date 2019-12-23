using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Order_Management.Models
{
    public class MasterSerialNumberModel
    {

       



    }
    public class OrderDetailsModel
    {
        public int Orderid { get; set; }
        public int Order_qty { get; set; }

        public int Productid { get; set; }
        public string Order_Make { get; set; }
        public string Order_Model { get; set; }
        public string Order_Processor_Type { get; set; }
        public string Order_Processor_Speed { get; set; }
        public string Order_Ram { get; set; }
        public string Order_Hdd { get; set; }
        public string Order_Lcd { get; set; }
        public string Order_count { get; set; }
        public DateTime PurchasedDate { get; set; }


    }
    public class UserCommentsModel
    {
        public string  Username{ get; set; }
         public DateTime PurchasedDate { get; set; }
        public string Comments { get; set; }
        public string CommentCount { get; set; }
        public DateTime Comment_Date { get; set; }
        public int Userid { get; set; }
    }
}