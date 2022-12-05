using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace smb_om.Model
{
    public class notificationcancel
    {
        public string NotificationCancel(int NoOrderReturn, string timestamp,string custname,string fname, string orderstate, bool orderterminalststus, string affilliatenumber, string transid, string affname, string partname, string acctno,string prdname,string prdcode,string prdtypevoip, string sellerrequested, string reasoncode,string statname,string stateid,string phno1, string phno2, string phno3, string phno4,string prdname1 ,string prdcode1, string prdtypeinternet, string sellerrequested1, string reasoncode1, string statname1, string stateid1)
        {
            StringBuilder sb = new StringBuilder();
          //  sb.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            sb.Append(@"<OrderStatusNotification xmlns:ind=""http://www.synchronoss.com/indirect/IndirectOrderCommonTypesV6.00.xsd"" xmlns=""http://www.synchronoss.com/indirect/OrderStatusNotificationV6.00.xsd"">");
            sb.Append("<Header numberOfOrdersReturned = \"" + NoOrderReturn + "\" timeStamp = \"" +timestamp+ "\" />");
            sb.Append("<ReturnedOrders>");
            sb.Append("<ReturnedOrder customerLastName=\"" + custname + "\" customerFirstName=\"" + fname + "\" orderState=\"" + orderstate + "\" orderTerminalStatus=\"" + orderterminalststus + "\" affiliateOrderNumber=\"" + affilliatenumber + "\" transactionId=\"" + transid + "\">");
            sb.Append("<Partner affiliateName=\""+affname+"\" name=\"" +partname+ "\" />");
            sb.Append("<AgentNotes/>");
            sb.Append("<ProductsOrdered>");
            if (!string.IsNullOrEmpty(prdtypevoip))
            {
                sb.Append("<ProductOrdered accountNumber = \"" + acctno + "\" productName = \"" + prdname + "\" productCode = \"" + prdcode + "\"  type=\"" + prdtypevoip + "\" >");
                sb.Append("<ProductStatus reasonName=\"" + sellerrequested + "\" reasonCode=\"" + reasoncode + "\" stateName=\"" + statname + "\" state=\"" + stateid + "\"/>");
                sb.Append("<LinesStatuses>");
                sb.Append("<LineStatus phoneNumber=\"" + phno1 + "\" lineNumber=\"1\"/>");
                if (!string.IsNullOrEmpty(phno2))
                    sb.Append("<LineStatus phoneNumber=\"" + phno2 + "\" lineNumber=\"2\"/>");
                if (!string.IsNullOrEmpty(phno3))
                    sb.Append("<LineStatus phoneNumber=\"" + phno3 + "\" lineNumber=\"3\"/>");
                if (!string.IsNullOrEmpty(phno4))
                    sb.Append("<LineStatus phoneNumber=\"" + phno4 + "\" lineNumber=\"4\"/>");
                sb.Append("</LinesStatuses>");
                sb.Append("</ProductOrdered>");
            }
            if (!string.IsNullOrEmpty(prdtypeinternet))
            {
                sb.Append("<ProductOrdered accountNumber = \"" + acctno + "\" productName = \"" + prdname1 + "\" productCode = \"" + prdcode1 + "\" type = \"" + prdtypeinternet + "\" >");
                sb.Append("<ProductStatus reasonName=\"" + sellerrequested1 + "\" reasonCode=\"" + reasoncode1 + "\" stateName=\"" + statname1 + "\" state=\"" + stateid1 + "\"/>");
                sb.Append("</ProductOrdered>");
            }

            sb.Append("</ProductsOrdered>");
            sb.Append("</ReturnedOrder>");
            sb.Append("</ReturnedOrders>");
            sb.Append("</OrderStatusNotification>");
            return sb.ToString();
        }

        public int callnotificatiourl(string outputxml)
        {
            int iresult = 0;
            XmlDocument xmlSoapRequest = new XmlDocument();
            xmlSoapRequest.LoadXml(outputxml);

            return iresult;

        }


    }

}
