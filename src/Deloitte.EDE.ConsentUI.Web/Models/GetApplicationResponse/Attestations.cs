namespace Deloitte.EDE.Models.ResponseModels
{
    public class Attestations
    {
        public ApplicationSection Application { get; set; } = default!;

        public HouseholdSection Household { get; set; } = default!;

        public Dictionary<string, MemberSection> Members { get; set; } = default!;

        public Dictionary<string, RemovedMemberSection> RemovedMembers { get; set; } = default!;

    }
}


