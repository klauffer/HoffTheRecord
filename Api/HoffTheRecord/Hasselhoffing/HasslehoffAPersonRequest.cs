using Domain.Hasselhoffing.ACoworker;
using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;

namespace API.Hasselhoffing
{
    public class HasslehoffACoworkerRequest
    {
        public string PersonThatCommittedTheOffense { get; set; }


        public HasselhoffingACoworkerCommand ToCommand() => new HasselhoffingACoworkerCommand(PersonThatCommittedTheOffense);
    }
}
