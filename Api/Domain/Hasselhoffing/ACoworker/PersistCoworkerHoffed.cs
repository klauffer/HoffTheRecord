using MediatR;
using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;
using static Domain.Hasselhoffing.ACoworker.IInsertAHasslehoffRecord;

namespace Domain.Hasselhoffing.ACoworker
{
    public class PersistCoworkerHoffed : IPipelineBehavior<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>
    {
        private readonly IInsertAHasslehoffRecord _createAHasslehoffRecord;

        public PersistCoworkerHoffed(IInsertAHasslehoffRecord createAHasslehoffRecord)
        {
            _createAHasslehoffRecord = createAHasslehoffRecord;
        }

        public async Task<HasselhoffingACoworkerResponse> Handle(HasselhoffingACoworkerCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<HasselhoffingACoworkerResponse> next)
        {
            var response = await next();
            int HasslehoffId = await PersistRecord(response, cancellationToken);
            response.SetId(HasslehoffId);
            return response;
        }

        private async Task<int> PersistRecord(
            HasselhoffingACoworkerResponse response,
            CancellationToken cancellationToken)
        {
            var createAHasslehoffRecordArguements = new InsertAHasslehoffRecordArguements(
                                                response.PersonThatCommittedTheOffense,
                                                response.PersonThatWasHoffed,
                                                response.ImageUrl,
                                                response.TimeOfTheHoffing);
            var HasslehoffId = await _createAHasslehoffRecord.Execute(createAHasslehoffRecordArguements, cancellationToken);
            return HasslehoffId;
        }
    }
}
