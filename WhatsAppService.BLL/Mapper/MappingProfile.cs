using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppService.Core.Models;
using WhatsAppService.Core.ViewModel;

namespace WhatsAppService.BLL.Mapper
{
   public  class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<MpesaTransactionViewModel, MpesaTransaction>();
        }
        
    }
}
