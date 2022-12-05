using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace smb_om.Model
{
    public class NotificationSend
    {
        public int notificationsend(string outputxml, string notificationUrl)
        {
            int iresult = 0;
            XmlDocument xmlSoapRequest = new XmlDocument();
            xmlSoapRequest.LoadXml(outputxml);
            string result;
            try
            {
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(notificationUrl);
                //Content_type  
                Req.ContentType = "text/xml;charset=\"utf-8\"";
                Req.Accept = "text/xml";
                //string SOAPReqBody;
                //HTTP method  
                XmlDocument SOAPReqBody = new XmlDocument();
                Req.Method = "POST";
                //X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                //store.Open(OpenFlags.ReadOnly);
                //X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindBySubjectName, "smb-dev.sequentialtech.net", true);
               // Req.ClientCertificates = collection;

              //  SOAPReqBody.LoadXml(xmlLoad);

                using (Stream stream = Req.GetRequestStream())
                {
                    SOAPReqBody.Save(stream);
                }
                using (WebResponse Serviceres = Req.GetResponse())
                {

                    using (StreamReader responseReader = new StreamReader(Serviceres.GetResponseStream()))
                    {

                        result = responseReader.ReadToEnd();
                        iresult = 1;

                    }


                }
            }
            catch (Exception ex)
            {
                iresult = 0;
            }

            return iresult;

        }
    }
}
