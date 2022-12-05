using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model  
{
    public class MlpModel
    {
       public List<Product_type> product_Types { get; set; }

    }

    public class Product_type
    {
     public List<PartnerQueue> PartnerDaysOrder { get; set; }
     public string OldestOrderQuene { get; set; }
     public string TotalnoOrders { get; set; }
     public string ProductName { get; set; }
     public string SLA_Color { get; set; }      

    }
    public class PartnerQueue   
    {
        public string PartnerText { get; set; }        
        public string PartnerValue { get; set; }    

    }

    public class Order_product_partner
    {
        public string ProductName { get; set; }
        public string PatnerName { get; set; }
        public DateTimeOffset OrderDate { get; set; }




    }

    [Table("tbl_order_master", Schema = "dbo")]
    public class OrderMaster
    {
        [Key]
        public string TransactionId { get; set; }
        public string PartnerId { get; set; }
        public string Affiliate_Name { get; set; }
        public string Order_Number { get; set; }
        public string UserId { get; set; }
        public string Order_Type { get; set; }
        public string Note { get; set; }
        public float One_Time_Charges { get; set; }
        public float Monthly_Charges { get; set; }
        public float Total_Fee { get; set; }
        public string Payment_Required { get; set; }
        public bool FG_Flag { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }
        public DateTimeOffset Locked_Timestamp { get; set; }
        public string Locked_User_Id { get; set; }
        public int Order_lockedStatus { get; set; }

        public int Order_WorkStatus { get; set; }


    }
  
    [Table("tbl_products_information", Schema = "dbo")]
    public class productInformation
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string Product_Type { get; set; }
        public string Product_Name { get; set; }
        public string Order_Number { get; set; }
        public string Product_Code { get; set; }
        public string Product_Seq { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }
        public float Rack_Rate { get; set; }
        public float Bundle_Rack_Rate { get; set; }
        public float Download_Speed { get; set; }
        public string Download_Unit { get; set; }
        public string Upload_Unit { get; set; }
       public int Upload_Speed { get; set; }
        public string Feature { get; set; }
        public string Extention { get; set; }
        public string bolt_On_Indicator { get; set; }
        public int FG_Flag { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }
      
        public string Locked_User_Id { get; set; }
        public int Order_lockedStatus { get; set; }

        public int Order_WorkStatus { get; set; }
       
    }

    [Table("tbl_partner_master", Schema = "dbo")]
    public class partner
    {
        public string PartnerId { get; set; }
        public string Partner_Name { get; set; }
        public bool FG_Flag { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }

    }
}
