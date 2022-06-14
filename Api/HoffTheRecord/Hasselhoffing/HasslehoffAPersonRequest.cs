using System.Text.Json.Serialization;
using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;

namespace API.Hasselhoffing
{
    public class HasslehoffACoworkerRequest
    {
        public string PersonThatCommittedTheOffense { get; }
        public string PersonThatWasHoffed { get; }
        public string ImageUrl { get; }


        [JsonConstructor]
        public HasslehoffACoworkerRequest(
            string personThatCommittedTheOffense,
            string personThatWasHoffed,
            string imageUrl)
        {
            PersonThatCommittedTheOffense = personThatCommittedTheOffense;
            PersonThatWasHoffed = personThatWasHoffed;
            ImageUrl = imageUrl;
        }

        public HasselhoffingACoworkerCommand ToCommand() => new HasselhoffingACoworkerCommand(
            PersonThatCommittedTheOffense,
            PersonThatWasHoffed,
            ImageUrl);
    }
}
