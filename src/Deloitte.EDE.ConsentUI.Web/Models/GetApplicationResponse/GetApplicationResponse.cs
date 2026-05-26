using Deloitte.EDE.Models.ResponseModels;

namespace Deloitte.EDE.Models
{
    public class GetApplicationResponse
    {
        public int CoverageYear { get; set; }
        public string? CreatingDePartner { get; set; }
        public string? SubmittingDePartner { get; set; }
        public long InsuranceApplicationIdentifier { get; set; }        
        public int ApplicationVersionNumber { get; set; }
        public string VersionDateTime { get; set; } = default!;
        public string ApplicationCreationDateTime { get; set; } = default!;

        public string? UseCase { get; set; }
        public string CreatingSystemId { get; set; } = default!;


        public string CreatingSystemRole { get; set; } = default!;

        
        public string CreatingUserId { get; set; } = default!;

        
        public bool DeletedIndicator { get; set; }

        
        public bool CurrentVersionIndicator { get; set; }

        public string? Comments { get; set; }

        
        public string LastModifiedDateTime { get; set; } = default!;

        
        public string LastModifiedUserId { get; set; } = default!;

        public string? ApplicationStatus { get; set; }
        
        public string CreationOriginType { get; set; } = default!;

        public string? ApplicationSubmissionDateTime { get; set; }
        public string? SubmissionOriginType { get; set; }
        public string? LastConsumerSubmissionDateTime { get; set; }
        public string? CopiedFromInsuranceApplicationIdentifier { get; set; }
        public string? CopiedFromInsuranceApplicationVersionNumber { get; set; }
        public string? InsuranceApplicationType { get; set; }
        
        public ComputedSection Computed { get; set; } = default!;
        public LastUpdateMetadata? LastUpdateMetaData { get; set; }
        
        public string LinkedSystemUserIdentifier { get; set; } = default!;

        public Attestations? Attestations { get; set; }

        public Submission? Submission { get; set; } 


    }

    public class Submission
    {
        
        public List<object> RequestMedicaidDeterminationMembers { get; set; } = new();
        
    }

    public class LastUpdateMetadata
    {
        
        public string SourceSystemName { get; set; } = default!; // Identifier for the system that made the last call.

        
        public string RoleId { get; set; } = default!; // The role of the system that made the last call.

        
        public string UseCase { get; set; } = default!; // "INITIAL_APP", "CIC", "REAPPLY", etc.

        
        public string UserId { get; set; } = default!; // User Identifier of the user for which the request was made.

        
        public string PartnerId { get; set; } = default!; // The identifier for the last Direct Enrollment Entity to update the application.
    }
    public class ComputedSection
    {
        
        public ComputedApplicationSection Application { get; set; } = default!;

        
        public Dictionary<string, ComputedMember> Members { get; set; } = new();

        public Dictionary<string, TaxHousehold> TaxHouseholds { get; set; } = new();

        public List<VariableDeterminationSection> VariableDeterminations { get; set; } = new();


        public Dictionary<string, RemovedMember> RemovedMembers { get; set; } = new();


        public ComputedRelationshipsSection Relationships { get; set; } = default!;
    }
    

    public class ComputedMember
    {
        
        public string PersonTrackingNumber { get; set; } = default!;
        
        public string IndianStatus { get; set; } = default!;
        
        public string IndianStatusReason { get; set; } = default!;
        
        public string NonEscMecStatus { get; set; } = default!;
        
        public string NonEscMecStatusReason { get; set; } = default!;
        
        public string SsnStatus { get; set; } = default!;
        
        public string SsnStatusReason { get; set; } = default!;
        
        public string CitizenshipStatus { get; set; } = default!;
        
        public string CitizenshipStatusReason { get; set; } = default!;
        
        public string CitizenshipDataEventStatus { get; set; } = default!;
        
        public bool CitizenshipDataFoundIndicator { get; set; }
        
        public string QhpLawfulPresenceStatus { get; set; } = default!;
        
        public string QhpLawfulPresenceStatusReason { get; set; } = default!;
        
        public string FiveYearBarStatus { get; set; } = default!;
        
        public string FiveYearBarStatusReason { get; set; } = default!;
        
        public string MedicaidLawfulPresenceStatus { get; set; } = default!;
        
        public string MedicaidLawfulPresenceStatusReason { get; set; } = default!;
        
        public bool Under100FplWithLawfulPresenceDmiIndicator { get; set; }
        
        public MedicaidChipStandard MedicaidChipStandard { get; set; } = default!;
        
        public string MedicaidNonMagiReferralStatus { get; set; } = default!;
        
        public string MedicaidNonMagiReferralStatusReason { get; set; } = default!;
        
        public string PreliminaryMedicaidStatus { get; set; } = default!;
        
        public string PreliminaryMedicaidStatusReason { get; set; } = default!;
        
        public string PreliminaryChipStatus { get; set; } = default!;
        
        public string PreliminaryChipStatusReason { get; set; } = default!;
        
        public string PreliminaryAptcStatus { get; set; } = default!;
        
        public string PreliminaryAptcStatusReason { get; set; } = default!;
        
        public string PreliminaryEmergencyMedicaidStatus { get; set; } = default!;
        
        public string PreliminaryEmergencyMedicaidStatusReason { get; set; } = default!;
        
        public string DependentChildCoveredStatus { get; set; } = default!;
        
        public string DependentChildCoveredStatusReason { get; set; } = default!;
        
        public string ChipStateHealthBenefitStatus { get; set; } = default!;
        
        public string ChipStateHealthBenefitStatusReason { get; set; } = default!;
        
        public string ChipWaitingPeriodStatus { get; set; } = default!;
        
        public string ChipWaitingPeriodStatusReason { get; set; } = default!;

        public bool? CicWithMedicaidChipPdmIndicator { get; set; }

        public bool? CicWithMedicaidChipPdmWithinLast90DaysIndicator { get; set; }

        public string EscMecStatus { get; set; } = default!;
        
        public string EscMecStatusReason { get; set; } = default!;
        
        public string IncarcerationStatus { get; set; } = default!;
        
        public string IncarcerationStatusReason { get; set; } = default!;
        
        public MedicaidHouseholdComposition MedicaidHouseholdComposition { get; set; } = default!;
        
        public IncomeSection Income { get; set; } = default!;
        
        public QhpResidencySection QhpResidency { get; set; } = default!;
        
        public string MedicaidResidencyStatus { get; set; } = default!;
        
        public string MedicaidResidencyStatusReason { get; set; } = default!;
        
        public string EmergencyMedicaidStatus { get; set; } = default!;
        
        public string EmergencyMedicaidStatusReason { get; set; } = default!;
        
        public ResidencyAddressSection ResidencyAddress { get; set; } = default!;
        
        public string QhpStatus { get; set; } = default!;
        
        public string QhpStatusReason { get; set; } = default!;
        
        public string AptcStatus { get; set; } = default!;
        
        public string AptcStatusReason { get; set; } = default!;
        
        public bool SecretaryHardshipExemptionIndicator { get; set; }
        
        public string CsrStatus { get; set; } = default!;
        
        public string CsrStatusReason { get; set; } = default!;
        
        public string CsrVariant { get; set; } = default!;
        
        public string MedicaidStatus { get; set; } = default!;
        
        public string MedicaidStatusReason { get; set; } = default!;
        
        public string ChipStatus { get; set; } = default!;
        
        public string ChipStatusReason { get; set; } = default!;
        
        public string UnbornChildChipStatus { get; set; } = default!;
        
        public string UnbornChildChipStatusReason { get; set; } = default!;
        
        public string TransferApplicantToStateStatus { get; set; } = default!;
        
        public string TransferApplicantToStateStatusReason { get; set; } = default!;
        
        public List<EligibleSepSection> EligibleSEP { get; set; } = new();
        
        public HraEventSection HraEvent { get; set; } = default!;
    }

    public class EligibleSepSection
    {
        
        public string Status { get; set; } = default!; // "YES"

        
        public string StatusReason { get; set; } = default!; // see schema for allowed values

        
        public string StartDate { get; set; } = default!;

        
        public string EndDate { get; set; } = default!;

        
        public string SepType { get; set; } = default!; // see schema for allowed values

        
        public string VerificationSourceType { get; set; } = default!; // see schema for allowed values
    }

    public class MedicaidHouseholdComposition
    {
        
        public string MedicaidHouseHoldStatus { get; set; } = default!; // "YES", "NO", "NOT_APPLICABLE"

        
        public string MedicaidHouseHoldStatusReason { get; set; } = default!; // "369", "371", "560", "662", "663", "664", "999"

        
        public string MedicaidTaxRoleType { get; set; } = default!; // "DEPENDENT_ON_OTHER", "DEPENDENT_ON_PARENT", etc.

        
        public int MedicaidHouseholdSize { get; set; } // Number of members in the Medicaid Household

        
        public List<string> MedicaidHouseholdMemberIdentifiers { get; set; } = new(); // Member IDs
    }

    public class HraEventSection
    {
        
        public string CreationDateTime { get; set; } = default!;

        
        public IchraResultSection IchraResult { get; set; } = default!;

        
        public List<HraOfferSection> HraOffers { get; set; } = new();
    }

    public class IchraResultSection
    {
        
        public string Status { get; set; } = default!; // "YES", "NO", "NOT_APPLICABLE"

        
        public string StatusReason { get; set; } = default!; // see schema for allowed values
    }

    public class HraOfferSection
    {
        
        public string EmployerName { get; set; } = default!;

        
        public string HraType { get; set; } = default!; // "ICHRA", "QSEHRA"

        
        public string PrimaryInsuredMemberIdentifier { get; set; } = default!;

        
        public bool? SafeHarborIndicator { get; set; }

        
        public bool? HraAffordabilityIndicator { get; set; }
    }
    public class ResidencyAddressSection : Address
    {
        public string? residencyAddressSourceType { get; set; }
    }
    public class IncomeSection
    {
        
        public string IrsDataStatus { get; set; } = default!; // "NOT_APPLICABLE", "HOLD", "DELAY", "ERROR", "COMPLETE"

        
        public string IrsDataStatusReason { get; set; } = default!;

        
        public string MedicaidIncomeStatus { get; set; } = default!; // "YES", "NO", "NOT_APPLICABLE"

        
        public string ChipIncomeStatus { get; set; } = default!; // "YES", "NO", "NOT_APPLICABLE"

        
        public string MedicaidChipIncomeStatusReason { get; set; } = default!;

        
        public bool? MedicaidGapFillingIndicator { get; set; }

        
        public bool? AnnualIncomeExplanationRequired { get; set; }

        
        public decimal? AttestedMonthlyIndividualIncomeAmt { get; set; }

        
        public decimal? AttestedAnnualizedAptcIndividualIncomeAmt { get; set; }

        
        public decimal? DisregardAdjustAttestedMonthlyMedicaidHouseholdIncomePercent { get; set; }

        
        public decimal? AdjustAttestedMonthlyMedicaidHouseholdIncomeAmount { get; set; }

        
        public decimal? AdjustAttestedAnnualMedicaidHouseholdIncomeAmount { get; set; }

        
        public List<EmployerSection> Employer { get; set; } = new();
    }
    public class QhpResidencySection
    {
        
        public string QhpResidencyStatus { get; set; } = default!; // "YES", "NO", "NOT_APPLICABLE"

        
        public string QhpResidencyStatusReason { get; set; } = default!; // "167_ADDRESS_NOT_IN_XCHNGE_SERVICE_AREA", "555_N_A_RULE_DOES_NOT_APPLY", "999_N_A"

        
        public bool? TaxHouseholdResidencyAppliesIndicator { get; set; }
    }
    public class EmployerSection
    {
        
        public string Employer { get; set; } = default!;

        
        public bool? JobIncomeExplanationRequiredIndicator { get; set; }

        
        public string JobIncomeExplanationAcceptance { get; set; } = default!; // "YES", "PENDING"
    }
    public class MedicaidChipStandard
    {
        public decimal? MedicaidStandardPercent { get; set; }
        public string MedicaidStandardBasisType { get; set; } = default!;
        public decimal? ChipStandardPercent { get; set; }
        public string ChipStandardBasisType { get; set; } = default!;
        public List<string> ParentCaretakerChildList { get; set; } = new();
        public string AdultGroupCategoryStatus { get; set; } = default!;
        public string ChildCaretakerDeprivedStatus { get; set; } = default!;
        public string ParentCaretakerCategoryStatus { get; set; } = default!;
        public string PregnancyCategoryStatus { get; set; } = default!;
    }

    public class ComputedApplicationSection
    {
        public bool? MultiTaxHouseholdIndicator { get; set; }
        public BestSepSection? BestSEP { get; set; }
        public string? FinalQhpEffectiveStartDate { get; set; }
        public string? FinalQhpEffectiveEndDate { get; set; }
        public InsertSepSection? InsertSep { get; set; }
        public AptcEventSection? AptcEvent { get; set; }
        public BenchmarkPlanDataEventSection? BenchmarkPlanDataEvent { get; set; }
        public AsyncSubmissionResultSection? AsyncSubmissionResult { get; set; }
    }

    public class BestSepSection
    {
        public string? Status { get; set; }
        public string? StatusReason { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SepType { get; set; }
        public List<string>? AssociatedMemberIdentifiers { get; set; }
    }
    public class InsertSepSection
    {
        public string? Status { get; set; }
        public string? StatusReason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? CustomQhpEffectiveDate { get; set; }
        public string SepType { get; set; }
        public InsertSepRequestor? InsertSepRequestor { get; set; }
    }
    public class InsertSepRequestor
    {
        public string RequestorType { get; set; }
        public string? RequestorUserIdentifier { get; set; }
        public string InsertSepReasonType { get; set; }
    }
    public class AptcEventSection
    {
        public decimal? PtcFplPercentage { get; set; }
        public decimal? TaxHouseholdAnnualIncomeAmount { get; set; }
        public decimal? MaxAPTCAmount { get; set; }
        public decimal? SpspPremiumAmount { get; set; }
        public string? SlcspIdentifier { get; set; }
    }

    public class BenchmarkPlanDataEventSection
    {
        public List<BenchmarkPlanSection>? BenchmarkPlans { get; set; }
    }

    public class BenchmarkPlanSection
    {
        public long? BenchmarkMemberIdentifier { get; set; }
        public string? InsurancePlanIdentifier { get; set; }
        public string? InsurancePlanName { get; set; }
        public string? IssuerName { get; set; }
        public decimal? TotalPremiumRate { get; set; }
        public string? InitialQhpEffectiveDate { get; set; }
    }

    public class AsyncSubmissionResultSection
    {
        public string? AsyncSubmissionStatus { get; set; }
        public string StatusDateTime { get; set; } = default!;
        public ImpactedDataSourcesSection ImpactedDataSources { get; set; } = default!;
    }

    public class ImpactedDataSourcesSection
    {
        public string? IrsStatus { get; set; }
    }

    public class VariableDeterminationSection
    {
        public string? VariableDeterminationIdentifier { get; set; }
        public string? CreationDateTime { get; set; }
        public bool? SamePlanAvailableForCicIndicator { get; set; }
        public List<Dictionary<string, MemberVariableDetermination>> MemberVariableDeterminations { get; set; } = new();
        public string CoverageState { get; set; } = default!;
    }

    public class ComputedRelationshipsSection
    {
        
        public List<List<string>> FamilyRelationships { get; set; } = new();

        
        public List<List<string>> LegalRelationships { get; set; } = new();
    }

    public class TaxHousehold 
    {
        public TaxHouseholdComposition TaxHouseHoldComposition { get; set; } = new();
        public TaxHouseholdAnnualIncome AnnualIncome { get; set; } = new();
        public TaxHouseholdMaxAptc MaxAPTC { get; set; } = new();
    }

    public class TaxHouseholdComposition
    {
        public string TaxHouseHoldStatus { get; set; } = string.Empty; // "YES", "NO", "NOT_APPLICABLE"
        public string TaxHouseHoldStatusReason { get; set; } = string.Empty; // "662_CLAIMING_TAX_FILER_NOT_ON_APPLICATION", etc.
        public List<string> TaxHouseholdMemberIdentifiers { get; set; } = new();
    }

    public class TaxHouseholdAnnualIncome
    {
        public string IncomeExplanationRequiredReasonType { get; set; } = string.Empty; // "INCOME_HIGHER_THAN_SOURCE", "INCOME_LOWER_THAN_SOURCE"
        public decimal AttestedAnnualTaxHouseholdIncomeAmount { get; set; }
        public decimal AttestedAnnualTaxHouseholdIncomePercent { get; set; }
        public string AnnualIncomeStatus { get; set; } = string.Empty; // "YES", "NO", "NOT_APPLICABLE", "DELAY", "ERROR"
        public string AnnualIncomeStatusReason { get; set; } = string.Empty;
        public bool IncomeExplanationRequiredIndicator { get; set; }
        public decimal UsedDocumentAnnualTaxIncomeAmountExplanationRequiredAmount { get; set; }
        public bool? AsyncSubmissionIndicator { get; set; }
        public decimal? UsedDocumentAnnualTaxIncomeAmount { get; set; }
    }

    public class TaxHouseholdMaxAptc
    {
        public decimal? PtcFplPercentage { get; set; }
        public decimal? TaxHouseholdAnnualIncomeAmount { get; set; }
        public decimal? MaxAPTCAmount { get; set; }
        public decimal? SpspPremiumAmount { get; set; }
        public string? SlcspIdentifier { get; set; }
    }

    public class RemovedMember
    {
        public string PersonTrackingNumber { get; set; } = string.Empty;
    }

    public class MemberVariableDetermination
    {
        public bool? CatastrophicEligibilityIndicator { get; set; }
        public string CatastrophicEligibilityReasonType { get; set; } = string.Empty;
        public string PlanMetalLevelRestrictionRuleType { get; set; } = string.Empty;
        public bool? CurrentPlanOnlyIndicator { get; set; }
        public string PlanMetalLevelRestrictionRuleReasonType { get; set; } = string.Empty;
        public List<string> AllowedPlanMetalLevelType { get; set; } = new();
        public bool? LpaIndicator { get; set; }
    }


}
