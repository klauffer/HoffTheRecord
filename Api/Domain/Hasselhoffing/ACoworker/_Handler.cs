using Domain.UniversalDateTime;
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
                RuleFor(m => m.PersonThatWasHoffed).NotEmpty();
                RuleFor(m => m.ImageUrl).NotEmpty();
            }
        }

        public record HasselhoffingACoworkerCommand(
            string PersonThatCommittedTheOffense,
            string PersonThatWasHoffed,
            string ImageUrl) : IRequest<HasselhoffingACoworkerResponse>
        {
        }

        public record HasselhoffingACoworkerResponse
        {
            public int Id { get; private set; }
            public string PersonThatCommittedTheOffense { get; }
            public string PersonThatWasHoffed { get; }
            public string ImageUrl { get; }
            public DateTime TimeOfTheHoffing { get; }

            public HasselhoffingACoworkerResponse(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl, DateTime timeOfTheHoffing)
            {
                PersonThatCommittedTheOffense = personThatCommittedTheOffense;
                PersonThatWasHoffed = personThatWasHoffed;
                ImageUrl = imageUrl;
                TimeOfTheHoffing = timeOfTheHoffing;
            }

            internal void SetId(int id) => Id = id;
        }

        public class CommandHandler : IRequestHandler<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>
        {
            private readonly IDateTimeProvider _dateTimeProvider;
            private readonly IGetWhenAUserWasLastHoffed _getWhenAUserWasLastHoffed;

            public CommandHandler(
                IDateTimeProvider dateTimeProvider,
                IGetWhenAUserWasLastHoffed getWhenAUserWasLastHoffed)
            {
                _dateTimeProvider = dateTimeProvider;
                _getWhenAUserWasLastHoffed = getWhenAUserWasLastHoffed;
            }

            async Task<HasselhoffingACoworkerResponse> IRequestHandler<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>.Handle(HasselhoffingACoworkerCommand command, CancellationToken cancellationToken)
            {
                await ValidateSystemCanAcceptCommand(command);
                var response = new HasselhoffingACoworkerResponse(
                    command.PersonThatCommittedTheOffense,
                    command.PersonThatWasHoffed,
                    command.ImageUrl,
                    _dateTimeProvider.UtcNow);

                return response;
            }

            private async Task ValidateSystemCanAcceptCommand(HasselhoffingACoworkerCommand command)
            {
                await HasEnoughTimePassedSinceLastHoffing(command.PersonThatWasHoffed);
            }

            private async Task HasEnoughTimePassedSinceLastHoffing(string PersonThatWasHoffed)
            {
                var timeOfLastHoffing = await _getWhenAUserWasLastHoffed.Query(PersonThatWasHoffed);
                if (timeOfLastHoffing.AddMinutes(1) >= _dateTimeProvider.UtcNow)
                {
                    var passedTimeSinceHoffing = _dateTimeProvider.UtcNow - timeOfLastHoffing;
                    throw new DomainException(
                        "{0} was Hoffed {1} seconds ago. Can you give them a minute!?",
                        PersonThatWasHoffed,
                        passedTimeSinceHoffing.TotalSeconds);
                }
            }
        }
    }
}
