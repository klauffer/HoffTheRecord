namespace Domain.Hasselhoffing.ACoworker
{
    public interface IInsertAHasslehoffRecord
    {
        public class InsertAHasslehoffRecordArguements
        {
            public string PersonThatCommittedTheOffense { get; }
            public string PersonThatWasHoffed { get; set; }
            public string ImageUrl { get; set; }

            public InsertAHasslehoffRecordArguements(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl)
            {
                PersonThatCommittedTheOffense = personThatCommittedTheOffense;
                PersonThatWasHoffed = personThatWasHoffed;
                ImageUrl = imageUrl;
            }

            
        }

        Task<int> Execute(
            InsertAHasslehoffRecordArguements arguements,
            CancellationToken cancellationToken = default);
    }
}
