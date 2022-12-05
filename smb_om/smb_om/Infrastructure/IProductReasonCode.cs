using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface IProductReasonCode
    {
        public ProductReasonCode GetProductReasonCode();
        public ProductReasonCode GetProductReasonCodeforState(string stateName);
        public int UpdateReasonCode(int RowID, int Isactive);
    }
}
