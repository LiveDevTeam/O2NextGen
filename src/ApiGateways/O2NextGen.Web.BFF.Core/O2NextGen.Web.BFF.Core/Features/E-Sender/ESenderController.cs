﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.Web.BFF.Core.Features.E_Sender.Models;
using O2NextGen.Web.BFF.Core.Features.E_Sender.Services;

namespace O2NextGen.Web.BFF.Core.Features.E_Sender
{
    [Route("api/features/e-sender")]
    public class ESenderController : Controller
    {
        private readonly IESenderService _senderService;

        public ESenderController(IESenderService senderService)
        {
            _senderService = senderService;
        }

        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            var result =await _senderService.GetAsync(id, ct);
            return Ok(result);
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] MailRequestViewModel model,
            CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync([FromBody] MailRequestViewModel model, CancellationToken ct)
        {
            var result = await _senderService.AddAsync(model, ct);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = result.Id}, result);
        }

        #endregion

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

