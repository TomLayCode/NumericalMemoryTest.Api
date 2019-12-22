using MediatR;
using NumericalMemoryTest.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NumericalMemoryTest.Application.Commands.GetNumberCommand;

namespace NumericalMemoryTest.Application.Commands
{
    public class GetNumberCommand 
    {
        public class Command : IRequest<IList<int>> 
        {
        }
        public class Handler : IRequestHandler<Command, IList<int>>
        {
            IGenerateNumbersService _generateNumbersService;
            public Handler(IGenerateNumbersService generateNumbersService)
            {
                _generateNumbersService = generateNumbersService;
            }

            public async Task<IList<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                return _generateNumbersService.GenerateNumbers();
            }
        }
    }
}
