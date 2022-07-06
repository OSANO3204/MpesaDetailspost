using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.Models
{
    public class MpesaTransaction
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string RecieverFullName { get; set; }
        public string ReceiverMobile { get; set; }
        public string Narration { get; set; }
        public string SenderPaybill { get; set; }

       // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
       // ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
