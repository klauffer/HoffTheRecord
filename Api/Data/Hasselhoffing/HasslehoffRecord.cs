﻿using static Domain.Hasselhoffing.ACoworker.ICreateAHasslehoffRecord;

namespace Data.Hasselhoffing
{
    internal sealed class HasslehoffRecord
    {
        public int Id { get; set; }
        public string PersonThatCommittedTheOffense { get; set; }
        public string PersonThatWasHoffed { get; set; }
        public string ImageUrl { get; set; }

        public HasslehoffRecord(string personThatCommittedTheOffense, string personThatWasHoffed, string imageUrl)
        {
            PersonThatCommittedTheOffense = personThatCommittedTheOffense;
            PersonThatWasHoffed = personThatWasHoffed;
            ImageUrl = imageUrl;
        }

        public static HasslehoffRecord FromCreateAHasslehoffRecordArguements(CreateAHasslehoffRecordArguements arguements)
            => new HasslehoffRecord(
                arguements.PersonThatCommittedTheOffense,
                arguements.PersonThatWasHoffed,
                arguements.ImageUrl);

    }
}
