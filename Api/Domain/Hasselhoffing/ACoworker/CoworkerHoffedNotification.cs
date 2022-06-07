using MediatR;

namespace Domain.Hasselhoffing.ACoworker
{
    internal class CoworkerHoffedNotification : INotification
    {
        public CoworkerHoffedNotification(string personThatCommittedTheOffense)
        {
            PersonThatCommittedTheOffense = personThatCommittedTheOffense;
        }

        public string PersonThatCommittedTheOffense { get; set; }
    }
}
