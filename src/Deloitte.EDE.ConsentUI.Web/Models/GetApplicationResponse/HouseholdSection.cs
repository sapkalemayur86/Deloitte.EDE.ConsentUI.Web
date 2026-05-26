namespace Deloitte.EDE.Models.ResponseModels
{
    public class HouseholdSection
    {
        public required List<List<dynamic>> FamilyRelationships { get; set; }
        public required List<List<dynamic>> LegalRelationships { get; set; }
        public required List<List<dynamic>> TaxRelationships { get; set; }
    }

    public class FamilyRelationshipDetails
    {
        public required bool ResideTogetherIndicator { get; set; }
        public required bool CaretakerRelativeIndicator { get; set; }
    }

    public class LegalRelationshipItem
    {
        public required string MemberId { get; set; }
        public required string RelationshipType { get; set; }
        public required string RelatedMemberId { get; set; }
    }

    public class TaxRelationshipItem
    {
        public required string MemberId { get; set; }
        public required string RelationshipType { get; set; }
        public required string RelatedMemberId { get; set; }
    }
}
