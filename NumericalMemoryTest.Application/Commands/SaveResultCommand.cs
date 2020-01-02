using MediatR;
using NumericalMemoryTest.Infrastructure.Models;
using NumericalMemoryTest.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumericalMemoryTest.Application.Commands
{
    public class SaveResultCommand
    {
        public class Command : IRequest<bool>
        {
            public Result Result { get; }

            public Command(Result result)
            {
                Result = result;
            }
        }
        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly ISaveDataQuery _saveData;

            public Handler(ISaveDataQuery saveDataQuery)
            {
                _saveData = saveDataQuery;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                Random generator = new Random();
                int id = generator.Next(100000, 1000000);

                request.Result.UserId = id;
                try 
                {
                    _saveData.SaveData(request.Result);
                    return true;
                }
                catch
                {
                    return false;
                }                               
            }
        }
    }
}
