using FluentValidation;
using MediatR;
using static Domain.Hasselhoffing.ACoworker.ICreateAHasslehoffRecord;

namespace Domain.Hasselhoffing.ACoworker
{
    public class HasselhoffingACoworkerHandler
    {
        public class Validator : AbstractValidator<HasselhoffingACoworkerCommand>
        {
            public Validator()
            {
                RuleFor(m => m.PersonThatCommittedTheOffense).NotEmpty();
                RuleFor(m => m.PersonThatWasHoffed).NotEmpty();
                RuleFor(m => m.ImageUrl).NotEmpty();
            }
        }

        public record HasselhoffingACoworkerCommand(
            string PersonThatCommittedTheOffense,
            string PersonThatWasHoffed,
            string ImageUrl) : IRequest<Result<int>>
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
                int HasslehoffId = await SaveHasslehoffing(request, cancellationToken);
                Result<int> result = new Result<int>.Success(HasslehoffId);

                return result;
            }

            private async Task<int> SaveHasslehoffing(HasselhoffingACoworkerCommand request, CancellationToken cancellationToken)
            {
                var createAHasslehoffRecordArguements = new CreateAHasslehoffRecordArguements(
                                    request.PersonThatCommittedTheOffense,
                                    request.PersonThatWasHoffed,
                                    request.ImageUrl);
                var HasslehoffId = await _createAHasslehoffRecord.Execute(createAHasslehoffRecordArguements, cancellationToken);
                return HasslehoffId;
            }
        }

    }
}
