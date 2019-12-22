using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using NumericalMemoryTest.Application.Commands;
using NumericalMemoryTest.Infrastructure.Configuration;

namespace NumericalMemoryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumericalMemoryTestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NumericalMemoryTestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region GET
        [Route("GetNumbers")]
        public async Task<IList<int>> GetNumbers()
        {
            return await _mediator.Send(new GetNumberCommand.Command());
        }

        [Route("GetSettings")]
        public async Task<string> GetSettings()
        {
            return new JavaScriptSerializer().Serialize(new Settings());
        }
        #endregion
    }
}