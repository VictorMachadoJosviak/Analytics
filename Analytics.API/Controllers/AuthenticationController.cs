using Analytics.API.Controllers.Base;
using Analytics.Core.DTOs;
using Analytics.Core.Interfaces.Services;
using Analytics.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Analytics.API.Controllers
{
    [RoutePrefix("Api/Authentication")]
    public class AuthenticationController : AppBaseController
    {
        private readonly IApplicationUserService appuserService;

        public AuthenticationController(IUnitOfWork _unitOfWork, IApplicationUserService _appuserService)
            : base(_unitOfWork)
        {
            appuserService = _appuserService;
        }

        [Route("Authenticate"), HttpGet]
        public async Task<HttpResponseMessage> AuthenticateUser(string email)
        {
            try
            {
                var dto = new ApplicationUserDTO
                {
                    Email = email
                };
                var auth = appuserService.AuthenticateUser(dto);
                return await ResponseAsync(auth, appuserService);
            }
            catch (Exception ex)
            {
                return ResponseExceptionAsync(ex).Result;
            }
        }
    }
}