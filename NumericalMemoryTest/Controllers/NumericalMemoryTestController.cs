using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NumericalMemoryTest.Application.Commands;

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
        #region Post
        [Route("GetNumbers")]
        public async Task<IList<int>> GetNumbers()
        {
            return await _mediator.Send(new GetNumberCommand.Command());
        }
        #endregion
    }
}