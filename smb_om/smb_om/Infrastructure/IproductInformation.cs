using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface IproductInformation
    {
        public List<ProductInformation> GetProductInformation(string orderuber);
    }
}
