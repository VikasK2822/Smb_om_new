using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
    public interface IDwqCheckInstall   
    {
        public DwqCheckInstallModel GetCheckInstallQueueOrder();
        public string GetDwqCheckInstallOrderId(string productType,string  partnerName,string queueName,string user_id);
    }
}
