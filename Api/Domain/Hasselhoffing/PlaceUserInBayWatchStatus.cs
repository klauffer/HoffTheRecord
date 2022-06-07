using Domain.Hasselhoffing.ACoworker;
using MediatR;

namespace Domain.Hasselhoffing
{
    internal class PlaceUserInBayWatchStatus : INotificationHandler<CoworkerHoffedNotification>
    {
        public Task Handle(CoworkerHoffedNotification notification, CancellationToken cancellationToken)
        {
            // do stuff

            return Task.CompletedTask;
        }
    }
}
