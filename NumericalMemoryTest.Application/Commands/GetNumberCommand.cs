using MediatR;
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
            public Handler()
            {

            }
            public async Task<IList<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
