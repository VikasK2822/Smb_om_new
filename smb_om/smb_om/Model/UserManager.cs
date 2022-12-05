using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    [Table("tbl_user_manager", Schema = "dbo")]
    public class UserManager
    {
        public int RowId { get; set; }
        [Key]
        [Required(ErrorMessage = "Login Id is required.")]
        [MinLength(8, ErrorMessage = "Login Id should be minimum 8 to 20 charaters long")]
        [MaxLength(20, ErrorMessage = "Login Id should be minimum 8 to 20 charaters long")]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Group_Name { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public int Role_Type { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public bool Account_Lock { get; set; }
        public bool Pass_Never_Expire { get; set; }
        [Required(ErrorMessage = "Max login required")]
        public int Max_Login { get; set; }
        public bool Program { get; set; }

        public int FG_IsLogin { get; set; }
        public string User_Session { get; set; }
        public string Mode { get; set; }
        public string PartnerId { get; set; }
        public string AffiliateId { get; set; }
        public int FG_Flag { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }

        [NotMapped]
        public string Confirm_Password { get; set; }


    }



    [Table("tbl_order_manger_login", Schema = "dbo")]
    public class OrderManagerLogin
    {
      
        [Key]
        [Required(ErrorMessage = "Login Id is required.")]
       
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Old Password is required.")]
        public string OldPassword { get; set; }
        public string Account_lock { get; set; }
        public string Created_By { get; set; }
        public string Updated_by { get; set; }
        public int RoleId { get; set; }
        public bool FG_Flag { get; set; }
        public DateTimeOffset Created_Date { get; set; }
        public DateTimeOffset Updated_Date { get; set; }
      
    }


  
}
