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
    public class SpecialProjectTypeRepository : ISpecialProjectType
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public SpecialProjectTypeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public SpecialProjectType GetPartnerAffiliate()
        {
            SpecialProjectType specialProjectType = new SpecialProjectType();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetSpecialProjectType");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<specialprojectN> lstspecialproject = new List<specialprojectN>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        specialprojectN specialprojectN = new specialprojectN();
                        specialprojectN.specialProjectName = Convert.ToString(dr["SpecialProjectName"]);
                        specialprojectN.Rowid = Convert.ToInt32(dr["Row_Id"]);

                        lstspecialproject.Add(specialprojectN);
                    }
                    specialProjectType.specialprojectNs = lstspecialproject;
                }

            }
            catch (Exception)
            {

                throw;
            }

           
            return specialProjectType;

        }

        public int UpdateSpecialProject(string Rowid, string SpecialProjectType, int Isdelete,int IsUpdate)
        {
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateSpecialProjectType");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ProjectName", SpecialProjectType);
                if(Isdelete == 1)
                    cmd.Parameters.AddWithValue("@Isdelete", 1);
                //else
                //    cmd.Parameters.AddWithValue("@Isdelete", null);

                if (IsUpdate == 1)
                    cmd.Parameters.AddWithValue("@Isupdate", 1);
                //else
                //    cmd.Parameters.AddWithValue("@Isupdate", null);
                cmd.Parameters.AddWithValue("@rowid", Rowid);

                iresult = cmd.ExecuteNonQuery();
               

              

            }
            catch (Exception ex)
            {

                throw;
            }


            return iresult;

        }
    }
}
