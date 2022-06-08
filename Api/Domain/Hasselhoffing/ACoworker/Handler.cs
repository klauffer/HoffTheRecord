using FluentValidation;
using MediatR;

namespace Domain.Hasselhoffing.ACoworker
{
    public class HasselhoffingACoworkerHandler
    {
        public class Validator : AbstractValidator<HasselhoffingACoworkerCommand>
        {
            public Validator()
            {
                RuleFor(m => m.PersonThatCommittedTheOffense).NotEmpty();
            }
        }

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
                cancellationToken.ThrowIfCancellationRequested();
                var id = await _createAHasslehoffRecord.Execute(request.PersonThatCommittedTheOffense);
                Result<int> result = new Result<int>.Success(id);
                return result;
            }
        }

    }
}
