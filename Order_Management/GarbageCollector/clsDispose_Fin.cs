using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTrackingModule.Garbage_Collector
{
    public class clsDispose_Fin:IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose1(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose1(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
                
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~clsDispose_Fin()
        {
            Dispose1(false);
        }
    }
}