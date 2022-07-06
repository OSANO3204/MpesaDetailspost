using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppService.Core.ViewModel
{
  public   class MpesaTransactionViewModel
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string RecieverFullName { get; set; }
        public string ReceiverMobile { get; set; }
        public string SenderPaybill { get; set; }
        public string Narration { get; set; }

    }
}
