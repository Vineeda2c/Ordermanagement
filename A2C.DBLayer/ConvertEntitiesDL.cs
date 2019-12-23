using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.DBLayer
{
    public class ConvertEntitiesDL
    {
      public DataTable ConvertNewSerialListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("ProcessorName");
            dt.Columns.Add("RevisedPurchasePrice");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                Order["MakeName"] = array.MakeName;
                Order["ModelName"] = array.ModelName;
                Order["ProcessorName"] = array.ProcessorName;
                Order["RevisedPurchasePrice"] = array.PurchasePrice;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertOkUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertPackageUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("CommonColumn");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["CommonColumn"] = array.Grade;

                dt.Rows.Add(Order);
            }

            return dt;
        }
        public DataTable ConvertSaleUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("SoldPrice");
            dt.Columns.Add("SoldDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["InvoiceNo"] = array.InvoiceNo;
                Order["SoldPrice"] = array.SoldPrice;
                Order["SoldDate"] = array.SoldDate;

                dt.Rows.Add(Order);
            }

            return dt;
        }
        public DataTable ConvertCommentUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("Comment");
           
            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["Comment"] = array.Comment;
               
                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertPurchaseUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("ProcessorName");
            dt.Columns.Add("PurchaseQty");
            dt.Columns.Add("PurchasePrice");
            dt.Columns.Add("PurchaseDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["MakeName"] = array.MakeName;
                Order["ModelName"] = array.ModelName;
                Order["ProcessorName"] = array.ProcessorName;
                Order["PurchaseQty"] = array.PurchaseQty;
                Order["PurchasePrice"] = array.PurchasePrice;
                Order["PurchaseDate"] = array.PurchaseDate;

                dt.Rows.Add(Order);
            }

            return dt;
        }


    }
}
