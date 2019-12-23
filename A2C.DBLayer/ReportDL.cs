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
   public class ReportDL
    {
        string cs = ConfigurationManager.ConnectionStrings["A2CConnectionString"].ToString();


        public List<PurchaseChargesEntity> GetAvailableStockreport(int MakeId, int ModelId, int ProcessorId)
        {
            PurchaseChargesEntity productDetail;
            InventoryReportEntity InvReport;
            List<PurchaseChargesEntity> productDetailList = new List<PurchaseChargesEntity>();

            //List<InventoryReportEntity> InvReportList = new List<InventoryReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetAvailableStockReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Make = cmd.Parameters.AddWithValue("@MakeId", MakeId);
                    SqlParameter Model = cmd.Parameters.AddWithValue("@ModelId", ModelId);
                    SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorId", ProcessorId);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            productDetail = new PurchaseChargesEntity();
                            InvReport = new InventoryReportEntity();

                            productDetail.MakeName = dr["MakeName"].ToString();
                            productDetail.ModelName = dr["ModelName"].ToString();
                            productDetail.ProcessorName = dr["ProcessorType"].ToString();
                            productDetail.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            productDetail.SoldQty = Convert.ToInt32(dr["SoldQty"]);
                            productDetail.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPrice"]);
                            productDetail.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
                            //productDetail.OrderNo = Convert.ToInt32(dr["OrderNo"]);
                            productDetail.OrderQty = Convert.ToInt32(dr["OrderQty"]);
                            productDetail.IntransitQty = Convert.ToInt32(dr["IntransitQty"]);
                        

                            InvReport.AvailableQty= Convert.ToInt32(dr["AvailableQty"]);
                            InvReport.ReceivedStatus = Convert.ToInt32(dr["ReceivedStatus"]);
                            InvReport.InitialTestingStatus = Convert.ToInt32(dr["IntitialTestingStatus"]);
                            InvReport.Unassembling = Convert.ToInt32(dr["Unassemble"]);
                            InvReport.Motherboard = Convert.ToInt32(dr["Motherboard"]);
                            InvReport.Batchmaking = Convert.ToInt32(dr["Batchmaking"]);
                            InvReport.InQC = Convert.ToInt32(dr["InQC"]);
                            InvReport.Assembling = Convert.ToInt32(dr["Assembling"]);

                            InvReport.WorkShop = Convert.ToInt32(dr["WorkShop"]);
                            InvReport.Testing = Convert.ToInt32(dr["Testing"]);
                            InvReport.PendingStatus = Convert.ToInt32(dr["Pending"]);
                            InvReport.OkStock = Convert.ToInt32(dr["OkStock"]);
                            InvReport.WaitingForTagging = Convert.ToInt32(dr["WaitingForTagging"]);
                            InvReport.Packaging = Convert.ToInt32(dr["Packaging"]);


                            productDetail.inventoryReportEntityobj = InvReport;
                            
                            productDetailList.Add(productDetail);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }

        public List<PurchaseChargesEntity> GetPriceWiseReport(int MakeId, int ModelId, int ProcessorId)
        {
          
            List<PurchaseChargesEntity> productDetailList = new List<PurchaseChargesEntity>();
            PurchaseChargesEntity productDetail;


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spPriceWiseReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Make = cmd.Parameters.AddWithValue("@MakeId", MakeId);
                    SqlParameter Model = cmd.Parameters.AddWithValue("@ModelId", ModelId);
                    SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorId", ProcessorId);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            productDetail = new PurchaseChargesEntity();

                            productDetail.MakeName = dr["MakeName"].ToString();
                            productDetail.ModelName = dr["ModelName"].ToString();
                            productDetail.ProcessorName = dr["ProcessorType"].ToString();
                            productDetail.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            productDetail.SoldQty = Convert.ToInt32(dr["SoldQty"]);
                            productDetail.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPrice"]);
                            productDetail.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
                            //productDetail.OrderNo = Convert.ToInt32(dr["OrderNo"]);
                            productDetail.OrderQty = Convert.ToInt32(dr["OrderQty"]);

                            productDetailList.Add(productDetail);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }

        

        public List<PurchaseChargesEntity> GetCompleteAvailableStockreport(int TypeId, int MakeId, int ModelId, int ProcessorId)
        {
            PurchaseChargesEntity productDetail;
            List<PurchaseChargesEntity> productDetailList = new List<PurchaseChargesEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetCmpltAvailableStockReport", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Type = cmd.Parameters.AddWithValue("@TypeId", TypeId);
                    SqlParameter Make = cmd.Parameters.AddWithValue("@MakeId", MakeId);
                    SqlParameter Model = cmd.Parameters.AddWithValue("@ModelId", ModelId);
                    SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorId", ProcessorId);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            productDetail = new PurchaseChargesEntity();

                            productDetail.MakeName = dr["MakeName"].ToString();
                            productDetail.ModelName = dr["ModelName"].ToString();
                            productDetail.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            productDetail.SoldQty = Convert.ToInt32(dr["SoldQty"]);
                            productDetail.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPrice"]);
                            productDetail.TotalCost = Convert.ToDecimal(dr["TotalCost"]);
                            productDetail.SoldCost = Convert.ToDecimal(dr["SoldCost"]);

                            productDetailList.Add(productDetail);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }

        public List<CompleteReportEntity> GetAvailableStockreportDetail(string MakeName, string ModelName, string ProcessorName)
        {
            CompleteReportEntity serialentity;
            List<CompleteReportEntity> productDetailList = new List<CompleteReportEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spAvailableStockReportDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Make = cmd.Parameters.AddWithValue("@MakeName", MakeName);
                    SqlParameter Model = cmd.Parameters.AddWithValue("@ModelName", ModelName);
                    SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorName", ProcessorName);


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

                            serialentity.PurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]);
                            serialentity.RevisedPurchasePrice = Convert.ToDecimal(dr["RevisedPurchasePrice"]);
                            serialentity.TotalCost = Convert.ToDecimal(dr["TotalCost"]);

                            serialentity.Passback = Convert.ToDecimal(dr["Passback"]);
                            serialentity.CustomDuty = Convert.ToDecimal(dr["CustomDuty"]);
                            serialentity.FreightCharges = Convert.ToDecimal(dr["FreightCharges"]);


                            serialentity.Standardization = Convert.ToDecimal(dr["Standardization"]);
                            serialentity.PartsPrice = Convert.ToDecimal(dr["PartsPrice"]);
                            serialentity.Resource = Convert.ToDecimal(dr["Resource"]);

                            serialentity.Miscellaneous = Convert.ToDecimal(dr["Miscellaneous"]);
                            serialentity.NeworderComment = dr["NeworderComment"].ToString();
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

                            productDetailList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }


        public List<PurchaseChargesEntity> GetTotalStockReportRefurb()
        {
            // int i = 0;
            PurchaseChargesEntity serialentity;
            List<PurchaseChargesEntity> serialentityList = new List<PurchaseChargesEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetTotalStockReportRefurb", myConnection))
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


        public List<ReserverOrderEntity> GetReserveOrder()
        {
            // int i = 0;
            ReserverOrderEntity serialentity;
            List<ReserverOrderEntity> serialentityList = new List<ReserverOrderEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetReserveOrder", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new ReserverOrderEntity();

                            serialentity.ReserveId = Convert.ToInt32(dr["ReserveId"]);
                            serialentity.MakeId = Convert.ToInt32(dr["MakeId"]);
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelId= Convert.ToInt32(dr["ModelId"]);
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorId = Convert.ToInt32(dr["ProcessorId"]);
                            serialentity.ProcessorType= dr["ProcessorType"].ToString();
                            serialentity.OrderQty = Convert.ToInt32(dr["OrderQty"]);
                            serialentity.OrderNo = Convert.ToInt32(dr["OrderNo"]);
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();


                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public int AddNewReserveOrder(ReserverOrderEntity entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spNewReserveOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter orderNo = cmd.Parameters.AddWithValue("@OrderNo", entity.OrderNo);
                SqlParameter make = cmd.Parameters.AddWithValue("@MakeId", entity.MakeId);
                SqlParameter Model = cmd.Parameters.AddWithValue("@ModelId", entity.ModelId);
                SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorId", entity.ProcessorId);
                SqlParameter orderQty = cmd.Parameters.AddWithValue("@OrderQty", entity.OrderQty);

                return (int)cmd.ExecuteScalar();

            }
        }
        public int UpdateReserveOrder(ReserverOrderEntity entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spUpdateReserveOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter reserver = cmd.Parameters.AddWithValue("@ReserveId", entity.ReserveId);
                SqlParameter orderNo = cmd.Parameters.AddWithValue("@OrderNo", entity.OrderNo);
                SqlParameter make = cmd.Parameters.AddWithValue("@MakeId", entity.MakeId);
                SqlParameter Model = cmd.Parameters.AddWithValue("@ModelId", entity.ModelId);
                SqlParameter Processor = cmd.Parameters.AddWithValue("@ProcessorId", entity.ProcessorId);
                SqlParameter orderQty = cmd.Parameters.AddWithValue("@OrderQty", entity.OrderQty);

                return (int)cmd.ExecuteScalar();
            }
        }

        public int CompleteReserveOrder(int ReserveId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spCompleteReserveOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter reserver = cmd.Parameters.AddWithValue("@ReserveId", ReserveId);
               

                return (int)cmd.ExecuteScalar();
            }
        }

        

    }
}
