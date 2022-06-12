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

        public async Task<int> Execute(ICreateAHasslehoffRecord.CreateAHasslehoffRecordArguements arguements, CancellationToken cancellationToken = default)
        {
            var record = HasslehoffRecord.FromCreateAHasslehoffRecordArguements(arguements);
            _context.Hoffs.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }
    }
}
