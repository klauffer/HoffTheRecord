namespace Domain.Hasselhoffing.ACoworker
{
    public interface ICreateAHasslehoffRecord
    {
        Task<int> Execute(string PersonThatCommittedTheOffense, CancellationToken cancellationToken = default);
    }
}
