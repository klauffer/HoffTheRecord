namespace Domain.Hasselhoffing.ACoworker
{
    public interface IInsertAHasslehoffRecord
    {
        public class InsertAHasslehoffRecordArguements
        {
            public string PersonThatCommittedTheOffense { get; }
            public string PersonThatWasHoffed { get; }
            public string ImageUrl { get; }
            public DateTime TimeOfTheHoffing { get; }

            public InsertAHasslehoffRecordArguements(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl, DateTime timeOfTheHoffing)
            {
                PersonThatCommittedTheOffense = personThatCommittedTheOffense;
                PersonThatWasHoffed = personThatWasHoffed;
                ImageUrl = imageUrl;
                TimeOfTheHoffing = timeOfTheHoffing;
            }


        }

        Task<int> Execute(
            InsertAHasslehoffRecordArguements arguements,
            CancellationToken cancellationToken = default);
    }
}
