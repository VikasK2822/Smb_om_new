using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class ChangePasswordModel
    {

        [Key]
        [Required(ErrorMessage = "Login Id is required.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password should be minimum 8 to 16 charaters long")]
        [MaxLength(16, ErrorMessage = "Password should be minimum 8 to 16 charaters long")]
        //   [[RegularExpression(("^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z])(.{8,15})$")]
        // [RegularExpression("@^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z])(.{8,15})$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        //   [RegularExpression(@"^\d{1,15}$", ErrorMessage = "Please enter up to 15 digits for a contact number")]
                            
              [RegularExpression(@"(?=^.{8,16}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password should have atleast one lowercase | atleast one uppercase, should have atleast one number, should have atleast one special character")]
      //  [RegularExpression(@"^(?=.*[a-z])|(?=.*[A-Z])|(?=.*[0-9])|(?=.*[@#$%])$", ErrorMessage = "Password should have atleast one lowercase | atleast one uppercase, should have atleast one number, should have atleast one special character")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
       
        public string ConfirmPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Old Password is required.")]
        public string OldPassword { get; set; }
    }
}
