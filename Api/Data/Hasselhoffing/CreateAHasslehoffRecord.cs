using Domain.Hasselhoffing.ACoworker;

namespace Persistence.Hasselhoffing
{
    internal class CreateAHasslehoffRecord : IInsertAHasslehoffRecord
    {
        private readonly HoffTheRecordContext _context;

        public CreateAHasslehoffRecord(HoffTheRecordContext context)
        {
            _context = context;
        }

        public async Task<int> Execute(IInsertAHasslehoffRecord.InsertAHasslehoffRecordArguements arguements, CancellationToken cancellationToken = default)
        {
            var record = HasslehoffRecord.FromCreateAHasslehoffRecordArguements(arguements);
            _context.Hoffs.Add(record);
            await _context.SaveChangesAsync();
            return record.Id;
        }
    }
}
