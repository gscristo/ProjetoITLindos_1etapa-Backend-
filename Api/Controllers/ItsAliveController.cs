using Api.Consts;
using Api.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [AllowAnonymous]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = AuthorizationPolicies.RequiresManager)]
    [Route("api/[controller]")]
    [ApiController]
    public class ItsAliveController : ControllerBase
    {
        IConfiguration _configuration;

        public ItsAliveController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<Result> Get()
        {
            var content = new
            {
                ServerCulture = CultureInfo.CurrentCulture.DisplayName,
                ApplicationStatus = $"Application is running. [Lean Learning] - Environment : {_configuration["ENV_NAME"]}"
            };

            return Result.Create(content, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!");
        }
    }
}
