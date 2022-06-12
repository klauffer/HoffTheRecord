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
            int HasslehoffId = await PersistRecord(request, cancellationToken);
            response.SetId(HasslehoffId);
            return response;
        }

        private async Task<int> PersistRecord(HasselhoffingACoworkerCommand request, CancellationToken cancellationToken)
        {
            var createAHasslehoffRecordArguements = new InsertAHasslehoffRecordArguements(
                                                request.PersonThatCommittedTheOffense,
                                                request.PersonThatWasHoffed,
                                                request.ImageUrl);
            var HasslehoffId = await _createAHasslehoffRecord.Execute(createAHasslehoffRecordArguements, cancellationToken);
            return HasslehoffId;
        }
    }
}
