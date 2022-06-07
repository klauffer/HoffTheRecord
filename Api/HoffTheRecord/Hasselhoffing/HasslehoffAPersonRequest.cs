using Domain.Hasselhoffing.HasslehoffAPerson;

namespace API.Hasselhoffing
{
    public class HasslehoffAPersonRequest
    {
        public string PersonThatCommittedTheOffense { get; set; }


        public Command ToCommand() => new Command(PersonThatCommittedTheOffense);
    }
}
