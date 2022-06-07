namespace Data.Hasselhoffing
{
    internal sealed class HasslehoffRecord
    {
        public HasslehoffRecord(string personThatCommittedTheOffense)
        {
            PersonThatCommittedTheOffense = personThatCommittedTheOffense;
        }

        public int Id { get; set; }
        public string PersonThatCommittedTheOffense { get; set; }
    }
}
