using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace smb_om.Repository
{
    public class EmailRepository : Iemail
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public EmailRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public int sendmail(string to, string from, string subject, string body, string mailtype, string createdby, string ordernumber)
        {

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("vikas.kumar2822@sequentialtech.com");
                mailMessage.Subject = subject;

                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("vikas.kumar2822@sequentialtech.com"));
                SmtpClient smtp = new SmtpClient();
                //   smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                smtp.Port = 587;
                smtp.Host = "email-smtp.us-east-1.amazonaws.com";
                NetworkCred.UserName = "AKIASQGTFAWZESAPIEUI";
                NetworkCred.Password = "";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                // smtp.Send(mailMessage);

                InsertEmail(to, from, subject, body, mailtype, createdby, ordernumber, 1);
            }

            return 1;
        }

        public int InsertEmail(string to, string from, string subject, string body, string mailtype, string createdby, string ordernumber, int ismailsent = 1)
        {
            int Ismailsent = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_email_Insert");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Ordenumber", ordernumber);
                cmd.Parameters.AddWithValue("@mailSubject", subject);
                cmd.Parameters.AddWithValue("@mailFrom", from);
                cmd.Parameters.AddWithValue("@mailto", to);
                cmd.Parameters.AddWithValue("@mailBody", body);
                cmd.Parameters.AddWithValue("@ISmailSent", ismailsent);
                cmd.Parameters.AddWithValue("@createdby", createdby);
                cmd.Parameters.AddWithValue("@mailtype", mailtype);
                Ismailsent = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {

            }
            return ismailsent;
        }

    }
}
