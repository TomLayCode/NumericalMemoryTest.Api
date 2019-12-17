using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace NumericalMemoryTest.Api.Controllers
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

        //public Task<int> GetNumber(ReturnObject Iteration)
        //{
        //    throw new NotImplementedException();
        //}

    }
}