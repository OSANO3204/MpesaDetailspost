using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppService.BLL.Data;
using WhatsAppService.BLL.Iservices;
using WhatsAppService.Core.Models;

namespace WhatsAppService.BLL.Services
{
    public class UserAccountServices
    {
        private readonly WhatsAppServiceContext _context;
        private readonly JwtSetting _settings;

        public UserAccountServices(
                WhatsAppServiceContext context,
                IOptions<JwtSetting> options
                    )
        {
            _context = context;
            _settings = options.Value;


        }

        //public async Task<UsersData>   CreateUsers(UsersData addeduser)
        //{
        //    var getusername = addeduser.Email;
        //    var checktransaction = _context.users.Where(x => x.Email == getusername).FirstOrDefault();
        //    try
        //    {
        //        if (!(checktransaction == null))
        //        {
                    


        //        }
        //        else
        //        {
        //            await _context.users.AddAsync(addeduser);
        //            await _context.SaveChangesAsync();
        //            return addeduser;
        //        }
                   
        //    }
           

        //    catch (Exception e)
        //    {
        //        return e;
        //    }
        //}



    }
}
