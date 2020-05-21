using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using WebApp.RestfulAPI.Models;
using WebApp.Services;
using WebApp.DataTransferObjects;
using System;

namespace WebApp.RestfulAPI.Controllers
{
    [Produces("application/json")]
    [Route("web/api-security")]
    public class SecurityController : Controller
    {
        private readonly ISecurityManagerService _securityManagerService;

        public SecurityController(ISecurityManagerService securityManagerService)
        {
            _securityManagerService = securityManagerService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]AppUserSingle appUserSingle)
        {
            IActionResult ret = null;
            var auth = _securityManagerService.GetUserWithClaims(appUserSingle).Result;

            if (auth != null)
            {
                ret = StatusCode(StatusCodes.Status200OK, auth);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound,
                                 "Invalido usuario o password.");
            }
            return ret;
        }

        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(Guid id)
        {
            IActionResult ret = null;
            var appUserSingle = _securityManagerService.GetUser(id).Result;

            if (appUserSingle != null)
            {
                ret = StatusCode(StatusCodes.Status200OK, appUserSingle);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound,
                                 "Error Interno API");
            }
            return ret;
        }

    }
}