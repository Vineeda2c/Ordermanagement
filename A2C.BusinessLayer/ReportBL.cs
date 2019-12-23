using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2C.DBLayer;
using BusinessEntity;

namespace A2C.BusinessLayer
{
   public class ReportBL
    {
        public List<PurchaseChargesEntity> GetAvailableStockreport(int MakeId,int ModelId,int ProcessorId)
        {
            ReportDL productdal = new ReportDL();

            return productdal.GetAvailableStockreport(MakeId, ModelId, ProcessorId);
        }
        public List<PurchaseChargesEntity> GetPriceWiseReport(int MakeId, int ModelId, int ProcessorId)
        {
            ReportDL productdal = new ReportDL();

            return productdal.GetPriceWiseReport(MakeId, ModelId, ProcessorId);
        }

        
        public List<PurchaseChargesEntity> GetCompleteAvailableStockreport(int TypeId, int MakeId, int ModelId, int ProcessorId)
        {
            ReportDL productdal = new ReportDL();

            return productdal.GetCompleteAvailableStockreport(TypeId, MakeId, ModelId, ProcessorId);
        }
        public List<CompleteReportEntity> GetAvailableStockreportDetail(string MakeName, string ModelName, string ProcessorName)
        {
            ReportDL productdal = new ReportDL();

            return productdal.GetAvailableStockreportDetail(MakeName, ModelName, ProcessorName);
        }
        public List<PurchaseChargesEntity> GetTotalStockReportRefurb()
        {
            ReportDL productdal = new ReportDL();
            return productdal.GetTotalStockReportRefurb();
        }
        public List<ReserverOrderEntity> GetReserveOrder()
        {
            ReportDL productdal = new ReportDL();
            return productdal.GetReserveOrder();
        }
        public int AddNewReserveOrder(ReserverOrderEntity entity)
        {
            ReportDL Obj = new ReportDL();
            return Obj.AddNewReserveOrder(entity);
        }
        public int UpdateReserveOrder(ReserverOrderEntity entity)
        {
            ReportDL Obj = new ReportDL();
            return Obj.UpdateReserveOrder(entity);
        }
        public int CompleteReserveOrder(int ReserveId)
        {
            ReportDL Obj = new ReportDL();
            return Obj.CompleteReserveOrder(ReserveId);
        }

        
    }
}
