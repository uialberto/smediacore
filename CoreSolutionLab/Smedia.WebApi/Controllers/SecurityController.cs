using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Smedia.WebApi.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.CustomEntities;
using Uibasoft.Smedia.Core.DTOs;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Enumerations;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.Core.QueryFilters;
using Uibasoft.Smedia.Core.Services;
using Uibasoft.Smedia.DataAccess.Interfaces;

namespace Smedia.WebApi.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrador))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _security;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passService;
        public SecurityController(ISecurityService security, IMapper pMapper, IPasswordService passService)
        {
            _security = security ?? throw new ArgumentNullException(nameof(security));
            _mapper = pMapper ?? throw new ArgumentNullException(nameof(pMapper));
            _passService = passService ?? throw new ArgumentNullException(nameof(passService));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);
            var hashPassword = _passService.Hash(security.Password);
            security.Password = hashPassword;
            await _security.RegisterUser(security);
            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}
