using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    // [NotMapped]
    public class LoginModel
    {


        [Required(ErrorMessage = "User Name is required.")]

        public string UserId { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
    }

