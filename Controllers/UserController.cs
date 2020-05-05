using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTAuthenticateConsumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpPost("getname1")]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
                return "Invalid";
        }

        [Authorize]
        [HttpPost("getname2")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var id = claims.Where(p => p.Type == "Id").FirstOrDefault()?.Value;
                return new
                {
                    data = id
                };
            }

            return null;
        }
    }
}
