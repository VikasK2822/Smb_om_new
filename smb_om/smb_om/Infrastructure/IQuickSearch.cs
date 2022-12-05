using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface IQuickSearch
    {
        public OrderQuickSearch GetOrderSearchDetails(OrderQuickSearch orderQuickSearch);
        public OrderQuickSearch GetOrderCompleteSearchDetails(DetailSearch detailSearch);
        public OrderQuickSearch GetOrderSearchDrp();
        public List<productstate> GetReasonById(string stateID);
    }
}
