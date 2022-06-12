namespace Domain.Hasselhoffing.ACoworker
{
    public interface ICreateAHasslehoffRecord
    {
        public class CreateAHasslehoffRecordArguements
        {
            public string PersonThatCommittedTheOffense { get; }
            public string PersonThatWasHoffed { get; set; }
            public string ImageUrl { get; set; }

            public CreateAHasslehoffRecordArguements(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl)
            {
                PersonThatCommittedTheOffense = personThatCommittedTheOffense;
                PersonThatWasHoffed = personThatWasHoffed;
                ImageUrl = imageUrl;
            }

            
        }

        Task<int> Execute(
            CreateAHasslehoffRecordArguements arguements,
            CancellationToken cancellationToken = default);
    }
}
