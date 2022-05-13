using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.ViewModel
{
  public   class MpesaTransactionViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public string TranscationId { get; set; }
    }
}
