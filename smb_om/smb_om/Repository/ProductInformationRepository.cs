using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Repository
{
    public class ProductInformationRepository : IproductInformation
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public ProductInformationRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public List<ProductInformation> GetProductInformation(string orderuber)
        {
            List<ProductInformation> lstproductInformation = new List<ProductInformation>();
           
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductInformation");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Ordernumber", orderuber);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductInformation productInformation = new ProductInformation();
                        productInformation.ordernumber = Convert.ToString(dr["Order_Number"]);
                        productInformation.productCode = Convert.ToString(dr["Product_Code"]);
                        productInformation.productName = Convert.ToString(dr["Product_Name"]);
                        productInformation.producttype = Convert.ToString(dr["Product_Type"]);
                        lstproductInformation.Add(productInformation);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

           
            return lstproductInformation;

        }
    }
}
