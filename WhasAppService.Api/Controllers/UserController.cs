using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppService.BLL.Data;
using WhatsAppService.Core.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace WhasAppService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WhatsAppServiceContext _context;
        private readonly JwtSetting _settings;

        public object Encording { get; private set; }

        public UserController(
            WhatsAppServiceContext context,
            IOptions<JwtSetting>  options
            )
        {
            _context = context;
            _settings = options.Value;


        }
       
        [Route("RegisterUsers")]
        [HttpPost]
        public async  Task<IActionResult> RegisterUsers(UsersData addeduser)
        {
            var getusername = addeduser.Email;
            var checktransaction =  _context.users.Where(x=>x.Email==getusername).FirstOrDefault();
            try
            {
                if (!(checktransaction==null))
                {
                    return BadRequest("This user  Email alredy exists");
                }
                else
                {
                    await _context.users.AddAsync(addeduser);
                    await _context.SaveChangesAsync();
                    return Ok(addeduser);
                }
            }
            catch(Exception e)
            {
                return BadRequest();
            }

            

        }

        
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials user)
        {
            var _user = _context.users.FirstOrDefault(x => x.Email == user.UserName && x.Password == user.Password);
                
                if (_user == null)
                {
                    return Unauthorized();
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(_settings.securityKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(

                         new Claim[]
                         {
                             new Claim(ClaimTypes.NameIdentifier, _user.Email)
                         }
                        ),
                    Expires = DateTime.Now.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                    {

                    }
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var finaltoken = tokenHandler.WriteToken(token);

                return Ok("Token: "+finaltoken);
            }
        }

    }

