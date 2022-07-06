using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.Models
{
  public   class UsersData
    {
        public int Id { get; set; }

        [Required]
        [DataType((DataType.Text), ErrorMessage ="Please Enter your first name correctly ")]
        public string FirstName { get; set; }

        [Required]
        [DataType((DataType.Text), ErrorMessage = "Please Enter your last name correctly ")]
        public string LastName { get; set; }

        [Required]
        [DataType((DataType.EmailAddress), ErrorMessage = "Please Enter your Email correctly ")]
        public string  Email { get; set; }

        [Required]
        [DataType((DataType.Password), ErrorMessage = "Please Enter your password correctly ")]
        public string Password { get; set; }


        [Required]
        [Compare(nameof(Password),ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }

        
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;




    }
}
