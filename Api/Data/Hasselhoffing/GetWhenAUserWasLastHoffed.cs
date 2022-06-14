using Domain.Hasselhoffing.ACoworker;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Hasselhoffing
{
    internal class GetWhenAUserWasLastHoffed : IGetWhenAUserWasLastHoffed
    {
        private readonly HoffTheRecordContext _context;

        public GetWhenAUserWasLastHoffed(HoffTheRecordContext context)
        {
            _context = context;
        }

        public async Task<DateTime> Query(string PersonThatWasHoffed)
        {
            var timeOfTheHoffing = await _context.Hoffs.Where(x => x.PersonThatWasHoffed == PersonThatWasHoffed)
                .OrderByDescending(x => x.TimeOfTheHoffing)
                .Select(x => x.TimeOfTheHoffing)
                .FirstOrDefaultAsync();

            return timeOfTheHoffing;
        }
    }
}
