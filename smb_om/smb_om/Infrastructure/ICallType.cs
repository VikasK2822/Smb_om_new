using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
    public interface ICallType
    {
        public CallTypeModel GetCalltype();
        CallTypeModel GetCalltypeReasonName(int CalltypeID);
        public int UpdateCalltypeReasonName(int CallReasonID, string CallreasonName, int IsActive);

        public int InsertCalltypeReasonName(int CallTypeID, string CallreasonName, int IsActive, string userid);
    }
}
