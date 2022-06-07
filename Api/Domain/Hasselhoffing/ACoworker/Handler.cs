using MediatR;

namespace Domain.Hasselhoffing.ACoworker
{
    public class HasselhoffingACoworkerHandler
    {
        public record HasselhoffingACoworkerCommand(string PersonThatCommittedTheOffense) : IRequest<Result<int>>
        {
        }

        public class CommandHandler : IRequestHandler<HasselhoffingACoworkerCommand, Result<int>>
        {
            private readonly ICreateAHasslehoffRecord _createAHasslehoffRecord;

            public CommandHandler(ICreateAHasslehoffRecord createAHasslehoffRecord)
            {
                _createAHasslehoffRecord = createAHasslehoffRecord;
            }

            async Task<Result<int>> IRequestHandler<HasselhoffingACoworkerCommand, Result<int>>.Handle(HasselhoffingACoworkerCommand request, CancellationToken cancellationToken)
            {
                var id = await _createAHasslehoffRecord.Execute(request.PersonThatCommittedTheOffense);
                Result<int> result = new Result<int>.Success(id);
                return result;
            }
        }

    }
}
