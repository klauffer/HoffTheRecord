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

            public HasselhoffingACoworkerResponse(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl)
            {
                PersonThatCommittedTheOffense = personThatCommittedTheOffense;
                PersonThatWasHoffed = personThatWasHoffed;
                ImageUrl = imageUrl;
            }

            internal void SetId(int id) => Id = id;
        }

        public class CommandHandler : IRequestHandler<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>
        {

            async Task<HasselhoffingACoworkerResponse> IRequestHandler<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>.Handle(HasselhoffingACoworkerCommand request, CancellationToken cancellationToken)
            {
                var response = new HasselhoffingACoworkerResponse(
                    request.PersonThatCommittedTheOffense,
                    request.PersonThatWasHoffed,
                    request.ImageUrl);

                return response;
            }
        }

    }
}
