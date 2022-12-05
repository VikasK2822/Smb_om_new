using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    

    public class PartnerModel
    {
        public List<Affiliate> affiliates { get; set; }
        public List<partner> partners { get; set; }
    }
    
   [Table("tbl_affiliate_master", Schema = "dbo")]
    public class Affiliate
    {
        [Key]
        public int RowId { get; set; }
        public string AffiliateId { get; set; }
        public string PartnerId { get; set; }
        public string Affiliate_Name { get; set; }
        public string Csi_Password { get; set; }
        public string Csi_Username { get; set; }
        public string SMBC_SMB_Affiliate { get; set; }
        public string Sales_Code_West { get; set; }
        public string Sales_Code_East { get; set; }
        public string Sales_Code_Southeast { get; set; }
        public string Sales_Code_Midwest { get; set; }
        public string Sales_Code_Southwest { get; set; }
        public string Sales_Code_Wireless { get; set; }
        public bool FG_Flag { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }
    }
}
