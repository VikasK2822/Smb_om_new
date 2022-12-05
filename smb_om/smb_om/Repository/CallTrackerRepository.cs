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
    public class CallTrackerRepository: ICallTracker
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public CallTrackerRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public string Insert_Edit_Delete_Out(SqlCommand cmd)
        {
            string message = string.Empty;
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                message = (string)cmd.Parameters["@ERROR"].Value;
                con.Close();
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public int InsertCallTracker(CallTrackerModel callTrackerinput, string UserId)  
        {
            int recordeffected = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("usp_insert_call_details");
                cmd.Parameters.AddWithValue("@Request_Number", callTrackerinput.RequestNumber);
                cmd.Parameters.AddWithValue("@Call_StartTime", callTrackerinput.CallStartTime);
                cmd.Parameters.AddWithValue("@Call_EndTime", callTrackerinput.CallEndTime);
                cmd.Parameters.AddWithValue("@Caller_FirstName", callTrackerinput.Caller_First_Name);
                cmd.Parameters.AddWithValue("@Caller_LastName", callTrackerinput.Caller_Last_Name);
                cmd.Parameters.AddWithValue("@Caller_Contact_TN", callTrackerinput.Caller_Contact_TN);
                cmd.Parameters.AddWithValue("@Order_Number", callTrackerinput.Order_Number);
                cmd.Parameters.AddWithValue("@Call_Type", callTrackerinput.CallTypeId);
                cmd.Parameters.AddWithValue("@Call_Reason", callTrackerinput.CallReasonId);
                cmd.Parameters.AddWithValue("@Call_Disposition", callTrackerinput.CallDispositionId);
                cmd.Parameters.AddWithValue("@Call_Comments", callTrackerinput.Call_Comments);
                cmd.Parameters.AddWithValue("@Created_by", UserId);

                SqlConnection con = new SqlConnection(conn);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                recordeffected = cmd.ExecuteNonQuery();
               
                con.Close();
                
            }
            catch (Exception ex)
            {

                throw;
            }

            return recordeffected;
        }
        public string GetRecentRequestNumber()
        {
            string RecentRequestNumber = "";
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getRecentRequestNumber");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    RecentRequestNumber = Convert.ToString(ds.Tables[0].Rows[0]["RecentRequestNumber"]);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return RecentRequestNumber;
        }
        public List<CallType> GetCallTypes()    
        {
            List<CallType> callTypes = new List<CallType>();      
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
                            CallType _callType = new CallType();
                        _callType.CallTypeId = Convert.ToString(dr["CallType_Id"]);
                        _callType.CallTypeName = Convert.ToString(dr["CallTypeName"]);

                        callTypes.Add(_callType);
                        }
                    }

            }
            catch (Exception)
            {

                throw;
            }
            return callTypes;
        }
        public List<CallReasonType> GetCallReasonByCallTypId(string CallTypId)
        {
            List<CallReasonType> callReasonTypes = new List<CallReasonType>();
            try
            {
                if (!string.IsNullOrEmpty(CallTypId))
                {

                    SqlCommand cmd = new SqlCommand("usp_GetCallReasonByCallTypId");
                    cmd.Parameters.AddWithValue("@CallTypId", CallTypId);
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
                            CallReasonType _callReasonType = new CallReasonType();  
                            _callReasonType.CallReasonId= Convert.ToString(dr["CallReasonId"]);
                            _callReasonType.CallReasonName = Convert.ToString(dr["CallReasonName"]);

                            callReasonTypes.Add(_callReasonType);
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return callReasonTypes;
        }
        public List<CallDispositionType> GetCallDispositionById(string CallReasonId)
        {
            List<CallDispositionType> callDispositionTypes = new List<CallDispositionType>();
            try
            {
                if (!string.IsNullOrEmpty(CallReasonId))
                {

                    SqlCommand cmd = new SqlCommand("usp_GetCalldispositionByCallReasonId");
                    cmd.Parameters.AddWithValue("@CallReasonId", CallReasonId);
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
                            CallDispositionType _callDispositionType = new CallDispositionType();
                            _callDispositionType.DispositionTypeId = Convert.ToString(dr["Disposition_Id"]);
                            _callDispositionType.CallDispositionName = Convert.ToString(dr["DispositionName"]);

                            callDispositionTypes.Add(_callDispositionType);
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return callDispositionTypes;

        }
    }
}
