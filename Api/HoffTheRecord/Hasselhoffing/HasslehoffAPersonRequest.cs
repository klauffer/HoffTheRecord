using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;

namespace API.Hasselhoffing
{
    public class HasslehoffACoworkerRequest
    {
        public string PersonThatCommittedTheOffense { get; set; }
        public string PersonThatWasHoffed { get; set; }
        public string ImageUrl { get; set; }


        public HasselhoffingACoworkerCommand ToCommand() => new HasselhoffingACoworkerCommand(
            PersonThatCommittedTheOffense,
            PersonThatWasHoffed,
            ImageUrl);
    }
}
