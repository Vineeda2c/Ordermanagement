using A2C.DBLayer;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.BusinessLayer
{
    public class AddSerialBL
    {

        public List<SerialNumberEnity> InsertReceiptStock(List<SerialNumberEnity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.InsertReceiptStock(entity);
        }

        public List<InitialTestingUploadEnity> InsertInitialTestingStock(List<InitialTestingUploadEnity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.InsertInitialTestingStock(entity);
        }
        public List<SerialNumberEnity> ProductionUploadStock(List<SerialNumberEnity> entity,string NewFileName)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ProductionUploadStock(entity, NewFileName);
        }
        public List<SerialNumberEnity> ProductionReceivedStock(List<SerialNumberEnity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ProductionReceivedStock(entity);
        }
        public List<SerialNumberEnity> ScrapPendingUploadStock(List<SerialNumberEnity> entity,int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ScrapPendingUploadStock(entity, uplodType);
        }
        public List<InventoryReportEntity> GetInventoryReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetInventoryReport();
        }
       
        public List<SerialNumberEnity> OkStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.OkStockUpload(entity, uplodType);
        }
        public List<SerialNumberEnity> PackagingStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.PackagingStockUpload(entity, uplodType);
        }
        public List<SerialNumberEnity> SoldStockUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.SoldStockUpload(entity, uplodType);
        }
        public List<SerialNumberEnity> NewOrderCommentUpdate(List<SerialNumberEnity> entity, int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.NewOrderCommentUpdate(entity, uplodType);
        }
        #region PurchaseOrder
        public List<SerialNumberEnity> GetPurchaseDetail()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetPurchaseDetail();
        }

        public int AddNewPurchase(List<SerialNumberEnity> entity,int Category)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddNewPurchase(entity, Category);
        }
        public int AddNewOrder(List<OrderEntity>ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddNewOrder(ent);
        }
        public int AddUserComments(List<UserCommentsEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddUserComments(ent);
        }
        public int AddOrderSpec(List<OrderSpecEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddOrderSpec(ent);
        }
        public int UpdateReceivedQty(int ReceiveOrderId, int Gulf, int Received, string ReceiveDate)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.UpdateReceivedQty(ReceiveOrderId, Gulf, Received, ReceiveDate);
        }

        public int ReceiveAll(int Gulf)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ReceiveAll(Gulf);
        }

        #endregion 
        public List<ProductionUploadEntity> GetProductionUploadData()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetProductionUploadData();
        }
        public List<ProductionUploadEntity> GetProductionUploadHistoryData(int HistoryId)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetProductionUploadHistoryData(HistoryId);
        }

        public string AcceptProductionUploadHistoryData(int HistoryId)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AcceptProductionUploadHistoryData(HistoryId);
        }

        public int ReleaseStockFromProduction(List<SerialNumberEnity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ReleaseStockFromProduction(entity);
        }
        public List<InitialTestingUploadEnity> GetStockInQC(string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetStockInQC(Flag);
        }
        
        public int ReleaseForTestingWorkShop(List<SerialNumberEnity> entity,string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ReleaseForTestingWorkShop(entity, Flag);
        }
       

        public int AcceptInWorkshop(string InhouseSerialNo,string OrderNumber,string IssueName ,string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AcceptInWorkshop(InhouseSerialNo, OrderNumber, IssueName, Flag);
        }
        public List<MultipleResultReturnEntity> TransferDepartMultipleNumber(string InhouseSerialNo, string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.TransferDepartMultipleNumber(InhouseSerialNo, Flag);
        }
        

        public int AcceptinPending(string InhouseSerialNo, string Flag, int MissingPartId)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AcceptinPending(InhouseSerialNo,Flag,MissingPartId);
        }

        
        public List<SerialNumberEnity> GetAllMakeProductData(int id, string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();

            return productdal.GetAllMakeProductData(id, Flag);
        }

        public List<SerialNumberEnity> GetNewPurchasedetailbyGulfNo(int GulfNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetNewPurchasedetailbyGulfNo(GulfNo);
        }
     
        

        public List<SerialNumberEnity> GetCreateNewOrderForOkStock(string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCreateNewOrderForOkStock(Flag);
        }

        public List<SerialNumberEnity> GetCreateNewOrderDetail(int GulfNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCreateNewOrderDetail(GulfNo);
        }
        public List<SerialNumberEnity> GetSilverStock(string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetSilverStock(Flag);
        }
        public int ConvertToSilverStock(List<SerialNumberEnity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.ConvertToSilverStock(entity);
        }

        public InitialTestingUploadEnity GetSearchSerialNo(string InhouseSerialNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetSearchSerialNo(InhouseSerialNo);
        }

        #region Report
        public List<InventoryReportEntity> GetCompleteStatusReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCompleteStatusReport();
        }
        public List<InventoryReportEntity> GetGulfWiseInvReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetGulfWiseInvReport();
        }
        public List<InventoryReportEntity> GetGulfWiseInventoryCountReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetGulfWiseInventoryCountReport();
        }
        public List<InventoryReportEntity> GetCurrentStockValueReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCurrentStockValueReport();
        }
        public List<InventoryReportEntity> GetComplteModelWiseReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetComplteModelWiseReport();
        }

        public List<InventoryReportEntity> GetCurrentStockValueSilverReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCurrentStockValueSilverReport();
        }
        public List<CompleteGulfReportEntity> GetCompleteGulfReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCompleteGulfReport();
        }
        public List<PurchaseChargesEntity> GetProfitabilityReport()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetProfitabilityReport();
        }

        public List<InventoryReportEntity> GetInventoryReportDetailByModel(int GulfNo, string ModelName)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetInventoryReportDetailByModel(GulfNo, ModelName);
        }

        public List<PurchaseChargesEntity> GetInventoryReportDetailByGulfNo(int GulfNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetInventoryReportDetailByGulfNo(GulfNo);
        }


        public List<InventoryReportEntity> GetCompleteReportDetailByGulfNo(int GulfNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCompleteReportDetailByGulfNo(GulfNo);
        }

        public List<OnBehalfUAEOkStockEntity> GetOnBehalfOFUAEandOKStock()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetOnBehalfOFUAEandOKStock();
        }

        public List<OnBehalfUAEOkStockEntity> GetOnBehalfOkStockDetail(string StockType, int MonthNumber)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetOnBehalfOkStockDetail(StockType,MonthNumber);
        }
        public List<OnBehalfUAEOkStockEntity> GetQCProductionReportDailyDetail(string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetQCProductionReportDailyDetail(Flag);
        }

        
        public void ErrorCapture(string Message)
        {
            AddSerialDL productdal = new AddSerialDL();

            productdal.ErrorCapture(Message);
        }
        public List<QCProductionReportEntity> GetQCProductionReportDaily()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetQCProductionReportDaily();
        }
        public List<InitialTestingUploadEnity> GetTotalRepairsReport(string Flag)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetTotalRepairsReport(Flag);
        }

        public List<PurchaseChargesEntity> GetPurchaseChargesUpload(List<PurchaseChargesEntity> entity)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetPurchaseChargesUpload(entity);
        }

        #endregion

        public List<CompleteReportEntity> GetCompleteStatusReportDetail(string filter)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCompleteStatusReportDetail(filter);
        }
        public List<InitialTestingUploadEnity> GetIntransitWaitingForTagging(string filter)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetIntransitWaitingForTagging(filter);
        }
        
        public List<PendingPartEntity> GetAllPendingPart()
        {
            AddSerialDL productdal = new AddSerialDL();

            return productdal.GetAllPendingPart();
        }

        public int PendingDetailUpdate(List<PendingPartEntity> entity, string Flag,string InhouseSerialNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.PendingDetailUpdate(entity, Flag,InhouseSerialNo);
        }


        public List<PendingPartEntity> GetDetailbyInhouseNumber(string InhouseSerialNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetDetailbyInhouseNumber(InhouseSerialNo);
        }

        public List<SerialNumberEnity> GetSearchSerialNoHistory(string InhouseSerialNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetSearchSerialNoHistory(InhouseSerialNo);
        }
        public List<SerialNumberEnity> PurchaseUpload(List<SerialNumberEnity> entity, int uplodType)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.PurchaseUpload(entity, uplodType);
        }
        public List<SerialNumberEnity> GetMakeModelSample()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetMakeModelSample();
        }

        public List<OrderEntity> GetOrderDetail()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetOrderDetail();
        }

        public List<UserCommentsEntity> GetUserList()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetUserList();
        }


        public List<OrderEntity> GetProductDetails(int OrderNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetProductDetails(OrderNo);
        
        }
        public List<UserCommentsEntity> GetCommentsbyOrderNo(int OrderNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCommentsbyOrderNo(OrderNo);

        }
        public List<UserCommentsEntity> GetNotificationCount()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetNotificationCount();

        }

        public int UpdateNotification(int Orderno)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.UpdateNotification(Orderno);
        }

    }
}
