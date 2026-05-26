namespace Deloitte.EDE.Models.ResponseModels
{
    public class RemovedMemberSection
    {
        public RemovedDemographic? Demographic { get; set; }
        public string? RemovalReasonType { get; set; }
    }
    public class RemovedDemographic
    {
        public Name? Name { get; set; }
        public string? DeathDate { get; set; }
        public string? DivorceDate { get; set; }
        public string? BirthDate { get; set; }
        public string? MedicareStartDate { get; set; }
    }
}
