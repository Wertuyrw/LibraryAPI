﻿using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService, IAccountService accountService)
        {
            _authenticationService = authenticationService;
            _accountService = accountService;
        }

        [HttpGet("sign-in")]
        [SwaggerOperation(Summary = "Authorize", Description = "Authorize and receive a token for access")]
        [SwaggerResponse(200, "Return a token")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Account not found")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> GetToken([FromQuery] AccountDTO accountDto,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var token = await _authenticationService.GetAccountTokenAsync(accountDto, cancellationToken);

            return Ok(token);
        }

        [HttpPost("sign-up")]
        [SwaggerOperation(Summary = "Registration", Description = "Registration in the service")]
        [SwaggerResponse(200, "The registration was a success.")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "If there is an internal server error")]
        public async Task<IActionResult> RegisterAccount([FromQuery] AccountDTO accountDto,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var account = await _accountService.RegisterAccountAsync(accountDto, cancellationToken);

            return Ok();
        }
    }
}
