using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace smb_om.Repository
{
    public class NotificationRepository : INotificationUrl
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public NotificationRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public NotificationUrl GetNotificationUrl(string ordernumber)
        {
            NotificationUrl notificationurl = new NotificationUrl();
            try
            {
                SqlCommand cmd = new SqlCommand("GetNotificationUrl");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ordernumber", ordernumber);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        notificationurl.Request_Xml = Convert.ToString(dr["Request_Response_Xml"]);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

          if(!string.IsNullOrEmpty(notificationurl.Request_Xml))
            {

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(notificationurl.Request_Xml);
                //   var nd = xml.Attributes["notificationUrl"];
                //  var v = xml.Descendants().FirstOrDefault(x => x.Name.LocalName == "primaryNpaNxx").Value;
                //           XElement root = XElement.Load(notificationurl.Request_Xml);
                //           IEnumerable<XElement> address =
                //from el in root.Elements("Notification")
                //where (string)el.Attribute("Type") == "notificationUrl"
                //select el;
                //           notificationurl.Request_Xml =Convert.ToString( address.FirstOrDefault());
                notificationurl.Request_Xml = "https://indirectwlp.activationnow.com/gateway/gw";
            }
           
            return notificationurl;

        }
    }
}
