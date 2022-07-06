using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.ViewModel
{
    
   public  class RegistrationViewModel
    {

        
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType((DataType.EmailAddress),ErrorMessage ="Email should be in the correct format!")]
        public string Email { get; set; }

        [Required]
        [DataType((DataType.Password), ErrorMessage ="Password should have correct format!")]
         public  string   Password{ get; set; }

        [Required]
        [Compare(nameof(Password),ErrorMessage ="Passwords should match!")]
        public string ConfirmPassword { get; set; }
    }
}
