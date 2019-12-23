using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class MasterSerialNumberEntity
    {
        public MasterSerialNumberEntity()
        {
            new List<MasterSerialNumberEntity>();
        }

        public List<SerialNumberEnity> serialNumberEntity { get; set; }

        public List<InitialTestingUploadEnity> productionUploadEnity { get; set; }

        public List<InventoryReportEntity> inventoryReportEntity { get; set; }

        public List<ProductionUploadEntity> productionUploadEntity { get; set; }
    }
    public class SerialNumberEnity
    {
        //public int SerialId { get; set; }
        //public int RecordId { get; set; }
        public int GulfNo { get; set; }
        public int PurchaseQty { get; set; }
        public int ReceivedQty { get; set; }
        public string OrderNo { get; set; }
        public int OrderId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public int ModelId { get; set; }
        public string BatchNo { get; set; }
        public string InhouseSerialNo { get; set; }
        public string OriginalSerialNo { get; set; }
        public string SCreatedDate { get; set; }
        public string Comment { get; set; }
        public string IssueName { get; set; }
        public string PendingScrapReason { get; set; }
        public string Status { get; set; }
        public int ProcessorId { get; set; }
        public string ProcessorName { get; set; }
        public int AvailableQty { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseDate { get; set; }
        public string Category { get; set; }
        public string Grade { get; set; }
        public int IntransitQty { get; set; }
        public int UploadedQty { get; set; }
        public string InvoiceNo { get; set; }
        public string SoldPrice { get; set; }
        public string SoldDate { get; set; }
        public string Description { get; set; }
        public decimal TotalCostN { get; set; }
    }
    public class InitialTestingUploadEnity : SerialNumberEnity
    {
        public string ProcessorType { get; set; }
        public string ProcessorGen { get; set; }
        public string ProcessorNo { get; set; }
        public string ProcessorSpeed { get; set; }
        public string RAM { get; set; }
        public string HDD { get; set; }
        public string KeyboardLan { get; set; }
        public string OSSticker { get; set; }
        public string Webcam { get; set; }
        public string Optical { get; set; }
        public string GraphicsName { get; set; }
        public string GraphicsMemory { get; set; }
        public string Resolution { get; set; }
        public string DisplaySize { get; set; }
        public string ScreenType { get; set; }
        public string Acadapter { get; set; }
        public string SupplierName { get; set; }
        public string FingerPrintSecurity { get; set; }
        public string MadeIn { get; set; }
        public string Battery { get; set; }
        public string Wifi { get; set; }

        public string MouseTrack { get; set; }
       
    }

    public class InventoryReportEntity : SerialNumberEnity
    {
        public int TotalQty { get; set; }
        public int ReceivedStatus { get; set; }
        public int InitialTestingStatus { get; set; }
        public int ProductionUploadStatus { get; set; }
        public int ProductionReceivedStatus { get; set; }
        public int WaitingForTagging { get; set; }
        public int ScrapStatus { get; set; }
        public int PendingStatus { get; set; }
        public int OkStock { get; set; }
        public int Rejected { get; set; }
        public int Sold { get; set; }
        public int Storage { get; set; }
        public int InQC { get; set; }
        public int WorkShop { get; set; }
        public int Testing { get; set; }
        public new int IntransitQty { get; set; }
        public int Scrap { get; set; }
        public int OnbehalfUAE { get; set; }
        public int MoveToSilver { get; set; }
        public int Unassembling { get; set; }
        public int Motherboard { get; set; }
        public int Batchmaking { get; set; }
        public int Assembling { get; set; }

        public int Packaging { get; set; }
    }
    public class ProductionUploadEntity : SerialNumberEnity
    {
        public int AcceptStatus { get; set; }
        public int HistoryId { get; set; }
        public string Filename { get; set; }
    }

    public class CompleteGulfReportEntity : SerialNumberEnity
    {
        public int TotalPurchasedQty { get; set; }
        public int TotalReceivedQty { get; set; }
        public int RefurbPurchase { get; set; }
        public int RefurbReceive { get; set; }
        public int RefurbIntransit { get; set; }
        public int SilverPurchased { get; set; }
        public int SilverReceive { get; set; }
        public int SilverIntransit { get; set; }
    }
    public class OnBehalfUAEOkStockEntity : SerialNumberEnity
    {
        public string StockType { get; set; }
        public string MonthName { get; set; }
        public int MonthNumber { get; set; }
        public int Qty { get; set; }
    }

    public class QCProductionReportEntity : SerialNumberEnity
    {
        public string TotalInspected { get; set; }
        public string AssemblingToQC { get; set; }
        public string AcceptedInQC { get; set; }
        public string QCToTesting { get; set; }
        public string QcToWorkshop { get; set; }
        public string Rejection { get; set; }
    }

    public class PurchaseChargesEntity : SerialNumberEnity
    {
        public int SoldQty { get; set; }
        public int OrderQty { get; set; }
        public new int OrderNo { get; set; }
        public decimal SoldCost { get; set; }
        public decimal NewPurchasePrice { get; set; }
        public decimal RevisedPurchasePrice { get; set; }
        public decimal CustomDuty { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal Passback { get; set; }
        public decimal Standardization { get; set; }

        public decimal PartsPrice { get; set; }
        public decimal Resource { get; set; }
        public decimal Miscellaneous { get; set; }
        public decimal ExportFees { get; set; }
        public decimal TotalCost { get; set; }
        public decimal LCD { get; set; }
        public decimal BatteryPrice { get; set; }
        public decimal ACAdaptorPrice { get; set; }
        public decimal HardDiskPrice { get; set; }
        public decimal RAMPrice { get; set; }
        public decimal KeyboardPrice { get; set; }
        public decimal COAPrice { get; set; }
        public decimal BodyPartsPrice { get; set; }
        public decimal InsurancePrice { get; set; }
        public decimal PackingPrice { get; set; }

        public List<PurchaseChargesEntity> purchaseChargesEntity { get; set; }
        public List<InventoryReportEntity> inventoryReportEntitylist{ get; set; }

        public InventoryReportEntity inventoryReportEntityobj { get; set; }

    }
    public class PendingPartEntity 
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string PartNo { get; set; }
        public string Comment { get; set; }

        public int GulfNo { get; set; }
        public string InhouseSerialNo { get; set; }
        public string OriginalSerialNo { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ProcessorType { get; set; }

        public decimal PurchasePrice { get; set; }
        public string SCreatedDate { get; set; }
        public int PendingDay { get; set; }
        public int MissingPartId { get; set; }



        public string MissingPartName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        


    }
    public class OrderEntity
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }

        public int Statusid { get; set; }
        public int Order_qty { get; set; }
        public string Order_Make { get; set; }
        public string Order_Model { get; set; }
        public string Order_Processor_Type { get; set; }
        public string Order_Processor_Speed { get; set; }
        public string Order_Ram { get; set; }
        public string Order_Hdd { get; set; }
        public string Order_Lcd { get; set; }
        public string ProductSpecification { get; set; }
        public string AdditionalInfomation { get; set; }
        public string OrderSpecification { get; set; }
        public DateTime  PurchasedDate { get; set; }

       
    }
    public class OrderSpecEntity
    {
       
        public string Statusid { get; set; }
        public string ProductSpecification { get; set; }
        public string AdditionalInfomation { get; set; }
     
    }
    public class UserCommentsEntity
    {
        public string Order_No { get; set; }
        public string User_name { get; set; }
        public int  User_id{ get; set; }
        public string Comment_Date { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        public string NotificationCount { get; set; }
    }


}
