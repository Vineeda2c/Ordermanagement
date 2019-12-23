using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class MasterCompleteReportEntity
    {
        public MasterCompleteReportEntity()
        {
            new List<MasterSerialNumberEntity>();
        }

        public List<CompleteReportEntity> CompleteReportEntity { get; set; }
    }
    public class CompleteReportEntity
    {
        public int GulfNo { get; set; }
        public int OrderNo { get; set; }
        public string SOrderNo { get; set; }
        public string InhouseSerialNo { get; set; }
        public string OriginalSerialNo { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ProcessorType { get; set; }
        public string ProcessorGen { get; set; }
        public string ProcessorNo { get; set; }
        public string ProcessorSpeed { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RevisedPurchasePrice { get; set; }
        public decimal Passback { get; set; }
        public decimal CustomDuty { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal Standardization { get; set; }
        public decimal Resource { get; set; }
        public decimal Miscellaneous { get; set; }
        public decimal PartsPrice { get; set; }
        public string NeworderComment { get; set; }
        public decimal LCDPrice { get; set; }
        public decimal BatteryPrice { get; set; }
        public decimal ACAdaptorPrice { get; set; }
        public decimal HardDiskPrice { get; set; }
        public decimal RAMPrice { get; set; }
        public decimal KeyboardPrice { get; set; }
        public decimal COAPrice { get; set; }
        public decimal BodyPartsPrice { get; set; }
        public decimal InsurancePrice { get; set; }
        public decimal PackingPrice { get; set; }
        public decimal TotalCost { get; set; }
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
        public string ACadapterType { get; set; }
        public string SupplierName { get; set; }
        public string FingerPrintSecurity { get; set; }
        public string MadeIn { get; set; }
        public string Battery { get; set; }
        public string WiFI { get; set; }
        public string MouseTrack { get; set; }
        public string Status { get; set; }
        public string Grade { get; set; }

    }
}
