namespace Domain.Hasselhoffing.ACoworker
{
    public interface IGetWhenAUserWasLastHoffed
    {
        Task<DateTime> Query(string PersonThatWasHoffed);
    }
}
