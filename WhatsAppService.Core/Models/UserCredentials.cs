using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.Models
{
    public class UserCredentials
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType((DataType.EmailAddress),ErrorMessage ="Username must be added in the correct format")]
        public string UserName { get; set; }

        [Required]  
        [DataType((DataType.Password), ErrorMessage =" Enter password correctly")]
        public string Password { get; set; }
    }
}
