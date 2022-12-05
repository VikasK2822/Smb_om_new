using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
  public interface Imlp
    {
        public MlpModel GetOrderMlp();
        public string GetSmbOrderId(string Product_Type, string Partner_Name,string User_Id);
    }
}
