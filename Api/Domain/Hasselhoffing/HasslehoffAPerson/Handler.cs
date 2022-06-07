using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Hasselhoffing.HasslehoffAPerson
{
    public record Command(string PersonThatCommittedTheOffense) : IRequest<Result<int>>
    {
    }

    public class Handler
    {


        public class CommandHandler : IRequestHandler<Command, Result<int>>
        {
            Task<Result<int>> IRequestHandler<Command, Result<int>>.Handle(Command request, CancellationToken cancellationToken)
            {
                Result<int> result = new Result<int>.Success(0);
                return Task.FromResult(result);
            }
        }

    }
}
