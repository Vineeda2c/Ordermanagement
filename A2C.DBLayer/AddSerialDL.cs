using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.DBLayer
{
    public class AddSerialDL
    {
        string cs = ConfigurationManager.ConnectionStrings["A2CConnectionString"].ToString();
        public List<SerialNumberEnity> InsertReceiptStock(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();
            ConvertEntitiesDL entityObj = new ConvertEntitiesDL();

            DataTable table = entityObj.ConvertNewSerialListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertSerialNumber", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
       
        public List<InitialTestingUploadEnity> InsertInitialTestingStock(List<InitialTestingUploadEnity> entity)
        {
            // int i = 0;
            InitialTestingUploadEnity serialentity;
            List<InitialTestingUploadEnity> serialentityList = new List<InitialTestingUploadEnity>();

            DataTable table = ConvertIntialTestingListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertInitialTestingData", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InitialTestingUploadEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();
                            serialentity.Category = dr["Type"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        static DataTable ConvertIntialTestingListToDataTable(List<InitialTestingUploadEnity> list)
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
            dt.Columns.Add("ProcessorType");
            dt.Columns.Add("ProcessorGen");
            dt.Columns.Add("ProcessorNo");
            dt.Columns.Add("ProcessorSpeed");
            dt.Columns.Add("RAM");
            dt.Columns.Add("HDD");
            dt.Columns.Add("KeyboardLan");
            dt.Columns.Add("OSSticker");
            dt.Columns.Add("Webcam");
            dt.Columns.Add("Optical");
            dt.Columns.Add("GraphicsName");
            dt.Columns.Add("GraphicsMemory");
            dt.Columns.Add("Resolution");
            dt.Columns.Add("DisplaySize");
            dt.Columns.Add("ScreenType");
            dt.Columns.Add("Acadapter");
            dt.Columns.Add("SupplierName");
            dt.Columns.Add("FingerPrintSecurity");
            dt.Columns.Add("MadeIn");
            dt.Columns.Add("Battery");
            dt.Columns.Add("Wifi");
            dt.Columns.Add("MouseTrack");
            dt.Columns.Add("PurchasePrice");
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
                Order["ProcessorType"] = array.ProcessorType;
                Order["ProcessorGen"] = array.ProcessorGen;
                Order["ProcessorNo"] = array.ProcessorNo;
                Order["ProcessorSpeed"] = array.ProcessorSpeed;
                Order["RAM"] = array.RAM;
                Order["HDD"] = array.HDD;
                Order["KeyboardLan"] = array.KeyboardLan;
                Order["OSSticker"] = array.OSSticker;
                Order["Webcam"] = array.Webcam;
                Order["Optical"] = array.Optical;
                Order["GraphicsName"] = array.GraphicsName;
                Order["GraphicsMemory"] = array.GraphicsMemory;
                Order["Resolution"] = array.Resolution;
                Order["DisplaySize"] = array.DisplaySize;
                Order["ScreenType"] = array.ScreenType;
                Order["Acadapter"] = array.Acadapter;
                Order["SupplierName"] = array.SupplierName;
                Order["FingerPrintSecurity"] = array.FingerPrintSecurity;
                Order["MadeIn"] = array.MadeIn;
                Order["Battery"] = array.Battery;
                Order["Wifi"] = array.Wifi;
                Order["MouseTrack"] = array.MouseTrack;
                Order["PurchasePrice"] = array.PurchasePrice;

                dt.Rows.Add(Order);
            }

            return dt;
        }


        public List<SerialNumberEnity> ProductionUploadStock(List<SerialNumberEnity> entity,string NewFileName)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertProductionUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spProductionUploadSerialNumber", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter FileName = cmd.Parameters.AddWithValue("@FileName", NewFileName);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        static DataTable ConvertProductionUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("BatchNo");
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
                Order["BatchNo"] = array.BatchNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public List<SerialNumberEnity> ProductionReceivedStock(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertProductionUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spProductionReceivedSerialNumber", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<SerialNumberEnity> ScrapPendingUploadStock(List<SerialNumberEnity> entity,int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertProductionUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spScrapPenidngUploadSerialNumber", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> OkStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();
            ConvertEntitiesDL objEnt = new ConvertEntitiesDL();

            DataTable table = objEnt.ConvertOkUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spOkUploadStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<SerialNumberEnity> PackagingStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();
            ConvertEntitiesDL objEnt = new ConvertEntitiesDL();

            DataTable table = objEnt.ConvertPackageUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("[spPackagingUploadStock]", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

      


        public List<SerialNumberEnity> SoldStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            ConvertEntitiesDL obj = new ConvertEntitiesDL();

            DataTable table = obj.ConvertSaleUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spSoldStockUpload", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<SerialNumberEnity> NewOrderCommentUpdate(List<SerialNumberEnity> entity, int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();
            ConvertEntitiesDL obj = new ConvertEntitiesDL();

            DataTable table = obj.ConvertCommentUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("[spUpdateCommentNewOrderUpload]", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            //serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        

        #region PurchaseOrder
        public List<SerialNumberEnity> GetPurchaseDetail()
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetPurchaseOrder", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.PurchaseQty = Convert.ToInt32(dr["Qty"]);
                            serialentity.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Type = Convert.ToInt32(dr["Type"]);
                            


                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public int AddNewOrder(List<OrderEntity> entity)
        {
            // int i = 0;

            DataTable table = ConvertOrderDetailsListToDataTable(entity);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spInsertNewOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter customrId = cmd.Parameters.AddWithValue("@tblOrd", table);
               // cmd.Parameters.AddWithValue("@Oreder_no",entity.Orderid);
               //cmd.Parameters.AddWithValue("@QTY", entity.Order_qty);
               //cmd.Parameters.AddWithValue("@O_Make", entity.Order_Make);
               //cmd.Parameters.AddWithValue("@O_Model", entity.Order_Model);
               //cmd.Parameters.AddWithValue("@O_Processor_Type", entity.Order_Processor_Type);
               //cmd.Parameters.AddWithValue("@O_processor_Speed", entity.Order_Processor_Speed);
               //cmd.Parameters.AddWithValue("@O_Ram", entity.Order_Ram);
               //cmd.Parameters.AddWithValue("@O_Lcd", entity.Order_Lcd);
               //cmd.Parameters.AddWithValue("@O_date", entity.Order_Date);


                return (int)cmd.ExecuteScalar();

            }
        }

        public int AddUserComments(List<UserCommentsEntity> entity)
        {
            // int i = 0;

           DataTable Comments = ConvertUserCommentsListToDataTable(entity);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spInsertUserComment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter customrId = cmd.Parameters.AddWithValue("@tblComments", Comments);



                return (int)cmd.ExecuteScalar();

            }
        }
        public int AddOrderSpec(List<OrderSpecEntity> entity)
        {
            // int i = 0;
          
            DataTable table = ConvertOrderSpecListToDataTable(entity);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[spInsertOrderSpec]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter customrId = cmd.Parameters.AddWithValue("@tblSpec", table);
                //cmd.Parameters.AddWithValue("@Status", obj.Statusid);
                //cmd.Parameters.AddWithValue("@ProductSpecification", obj.ProductSpecification);
             
                //cmd.Parameters.AddWithValue("@O_Model", entity.Order_Model);
                //cmd.Parameters.AddWithValue("@O_Processor_Type", entity.Order_Processor_Type);
                //cmd.Parameters.AddWithValue("@O_processor_Speed", entity.Order_Processor_Speed);
                //cmd.Parameters.AddWithValue("@O_Ram", entity.Order_Ram);
                //cmd.Parameters.AddWithValue("@O_Lcd", entity.Order_Lcd);
                //cmd.Parameters.AddWithValue("@O_date", entity.Order_Date);


                return (int)cmd.ExecuteScalar();

            }
        }

        public int AddNewPurchase(List<SerialNumberEnity> entity, int Category)
        {
            // int i = 0;

            DataTable table = ConvertPurchaseOrderListToDataTable(entity);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[spInsertPurchaseOrder ]", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter customrId = cmd.Parameters.AddWithValue("@tblEmp", table);
                SqlParameter category = cmd.Parameters.AddWithValue("@Category", Category);



                return (int)cmd.ExecuteScalar();

            }
        }
        public int UpdateReceivedQty(int ReceiveOrderId, int Gulf, int Received, string ReceiveDate)
        {

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateReceivedQty", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    cmd.Parameters.AddWithValue("@ReceiveOrderId", ReceiveOrderId);
                    cmd.Parameters.AddWithValue("@Gulf", Gulf);
                    cmd.Parameters.AddWithValue("@Received", Received);
                    cmd.Parameters.AddWithValue("@ReceiveDate", ReceiveDate);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        public int ReceiveAll(int Gulf)
        {
            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReceiveAllQty", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    cmd.Parameters.AddWithValue("@Gulf", Gulf);
              
                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        static DataTable ConvertOrderDetailsListToDataTable(List<OrderEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Orderid");
            dt.Columns.Add("Order_qty");
            dt.Columns.Add("Order_Make");
            dt.Columns.Add("Order_Model");
            dt.Columns.Add("Processor_Type");
            dt.Columns.Add("Processor_Speed");
            dt.Columns.Add("Order_Ram");
            dt.Columns.Add("Order_Hdd");
            dt.Columns.Add("Order_Lcd");
            dt.Columns.Add("PurchasedDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

              
                Order["Orderid"] = array.Orderid;
                Order["Order_Qty"] = array.Order_qty;
                Order["Order_Make"] = array.Order_Make;
                Order["Order_Model"] = array.Order_Model;
                Order["Processor_Type"] = array.Order_Processor_Type;
                Order["Processor_Speed"] = array.Order_Processor_Speed;
                Order["Order_Ram"] = array.Order_Ram;
                Order["Order_Hdd"] = array.Order_Hdd;
                Order["Order_Lcd"] = array.Order_Lcd;
                Order["PurchasedDate"] = array.PurchasedDate;
                dt.Rows.Add(Order);
            }

            return dt;
        }
        static DataTable ConvertUserCommentsListToDataTable(List<UserCommentsEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Orderid");
            dt.Columns.Add("User_Name");
            //dt.Columns.Add("Comment_Date");
            dt.Columns.Add("Comments");
            //dt.Columns.Add("CreatedBy");

            DataRow Comments;


            // Add rows.
            foreach (var array in list)
            {
                Comments = dt.NewRow();

                lineNo = lineNo + 1;
                Comments["Orderid"] = array.Order_No;
                Comments["User_Name"] = array.User_name;
            //    Comments["Comment_Date"] = array.Comment_Date;
                Comments["Comments"] = array.Comments;
                dt.Rows.Add(Comments);
            }

            return dt;
        }
        static DataTable ConvertOrderSpecListToDataTable(List<OrderSpecEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Statusid");
            dt.Columns.Add("AdditionalInfomation");
            dt.Columns.Add("ProductSpecification");
            

                //dt.Columns.Add("CreatedBy");

                DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();
                string status;
                lineNo = lineNo + 1;
                if (array.Statusid=="Yes")
                {
                    status = "1";
                }
                else { status = "0"; }

                Order["Statusid"] = Convert.ToInt32( status);
                Order["AdditionalInfomation"] = array.AdditionalInfomation;
                Order["ProductSpecification"] = array.ProductSpecification;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        static DataTable ConvertPurchaseOrderListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("MakeId");
            dt.Columns.Add("ModelId");
            dt.Columns.Add("ProcessorId");
            dt.Columns.Add("PurchasedQty");
            dt.Columns.Add("PurchasedPrice");
            dt.Columns.Add("PurchasedDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["MakeId"] = array.MakeId;
                Order["ModelId"] = array.ModelId;
                Order["ProcessorId"] = array.ProcessorId;
                Order["PurchasedQty"] = array.PurchaseQty;
                Order["PurchasedPrice"] = array.PurchasePrice;
                Order["PurchasedDate"] = array.PurchaseDate;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        #endregion
        public List<ProductionUploadEntity> GetProductionUploadData()
        {
            // int i = 0;
            ProductionUploadEntity serialentity;
            List<ProductionUploadEntity> serialentityList = new List<ProductionUploadEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetProductionUploadHistory", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new ProductionUploadEntity();

                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.HistoryId = Convert.ToInt32(dr["HistoryId"]);
                            serialentity.Filename = dr["Filename"].ToString();
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.AcceptStatus = Convert.ToInt32(dr["Status"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<ProductionUploadEntity> GetProductionUploadHistoryData(int HistoryId)
        {
            // int i = 0;
            ProductionUploadEntity serialentity;
            List<ProductionUploadEntity> serialentityList = new List<ProductionUploadEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetProductionUploadHistoryDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter historyId = cmd.Parameters.AddWithValue("@HistoryId", HistoryId);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new ProductionUploadEntity();

                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public string AcceptProductionUploadHistoryData(int HistoryId)
        {
            // int i = 0;
           // string result;
            List<ProductionUploadEntity> serialentityList = new List<ProductionUploadEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spAcceptProductionUploadHistoryData", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter historyId = cmd.Parameters.AddWithValue("@HistoryId", HistoryId);

                   return (string)cmd.ExecuteScalar();

                }
            }
        }

        public int ReleaseStockFromProduction(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReleaseStockFromProduction", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        static DataTable ConvertReleasefromProdListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("IssueName");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["IssueName"] = array.IssueName;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public List<InitialTestingUploadEnity> GetStockInQC(string Flag)
        {
            // int i = 0;
            InitialTestingUploadEnity serialentity;
            List<InitialTestingUploadEnity> serialentityList = new List<InitialTestingUploadEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetinQcStockData", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InitialTestingUploadEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.ProcessorType = dr["ProcessorType"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();
                            serialentity.IssueName = dr["IssueName"].ToString();
                            serialentity.Grade = dr["Grade"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public int ReleaseForTestingWorkShop(List<SerialNumberEnity> entity,string Flag)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReleaseforWorkShopandTesting", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }
      

        public int AcceptInWorkshop(string InhouseSerialNo, string Ordernumber,string IssueName,string Flag)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            //DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spAcceptInWorkshop", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);
                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);
                    SqlParameter order = cmd.Parameters.AddWithValue("@OrderNo", Ordernumber);
                    SqlParameter Issue = cmd.Parameters.AddWithValue("@IssueName", IssueName);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        public List<MultipleResultReturnEntity> TransferDepartMultipleNumber(string InhouseSerialNo, string Flag)
        {
            MultipleResultReturnEntity returnResult;
            List<MultipleResultReturnEntity> productDetailList = new List<MultipleResultReturnEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spTransferDepartmentMultiple", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);
                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            returnResult = new MultipleResultReturnEntity();

                            returnResult.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            returnResult.Status =Convert.ToInt32(dr["Status"]);
                            returnResult.Comment = dr["Comment"].ToString();

                            productDetailList.Add(returnResult);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }


        public List<SerialNumberEnity> GetAllMakeProductData(int id, string Flag)
        {
            SerialNumberEnity productDetail;
            List<SerialNumberEnity> productDetailList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGETPRODUCTDETAIL", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter ProductId = cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlParameter ProductFlag = cmd.Parameters.AddWithValue("@Flag", Flag);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            productDetail = new SerialNumberEnity();

                            productDetail.MakeId = Convert.ToInt32(dr["ProductId"]);
                            productDetail.MakeName = dr["ProductName"].ToString();

                            productDetailList.Add(productDetail);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }

       
        public List<SerialNumberEnity> GetCreateNewOrderForOkStock(string Flag)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCreateNewOrderForOkStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo =Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorName = dr["ProcessorType"].ToString();
                            serialentity.AvailableQty = Convert.ToInt32(dr["AvailableQty"]);

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> GetCreateNewOrderDetail(int GulfNo)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCreateNewOrderForOkStockDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.ProcessorName = dr["ProcessorType"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> GetSilverStock(string Flag)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetSilverStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public int ConvertToSilverStock(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertSilverStockListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spConvertStockToSilver", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        static DataTable ConvertSilverStockListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
           
            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();
                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                dt.Rows.Add(Order);
            }
            return dt;
        }

        public InitialTestingUploadEnity GetSearchSerialNo(string InhouseSerialNo)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            InitialTestingUploadEnity Obj = new InitialTestingUploadEnity();

            //DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spSearchSerialNo", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;

                            Obj.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            Obj.OrderNo = dr["OrderNo"].ToString();
                            Obj.MakeName = dr["MakeName"].ToString();
                            Obj.ModelName = dr["ModelName"].ToString();
                            Obj.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            Obj.ProcessorGen = dr["ProcessorGen"].ToString();
                            Obj.ProcessorSpeed= dr["ProcessorSpeed"].ToString();
                            Obj.ProcessorNo = dr["ProcessorNo"].ToString();
                            Obj.ProcessorType = dr["ProcessorType"].ToString();
                            Obj.Status = dr["StatusName"].ToString();
                            Obj.TypeName = dr["Type"].ToString();

                        }
                        if (isnull) return null;
                        else return Obj;
                    }

                }
            }
        }

        #region Reports

        public List<InventoryReportEntity> GetInventoryReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("SpInventoryReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.PurchaseQty = Convert.ToInt32(dr["PurchaseQty"]);
                            serialentity.TotalQty = Convert.ToInt32(dr["TotalQty"]);
                            serialentity.MoveToSilver = Convert.ToInt32(dr["Silver"]);
                            serialentity.ReceivedStatus = Convert.ToInt32(dr["ReceivedStatus"]);
                            serialentity.InitialTestingStatus = Convert.ToInt32(dr["InitialTestingStatus"]);
                            //serialentity.ProductionUploadStatus = Convert.ToInt32(dr["ProductionUploadStatus"]);
                            serialentity.Unassembling = Convert.ToInt32(dr["Unassemble"]);
                            serialentity.Motherboard = Convert.ToInt32(dr["Motherboard"]);
                            serialentity.Batchmaking = Convert.ToInt32(dr["Batchmaking"]);
                            serialentity.Assembling = Convert.ToInt32(dr["Assembling"]);
                            serialentity.InQC = Convert.ToInt32(dr["InQC"]);
                            serialentity.WorkShop = Convert.ToInt32(dr["WorkShop"]);
                            serialentity.Testing = Convert.ToInt32(dr["Testing"]);
                            serialentity.PendingStatus = Convert.ToInt32(dr["Pending"]);
                            serialentity.IntransitQty = Convert.ToInt32(dr["IntransitQty"]);
                            serialentity.Scrap = Convert.ToInt32(dr["Scrap"]);
                            serialentity.OkStock = Convert.ToInt32(dr["OkStock"]);
                            serialentity.OnbehalfUAE = Convert.ToInt32(dr["OnBehaflUAE"]);
                            serialentity.Sold = Convert.ToInt32(dr["Sold"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<InventoryReportEntity> GetCompleteStatusReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spTotalInvStatusReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.TotalQty = Convert.ToInt32(dr["TotalQty"]);
                            serialentity.MoveToSilver = Convert.ToInt32(dr["Silver"]);
                            serialentity.IntransitQty = Convert.ToInt32(dr["InTransit"]);
                            serialentity.ReceivedStatus = Convert.ToInt32(dr["ReceivedStatus"]);
                            serialentity.InitialTestingStatus = Convert.ToInt32(dr["InitialTestingStatus"]);
                            serialentity.WaitingForTagging = Convert.ToInt32(dr["WaitingForTagging"]);
                            serialentity.Unassembling = Convert.ToInt32(dr["Unassemble"]);
                            serialentity.Motherboard = Convert.ToInt32(dr["Motherboard"]);
                            serialentity.Batchmaking = Convert.ToInt32(dr["Batchmaking"]);
                            serialentity.Assembling = Convert.ToInt32(dr["Assembling"]);
                            serialentity.InQC = Convert.ToInt32(dr["InQC"]);
                            serialentity.WorkShop = Convert.ToInt32(dr["WorkShop"]);
                            serialentity.Testing = Convert.ToInt32(dr["Testing"]);
                            serialentity.PendingStatus = Convert.ToInt32(dr["Pending"]);

                            serialentity.Scrap = Convert.ToInt32(dr["Scrap"]);
                            serialentity.OkStock = Convert.ToInt32(dr["OkStock"]);
                            serialentity.OnbehalfUAE = Convert.ToInt32(dr["OnBehaflUAE"]);
                            serialentity.Sold = Convert.ToInt32(dr["Sold"]);
                            serialentity.Packaging = Convert.ToInt32(dr["Packaging"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<InventoryReportEntity> GetGulfWiseInvReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGulfWiseInvReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.TotalQty = Convert.ToInt32(dr["TotalQty"]);
                            serialentity.MoveToSilver = Convert.ToInt32(dr["Silver"]);
                            serialentity.ReceivedStatus = Convert.ToInt32(dr["ReceivedStatus"]);
                            serialentity.InitialTestingStatus = Convert.ToInt32(dr["InitialTestingStatus"]);
                            //serialentity.ProductionUploadStatus = Convert.ToInt32(dr["ProductionUploadStatus"]);
                            serialentity.Unassembling = Convert.ToInt32(dr["Unassemble"]);
                            serialentity.Motherboard = Convert.ToInt32(dr["Motherboard"]);
                            serialentity.Batchmaking = Convert.ToInt32(dr["Batchmaking"]);
                            serialentity.Assembling = Convert.ToInt32(dr["Assembling"]);
                            serialentity.InQC = Convert.ToInt32(dr["InQC"]);
                            serialentity.WorkShop = Convert.ToInt32(dr["WorkShop"]);
                            serialentity.Testing = Convert.ToInt32(dr["Testing"]);
                            serialentity.PendingStatus = Convert.ToInt32(dr["Pending"]);
                            serialentity.Scrap = Convert.ToInt32(dr["Scrap"]);
                            serialentity.OkStock = Convert.ToInt32(dr["OkStock"]);
                            serialentity.OnbehalfUAE = Convert.ToInt32(dr["OnBehaflUAE"]);
                            serialentity.Sold = Convert.ToInt32(dr["Sold"]);
                            serialentity.AvailableQty = Convert.ToInt32(dr["AvailableQty"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<InventoryReportEntity> GetGulfWiseInventoryCountReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGulfWiseCurrentCountStatusReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.TotalQty = Convert.ToInt32(dr["PurchaseQty"]);
                            serialentity.AvailableQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.IntransitQty = Convert.ToInt32(dr["IntransitQty"]);
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<InventoryReportEntity> GetCurrentStockValueReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCurrentSTockValueReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.Status = dr["Status"].ToString();
                            serialentity.PurchasePrice = Convert.ToDecimal(dr["CurrentStockValue"]);
                            serialentity.TotalQty = Convert.ToInt32(dr["TotalQty"]);


                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<InventoryReportEntity> GetComplteModelWiseReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spcompleteModelWiseReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.TotalQty = Convert.ToInt32(dr["Qty"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public List<InventoryReportEntity> GetCurrentStockValueSilverReport()
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCurrentSTockValueReportSilver", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.Status = dr["Status"].ToString();
                            serialentity.TotalQty = Convert.ToInt32(dr["TotalQty"]);
                            serialentity.PurchasePrice = Convert.ToDecimal(dr["CurrentStockValue"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<OnBehalfUAEOkStockEntity> GetOnBehalfOFUAEandOKStock()
        {
            // int i = 0;
            OnBehalfUAEOkStockEntity serialentity;
            List<OnBehalfUAEOkStockEntity> serialentityList = new List<OnBehalfUAEOkStockEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spOnBehlfofUAEOkStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new OnBehalfUAEOkStockEntity();

                            serialentity.StockType = dr["StockType"].ToString();
                            serialentity.MonthName = dr["MonthName"].ToString();
                            serialentity.MonthNumber = Convert.ToInt32(dr["MonthNumber"]);
                            serialentity.Qty = Convert.ToInt32(dr["Qty"]);

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
      

        public List<SerialNumberEnity> GetNewPurchasedetailbyGulfNo(int GulfNo)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetNewPurchasedetailbyGulfNo", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.OrderId = Convert.ToInt32(dr["OrderId"]);
                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorName = dr["Processor"].ToString();
                            serialentity.PurchaseQty = Convert.ToInt32(dr["PurchaseQty"]);
                            serialentity.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.Type = Convert.ToInt32(dr["Type"]);


                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
   
        
        public List<InventoryReportEntity> GetInventoryReportDetailByModel(int GulfNo, string ModelName)
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("SpGetInventoryReportDetailByModel", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter gulf = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);
                    SqlParameter Model = cmd.Parameters.AddWithValue("@ModelName", ModelName);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();


                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<PurchaseChargesEntity> GetInventoryReportDetailByGulfNo(int GulfNo)
        {
            // int i = 0;
            PurchaseChargesEntity serialentity;
            List<PurchaseChargesEntity> serialentityList = new List<PurchaseChargesEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("GetInventoryReportDetailByGulfNo", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter gulf = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new PurchaseChargesEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorName = dr["ProcessorType"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();
                            serialentity.TypeName = dr["Type"].ToString();
                            serialentity.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPurchasePrice"]);
                            serialentity.Passback = Convert.ToDecimal(dr["Passback"]);
                            serialentity.CustomDuty = Convert.ToDecimal(dr["CustomDuty"]);
                            serialentity.FreightCharges = Convert.ToDecimal(dr["Freight"]);
                            serialentity.Standardization = Convert.ToDecimal(dr["Standardization"]);
                            serialentity.Miscellaneous = Convert.ToDecimal(dr["Miscellaneous"]);
                            serialentity.PartsPrice = Convert.ToDecimal(dr["PartsPrice"]);
                            serialentity.ExportFees = Convert.ToDecimal(dr["ExportFees"]);
                            serialentity.LCD = Convert.ToDecimal(dr["LCD"]);
                            serialentity.BatteryPrice = Convert.ToDecimal(dr["BatteryPrice"]);
                            serialentity.ACAdaptorPrice = Convert.ToDecimal(dr["ACAdaptorPrice"]);
                            serialentity.HardDiskPrice = Convert.ToDecimal(dr["HardDiskPrice"]);
                            serialentity.RAMPrice = Convert.ToDecimal(dr["RAMPrice"]);
                            serialentity.KeyboardPrice = Convert.ToDecimal(dr["KeyboardPrice"]);
                            serialentity.COAPrice = Convert.ToDecimal(dr["COAPrice"]);
                            serialentity.BodyPartsPrice = Convert.ToDecimal(dr["BodyPartsPrice"]);
                            serialentity.InsurancePrice = Convert.ToDecimal(dr["InsurancePrice"]);
                            serialentity.PackingPrice = Convert.ToDecimal(dr["PackingPrice"]);
                            serialentity.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
                            serialentity.SoldCost = Convert.ToDecimal(dr["SoldCost"]);


                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
     

        public List<CompleteGulfReportEntity> GetCompleteGulfReport()
        {
            // int i = 0;
            CompleteGulfReportEntity serialentity;
            List<CompleteGulfReportEntity> serialentityList = new List<CompleteGulfReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCompleteGulfWiseReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new CompleteGulfReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.TotalPurchasedQty = Convert.ToInt32(dr["TotalPurchasedQty"]);
                            serialentity.TotalReceivedQty = Convert.ToInt32(dr["TotalReceivedQty"]);
                            serialentity.RefurbPurchase = Convert.ToInt32(dr["RefurbPurchase"]);
                            serialentity.RefurbReceive = Convert.ToInt32(dr["RefurbReceive"]);
                            serialentity.RefurbIntransit = Convert.ToInt32(dr["RefurbIntransit"]);
                            serialentity.SilverPurchased = Convert.ToInt32(dr["SilverPurchased"]);
                            serialentity.SilverReceive = Convert.ToInt32(dr["SilverReceive"]);
                            serialentity.SilverIntransit = Convert.ToInt32(dr["SilverIntransit"]);


                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public List<PurchaseChargesEntity> GetProfitabilityReport()
        {
            // int i = 0;
            PurchaseChargesEntity serialentity;
            List<PurchaseChargesEntity> serialentityList = new List<PurchaseChargesEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spProfitabilityReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new PurchaseChargesEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                           // serialentity.PurchaseQty = Convert.ToInt32(dr["Qty"]);
                           // serialentity.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.UploadedQty = Convert.ToInt32(dr["UploadedQty"]);
                            serialentity.SoldQty = Convert.ToInt32(dr["SoldQty"]);
                            serialentity.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPurchasePrice"]);
                            serialentity.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
                            serialentity.SoldCost = Convert.ToDecimal(dr["SoldPrice"]);
                            
                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        
        public List<InventoryReportEntity> GetCompleteReportDetailByGulfNo(int GulfNo)
        {
            // int i = 0;
            InventoryReportEntity serialentity;
            List<InventoryReportEntity> serialentityList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("CompleteGulfReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter gulf = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InventoryReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();
                            serialentity.Category = dr["Type"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public List<OnBehalfUAEOkStockEntity> GetOnBehalfOkStockDetail(string StockType, int MonthNumber)
        {
            // int i = 0;
            OnBehalfUAEOkStockEntity serialentity;
            List<OnBehalfUAEOkStockEntity> serialentityList = new List<OnBehalfUAEOkStockEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spOnBehlfofUAEOkStockDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Type = cmd.Parameters.AddWithValue("@StockType", StockType);
                    SqlParameter Month = cmd.Parameters.AddWithValue("@MonthNumber", MonthNumber);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new OnBehalfUAEOkStockEntity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.SCreatedDate= dr["CreatedDate"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<OnBehalfUAEOkStockEntity> GetQCProductionReportDailyDetail(string Flag)
        {
            // int i = 0;
            OnBehalfUAEOkStockEntity serialentity;
            List<OnBehalfUAEOkStockEntity> serialentityList = new List<OnBehalfUAEOkStockEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spQCDailyMovementreportDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);
                    
                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new OnBehalfUAEOkStockEntity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        
        public void ErrorCapture(string Message)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[spErrorCapturedLog]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@errorMessage", Message);

                cmd.ExecuteScalar();

            }
        }

        public List<QCProductionReportEntity> GetQCProductionReportDaily()
        {
            // int i = 0;
            QCProductionReportEntity serialentity;
            List<QCProductionReportEntity> serialentityList = new List<QCProductionReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("[spQCDailyReport]", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new QCProductionReportEntity();

                            serialentity.TotalInspected = dr["TotalInspected"].ToString();
                            serialentity.QCToTesting = dr["QCToTesting"].ToString();
                            serialentity.QcToWorkshop = dr["QcToWorkshop"].ToString();
                            serialentity.Rejection = dr["Rejection"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<InitialTestingUploadEnity> GetTotalRepairsReport(string Flag)
        {
            // int i = 0;
            InitialTestingUploadEnity serialentity;
            List<InitialTestingUploadEnity> serialentityList = new List<InitialTestingUploadEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spRepairsFinalReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InitialTestingUploadEnity();

                            serialentity.OrderNo = dr["OrderNo"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.ProcessorType = dr["ProcessorType"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();
                            serialentity.IssueName = dr["IssueName"].ToString();
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        #endregion

        #region PurchaseChargesUpload
        public List<PurchaseChargesEntity> GetPurchaseChargesUpload(List<PurchaseChargesEntity> entity)
        {
            // int i = 0;
            PurchaseChargesEntity purchaseentity;
            List<PurchaseChargesEntity> PurchaseentityList = new List<PurchaseChargesEntity>();

            DataTable table = ConvertNewPurchasePriceToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUploadPurchaseCharges", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            purchaseentity = new PurchaseChargesEntity();

                            purchaseentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            purchaseentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            purchaseentity.NewPurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]);
                            purchaseentity.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPurchasePrice"]);
                            purchaseentity.Passback = Convert.ToDecimal(dr["Passback"]);
                            purchaseentity.Passback = Convert.ToDecimal(dr["Passback"]);
                            purchaseentity.CustomDuty = Convert.ToDecimal(dr["CustomDuty"]);
                            purchaseentity.FreightCharges = Convert.ToDecimal(dr["FreightCharges"]);
                            purchaseentity.Standardization = Convert.ToDecimal(dr["Standardization"]);
                            purchaseentity.PartsPrice = Convert.ToDecimal(dr["PartsPrice"]);
                            purchaseentity.Resource = Convert.ToDecimal(dr["Resource"]);
                            purchaseentity.Miscellaneous = Convert.ToDecimal(dr["Miscellaneous"]);
                            purchaseentity.ExportFees = Convert.ToDecimal(dr["ExportFees"]);
                            purchaseentity.TypeName = dr["Type"].ToString();
                            purchaseentity.Comment = dr["Comment"].ToString();

                            PurchaseentityList.Add(purchaseentity);

                        }
                        if (isnull) return null;
                        else return PurchaseentityList;
                    }

                }
            }
        }


        static DataTable ConvertNewPurchasePriceToDataTable(List<PurchaseChargesEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("PurchasePrice");
            dt.Columns.Add("RevisedPurchasePrice");
            dt.Columns.Add("Passback");
            dt.Columns.Add("CustomDuty");
            dt.Columns.Add("FreightCharges");
            dt.Columns.Add("Standardization");
            dt.Columns.Add("PartsPrice");
            dt.Columns.Add("Resource");
            dt.Columns.Add("Miscellaneous");
            dt.Columns.Add("ExportFees");
            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["PurchasePrice"] = array.NewPurchasePrice;
                Order["RevisedPurchasePrice"] = array.RevisedPurchasePrice;
                Order["Passback"] = array.Passback;
                Order["CustomDuty"] = array.CustomDuty;
                Order["FreightCharges"] = array.FreightCharges;
                Order["Standardization"] = array.Standardization;
                Order["PartsPrice"] = array.PartsPrice;
                Order["Resource"] = array.Resource;
                Order["Miscellaneous"] = array.Miscellaneous;
                Order["ExportFees"] = array.ExportFees;

                dt.Rows.Add(Order);
            }

            return dt;
        }


        #endregion


        public List<CompleteReportEntity> GetCompleteStatusReportDetail(string filter)
        {
            // int i = 0;
            CompleteReportEntity serialentity;
            List<CompleteReportEntity> serialentityList = new List<CompleteReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCompleteStatusReportDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter gulf = cmd.Parameters.AddWithValue("@filter", filter);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new CompleteReportEntity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.SOrderNo = dr["OrderNo"].ToString();
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.ProcessorType = dr["ProcessorType"].ToString();

                            serialentity.PurchasePrice =Convert.ToDecimal(dr["PurchasePrice"]);
                            serialentity.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPurchasePrice"]);
                            serialentity.TotalCost = Convert.ToDecimal(dr["TotalCost"]);

                            serialentity.Passback = Convert.ToDecimal(dr["Passback"]);
                            serialentity.CustomDuty = Convert.ToDecimal(dr["CustomDuty"]);
                            serialentity.FreightCharges = Convert.ToDecimal(dr["FreightCharges"]);


                            serialentity.Standardization = Convert.ToDecimal(dr["Standardization"]);
                            serialentity.PartsPrice = Convert.ToDecimal(dr["PartsPrice"]);
                            serialentity.Resource = Convert.ToDecimal(dr["Resource"]);

                            serialentity.Miscellaneous = Convert.ToDecimal(dr["Miscellaneous"]);
                            serialentity.NeworderComment =dr["NeworderComment"].ToString();
                            serialentity.LCDPrice = Convert.ToDecimal(dr["LCDPrice"]);
                            serialentity.BatteryPrice = Convert.ToDecimal(dr["Miscellaneous"]);
                            serialentity.ACAdaptorPrice = Convert.ToDecimal(dr["ACAdaptorPrice"]);
                            serialentity.HardDiskPrice = Convert.ToDecimal(dr["HardDiskPrice"]);

                            serialentity.RAMPrice = Convert.ToDecimal(dr["RAMPrice"]);
                            serialentity.KeyboardPrice = Convert.ToDecimal(dr["KeyboardPrice"]);
                            serialentity.COAPrice = Convert.ToDecimal(dr["COAPrice"]);
                            serialentity.BodyPartsPrice = Convert.ToDecimal(dr["BodyPartsPrice"]);
                            serialentity.InsurancePrice = Convert.ToDecimal(dr["InsurancePrice"]);
                            serialentity.PackingPrice = Convert.ToDecimal(dr["PackingPrice"]);

                            serialentity.ProcessorGen = dr["ProcessorGen"].ToString();
                            serialentity.ProcessorNo = dr["ProcessorNo"].ToString();
                            serialentity.ProcessorSpeed = dr["ProcessorSpeed"].ToString();
                            serialentity.RAM = dr["RAM"].ToString();
                            serialentity.HDD = dr["HDD"].ToString();

                            serialentity.OSSticker = dr["OSSticker"].ToString();
                            serialentity.Webcam = dr["Webcam"].ToString();
                            serialentity.Optical = dr["Optical"].ToString();
                            serialentity.GraphicsName = dr["GraphicsName"].ToString();
                            serialentity.GraphicsMemory = dr["GraphicsMemory"].ToString();

                            serialentity.Resolution = dr["Resolution"].ToString();
                            serialentity.DisplaySize = dr["DisplaySize"].ToString();
                            serialentity.ScreenType = dr["ScreenType"].ToString();
                            serialentity.ACadapterType = dr["ACadapterType"].ToString();
                            serialentity.SupplierName = dr["SupplierName"].ToString();

                            serialentity.FingerPrintSecurity = dr["FingerPrintSecurity"].ToString();
                            serialentity.MadeIn = dr["MadeIn"].ToString();
                            serialentity.Battery = dr["Battery"].ToString();
                            serialentity.WiFI = dr["WiFI"].ToString();
                            serialentity.MouseTrack = dr["MouseTrack"].ToString();

                            serialentity.Status = dr["Status"].ToString();
                            serialentity.Grade = dr["Grade"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public List<InitialTestingUploadEnity> GetIntransitWaitingForTagging(string filter)
        {
            // int i = 0;
            InitialTestingUploadEnity serialentity;
            List<InitialTestingUploadEnity> serialentityList = new List<InitialTestingUploadEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetIntransitTaggingQty", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter gulf = cmd.Parameters.AddWithValue("@filter", filter);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new InitialTestingUploadEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                          
                            serialentity.PurchaseQty = Convert.ToInt32(dr["PurchaseQty"]);
                            serialentity.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.IntransitQty = Convert.ToInt32(dr["InransitQty"]);

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        

        public List<PendingPartEntity> GetAllPendingPart()
        {
            PendingPartEntity partDetail;
            List<PendingPartEntity> partDetailList = new List<PendingPartEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetPendingPartDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            partDetail = new PendingPartEntity();

                            partDetail.PartId = Convert.ToInt32(dr["PartId"]);
                            partDetail.PartName = dr["PartName"].ToString();

                            partDetailList.Add(partDetail);

                        }
                        if (isnull) return null;
                        else return partDetailList;
                    }

                }
            }
        }

        public int PendingDetailUpdate(List<PendingPartEntity> entity, string Flag,string InhouseSerialNo)
        {
            DataTable table = ConvertPendingUpdateToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdatePendingPart", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);
                    SqlParameter serialNo = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);
                    SqlParameter Appstatus = cmd.Parameters.AddWithValue("@AppStatus", "TrackingModule");
                    

                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        static DataTable ConvertPendingUpdateToDataTable(List<PendingPartEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("PartId");
            dt.Columns.Add("PartNo");
            dt.Columns.Add("Comment");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["PartId"] = array.PartId;
                Order["PartNo"] = array.PartNo;
                Order["Comment"] = array.Comment;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public List<PendingPartEntity> GetDetailbyInhouseNumber(string InhouseSerialNo)
        {
            // int i = 0;
            PendingPartEntity pendingEntity;
            List<PendingPartEntity> pendingEntityList = new List<PendingPartEntity>();

            //DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetUnCompletePendingDetailByNumber", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;

                            pendingEntity = new PendingPartEntity();

                            pendingEntity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            pendingEntity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            pendingEntity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            pendingEntity.MakeName = dr["MakeName"].ToString();
                            pendingEntity.ModelName = dr["ModelName"].ToString();
                            pendingEntity.ProcessorType = dr["ProcessorType"].ToString();
                            pendingEntity.PurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]);
                            pendingEntity.SCreatedDate = dr["CreatedDate"].ToString();
                            pendingEntity.PendingDay = Convert.ToInt32(dr["PendingDay"]);
                            pendingEntity.MissingPartId = Convert.ToInt32(dr["MissingPartId"]);
                            pendingEntity.MissingPartName = dr["MissingPartName"].ToString();
                            pendingEntity.PartNo = dr["PartNo"].ToString();
                            pendingEntity.Price = Convert.ToDecimal(dr["Price"]);
                            pendingEntity.Status = dr["StatusName"].ToString();
                            pendingEntity.Type = dr["Type"].ToString();

                            pendingEntityList.Add(pendingEntity);
                        }
                        if (isnull) return null;
                        else return pendingEntityList;
                    }

                }
            }
        }

        public int AcceptinPending(string InhouseSerialNo, string Flag, int MissingPartId)
        {

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spAcceptinPending", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);
                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);
                    SqlParameter order = cmd.Parameters.AddWithValue("@MissingPartId", MissingPartId);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }


        public List<SerialNumberEnity> GetSearchSerialNoHistory(string InhouseSerialNo)
        {
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spSearchSerialNoHistory_Refurb", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.Description = dr["Description"].ToString();
                            serialentity.SCreatedDate = dr["SCreatedDate"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public List<SerialNumberEnity> PurchaseUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            ConvertEntitiesDL obj = new ConvertEntitiesDL();

            DataTable table = obj.ConvertPurchaseUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spPurchaseUpload", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter TableType = cmd.Parameters.AddWithValue("@tblEmp", table);
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@uploadType", uplodType);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = Convert.ToInt32(dr["GulfNo"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorName = dr["ProcessorName"].ToString();
                            serialentity.Comment = dr["Comment"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> GetMakeModelSample()
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spMakeModelSample", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.MakeId = Convert.ToInt32(dr["MakeId"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelId = Convert.ToInt32(dr["ModelId"]);
                            serialentity.ModelName = dr["ModelName"].ToString();

                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }


        public List<OrderEntity> GetOrderDetail()
        {
            // int i = 0;
            OrderEntity Oentity;
            List<OrderEntity> serialentityList = new List<OrderEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetOrderDetails", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            Oentity = new OrderEntity();

                            Oentity.Orderid = Convert.ToInt32(dr["Orderno"]);
                            Oentity.Order_qty = Convert.ToInt32(dr["Qty"]);
                            Oentity.Order_Make = dr["O_Make"].ToString();
                            Oentity.Order_Model = dr["O_Model"].ToString();
                            Oentity.Order_Processor_Type= dr["O_Processor_Type"].ToString();
                            Oentity.Order_Processor_Speed = dr["O_processor_Speed"].ToString();
                            Oentity.Order_Ram = dr["O_Ram"].ToString();
                            Oentity.Order_Hdd = dr["O_Hdd"].ToString();
                            Oentity.Order_Lcd = dr["O_Lcd"].ToString();
                            Oentity.PurchasedDate= Convert.ToDateTime(dr["PurchaseDate"]);
                        


                            serialentityList.Add(Oentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<UserCommentsEntity> GetUserList()
        {
            // int i = 0;
            UserCommentsEntity Uentity;
            List<UserCommentsEntity> UserList = new List<UserCommentsEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUserList", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            Uentity = new UserCommentsEntity();

                            Uentity.User_id = Convert.ToInt32(dr["Emp_id"]);
                            Uentity.User_name = (dr["UserName"].ToString());




                            UserList.Add(Uentity);

                        }
                        if (isnull) return null;
                        else return UserList;
                    }

                }
            }
        }
        public List<OrderEntity> GetProductDetails(int OrderNo)
        {
            // int i = 0;
            OrderEntity Orderentity;
            List<OrderEntity> OrderList = new List<OrderEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("GetProductSpecification", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@OrderNo", OrderNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            Orderentity = new OrderEntity();

                            Orderentity.Productid= Convert.ToInt32(dr["Product_id"]);
                            Orderentity.ProductSpecification = dr["ProductSpecification"].ToString();


                            OrderList.Add(Orderentity);
                        }
                        if (isnull) return null;
                        else return OrderList;
                    }

                }
            }
        }

        public List<UserCommentsEntity> GetCommentsbyOrderNo(int OrderNo)
        {
            // int i = 0;
            UserCommentsEntity Comentity;
            List<UserCommentsEntity> ComList = new List<UserCommentsEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("GetCommentbyOrderNo", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@OrderNo", OrderNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            Comentity = new UserCommentsEntity();

                            Comentity.User_name = dr["UserName"].ToString();
                            Comentity.Comments = dr["Comment"].ToString();
                            Comentity.Comment_Date = dr["Comment_date"].ToString();


                            ComList.Add(Comentity);
                        }
                        if (isnull) return null;
                        else return ComList;
                    }

                }
            }
        }

        public List<UserCommentsEntity> GetNotificationCount()
        {
            // int i = 0;
            UserCommentsEntity Comentity;
            List<UserCommentsEntity> ComList = new List<UserCommentsEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("GetNotificationCount", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    //SqlParameter flag = cmd.Parameters.AddWithValue("@OrderNo", OrderNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            Comentity = new UserCommentsEntity();

                            Comentity.NotificationCount = dr["OrderCount"].ToString();
                            Comentity.Order_No = dr["Order_id"].ToString();


                            ComList.Add(Comentity);
                        }
                        if (isnull) return null;
                        else return ComList;
                    }

                }
            }
        }



        public int UpdateNotification(int OrderNo)
        {

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateNotificationStatus", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
                
                    return (int)cmd.ExecuteScalar();

                }
            }
        }
    }



}
