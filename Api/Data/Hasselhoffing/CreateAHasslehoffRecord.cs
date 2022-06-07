using Domain.Hasselhoffing.ACoworker;

namespace Data.Hasselhoffing
{
    internal class CreateAHasslehoffRecord : ICreateAHasslehoffRecord
    {
        private readonly HoffTheRecordContext _context;

        public CreateAHasslehoffRecord(HoffTheRecordContext context)
        {
            _context = context;
        }

        public async Task<int> Execute(string PersonThatCommittedTheOffense)
        {
            var record = new HasslehoffRecord(PersonThatCommittedTheOffense);
            _context.Hoffs.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }
    }
}
