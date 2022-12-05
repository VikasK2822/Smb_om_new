using Microsoft.AspNetCore.Http;
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
    public class CallTypeRepository : ICallType
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public CallTypeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public CallTypeModel GetCalltype()
        {
            List<CallTypeReason> lstcallTypeReasons = new List<CallTypeReason>();
            CallTypeModel Calltype = new CallTypeModel();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetCallType");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CallTypeReason callTypeReason = new CallTypeReason();
                        callTypeReason.CallType = Convert.ToInt32(dr["CallType_Id"]);
                        callTypeReason.CallTypeName = Convert.ToString(dr["CallTypeName"]);
                        lstcallTypeReasons.Add(callTypeReason);
                     
                    }
                   
                }
                Calltype.callTypeReasons = lstcallTypeReasons;
            }
            catch (Exception ex)
            {

                throw;
            }

            return Calltype;

        }
        public CallTypeModel GetCalltypeReasonName(int CalltypeID)
        {
            CallTypeModel callTypeModel = new CallTypeModel();
            List<CallTypeReasonNAme> Calltypereason = new List<CallTypeReasonNAme>();
            try
            {
                
                SqlCommand cmd = new SqlCommand("Usp_GetCallTypeReasonName");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CalltypeID", CalltypeID);
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CallTypeReasonNAme callTypeReasonnAme = new CallTypeReasonNAme();
                        callTypeReasonnAme.CallReasonId = Convert.ToInt32(dr["CallReasonId"]);
                        callTypeReasonnAme.CallReasonName = Convert.ToString(dr["CallReasonName"]);
                        callTypeReasonnAme.CallReasonIsActive = Convert.ToBoolean(dr["FG_Flag"]);
                        Calltypereason.Add(callTypeReasonnAme);
                    }

                }
                callTypeModel.callTypeReasonNAmes = Calltypereason;

            }
            catch (Exception ex)
            {

                throw;
            }

            return callTypeModel;

        }

        public int UpdateCalltypeReasonName(int CallReasonID, string CallreasonName, int IsActive)
        {
            int Iresult = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("Usp_UpdateCallReason");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CallReasonId", CallReasonID);
                cmd.Parameters.AddWithValue("@callReasonName", CallreasonName);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Connection = con;
                Iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return Iresult;

        }

        public int InsertCalltypeReasonName(int CallTypeID, string CallreasonName, int IsActive,string userid)
        {
            int Iresult = 0;
            try
            {
               
                SqlCommand cmd = new SqlCommand("Usp_InsertCallReason");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CallTypeID", CallTypeID);
                cmd.Parameters.AddWithValue("@callReasonName", CallreasonName);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@userID", userid);
                cmd.Connection = con;
                Iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return Iresult;

        }

    }
}
