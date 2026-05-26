namespace Deloitte.EDE.Models.ResponseModels
{
    public class MemberSection
    {
        public bool RequestingCoverageIndicator { get; set; }
        public bool? TerminateCoverageStartMedicareIndicator { get; set; }
        public Demographic? Demographic { get; set; }
        public Income? Income { get; set; }
        public Family? Family { get; set; }
        public LawfulPresence? LawfulPresence { get; set; }
        public InsuranceCoverage? InsuranceCoverage { get; set; }
        public Medicaid? Medicaid { get; set; }
        public Chip? Chip { get; set; }
        public NonMagi? NonMagi { get; set; }
        public Other? Other { get; set; }
    }
    public class Demographic
    {
        public string? Ssn { get; set; }
        
        public string BirthDate { get; set; } = string.Empty;
        public Name? Name { get; set; }
        public Name? SsnAlternateName { get; set; }
        public string? Sex { get; set; }
        public string? MaritalStatus { get; set; }
        public bool? NoHomeAddressIndicator { get; set; }
        public bool? LiveOutsideStateTemporarilyIndicator { get; set; }
        public bool? HispanicOriginIndicator { get; set; }
        public bool? AmericanIndianAlaskanNativeIndicator { get; set; }
        public List<string>? Ethnicity { get; set; }
        public string? OtherEthnicityText { get; set; }
        public List<string>? Race { get; set; }
        public string? OtherRaceText { get; set; }
        public string? SexAssignedAtBirth { get; set; }
        public string? SexAssignedAtBirthOtherText { get; set; }
        public string? Gender { get; set; }
        public string? GenderDifferentTermText { get; set; }
        public string? SexualOrientation { get; set; }
        public string? SexualOrientationDifferentTermText { get; set; }
        public Address? MailingAddress { get; set; }
        public Address? HomeAddress { get; set; }
        public Address? TransientAddress { get; set; }
    }

    public class Name
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        
        public string LastName { get; set; } = string.Empty;
        public string? Suffix { get; set; }
    }

    public class Address
    {
        
        public string StreetName1 { get; set; } = string.Empty;
        public string? StreetName2 { get; set; }
        
        public string CityName { get; set; } = string.Empty;
        
        public string StateCode { get; set; } = string.Empty;
        public string? Plus4Code { get; set; }
        
        public string ZipCode { get; set; } = string.Empty;
        public string? CountyName { get; set; }
        public string? CountyFipsCode { get; set; }
    }
    public class Income
    {
        public AnnualTaxIncome? AnnualTaxIncome { get; set; }
        public Dictionary<string, CurrentIncome>? CurrentIncome { get; set; }
    }

    public class AnnualTaxIncome
    {
        public double? IncomeAmount { get; set; }
        public bool? IncomeLessExplainedIndicator { get; set; }
        public bool? UnknownIncomeIndicator { get; set; }
        public bool? VariableIncomeIndicator { get; set; }
        public bool? ReceivedUnemploymentCompensationIndicator { get; set; }
        public string? TaxHouseholdIncomeDiscrepancyDescriptionText { get; set; }
        public List<string>? TaxHouseholdIncomeDifferenceReasonType { get; set; }
        public string? VariableIncomeDescriptionText { get; set; }
    }

    public class CurrentIncome
    {
        public double? IncomeAmount { get; set; }
        public double? TribalIncomeAmount { get; set; }
        public string? IncomeSourceType { get; set; }
        public string? IncomeFrequencyType { get; set; }
        public bool? EstimatedForAptcIndicator { get; set; }
        public JobIncome? JobIncome { get; set; }
        public string? OtherDeductionDescription { get; set; }
        public string? SelfEmploymentIncomeDescription { get; set; }
        public UnemploymentIncome? UnemploymentIncome { get; set; }
        public string? OtherIncomeDescription { get; set; }
    }

    public class JobIncome
    {
        public double? AverageWeeklyWorkDays { get; set; }
        public double? AverageWeeklyWorkHours { get; set; }
        public string? IncomeDifferenceReason { get; set; }
        public string? EmployerName { get; set; }
        public string? OtherIncomeDifferenceReason { get; set; }
    }

    public class UnemploymentIncome
    {
        public string? ExpirationDate { get; set; }
        public string? IncomeDescription { get; set; }
    }

    public class Family
    {
        public bool? LiveWithParentOrSiblingIndicator { get; set; }
        public int? BabyDueQuantity { get; set; }
        public bool? TaxDependentIndicator { get; set; }
        public bool? TaxFilerIndicator { get; set; }
        public string? TaxReturnFilingStatusType { get; set; }
        public bool? ClaimsDependentIndicator { get; set; }
        public bool? ClaimingTaxFilerNotOnApplicationIndicator { get; set; }
        public bool? LivesWithCustodialParentNotOnApplicationIndicator { get; set; }
        public bool? FosterCareIndicator { get; set; }
        public int? FosterCareEndAge { get; set; }
        public bool? MedicaidDuringFosterCareIndicator { get; set; }
        public string? FosterCareState { get; set; }
        public bool? MedicaidFamilyNotProvidedIndicator { get; set; }
        public bool? TaxFilerNotProvidedIndicator { get; set; }
        public bool? ParentCaretakerIndicator { get; set; }
        public bool? PregnancyIndicator { get; set; }
        public bool? FullTimeStatusIndicator { get; set; }
        public bool? StudentsParentLivingInExchangeStateIndicator { get; set; }
        public bool? ParentLivesInStudentStateIndicator { get; set; }
        public bool? AbsentParentIndicator { get; set; }
        public bool? ResideWithBothParentIndicator { get; set; }
        public bool? AttestedHeadOfHouseholdIndicator { get; set; }
        public bool? LiveApartFromSpouseIndicator { get; set; }
    }

    public class LawfulPresence
    {
        public string? LawfulPresenceGrantDate { get; set; }
        public bool? LawfulPresenceStatusIndicator { get; set; }
        public bool? LivedInUs5yearIndicator { get; set; }
        public bool? NoAlienNumberIndicator { get; set; }
        public bool? CitizenshipIndicator { get; set; }
        public bool? NaturalizedCitizenIndicator { get; set; }
        public LawfulPresenceDocument? LawfulPresenceDocumentation { get; set; }
    }

    public class LawfulPresenceDocument
    {
        public DocumentInformation? PERMANENT_RESIDENT_CARD_I_551 { get; set; }
        public DocumentInformation? TEMPORARY_I_551_STAMP_ON_PASSPORT_OR_I_94_I_94A { get; set; }
        public DocumentInformation? MACHINE_READABLE_IMMIGRANT_VISA_WITH_TEMPORARY_I_551_LANGUAGE { get; set; }
        public DocumentInformation? EMPLOYMENT_AUTHORIZATION_CARD_I_766 { get; set; }
        public DocumentInformation? ARRIVAL_DEPARTURE_RECORD_IN_FOREIGN_PASSPORT_I_94 { get; set; }
        public DocumentInformation? ARRIVAL_DEPARTURE_RECORD_IN_UNEXPIRED_FOREIGN_PASSPORT_I_94 { get; set; }
        public DocumentInformation? FOREIGN_PASSPORT { get; set; }
        public DocumentInformation? REENTRY_PERMIT { get; set; }
        public DocumentInformation? REFUGEE_TRAVEL_DOCUMENT { get; set; }
        public DocumentInformation? CERTIFICATE_OF_ELIGIBILITY_FOR_NONIMMIGRANT_STUDENT_STATUS_I_20 { get; set; }
        public DocumentInformation? CERTIFICATE_OF_ELIGIBILITY_FOR_EXCHANGE_VISITOR_STATUS_DS_2019 { get; set; }
        public DocumentInformation? DOCUMENT_INDICATING_A_MEMBER_OF_RECOGNIZED_INDIAN_TRIBE_OR_INDIAN_BORN_IN_CANADA { get; set; }
        public DocumentInformation? NOTICE_OF_ACTION_I_797 { get; set; }
        public DocumentInformation? CERTIFICATION_FROM_HHS_ORR { get; set; }
        public DocumentInformation? ORR_ELIGIBILITY_LETTER { get; set; }
        public DocumentInformation? CUBAN_HAITAN_ENTRANT { get; set; }
        public DocumentInformation? RESIDENT_OF_AMERICAN_SAMOA_CARD { get; set; }
        public DocumentInformation? DOCUMENT_INDICATING_WITHHOLDING_OF_REMOVAL { get; set; }
        public DocumentInformation? ADMINISTRATIVE_STAY_BY_DHS { get; set; }
        public DocumentInformation? OTHER { get; set; }
        public DocumentInformation? CERTIFICATE_OF_CITIZENSHIP { get; set; }
        public DocumentInformation? CERTIFICATE_OF_NATURALIZATION { get; set; }
        public DocumentInformation? NS1_MEMBERS_OF_A_FEDERALLY_RECOGNIZED_INDIAN_TRIBE { get; set; }
        public DocumentInformation? NS2_NON_CITIZEN_WHO_IS_LAWFULLY_PRESENT_IN_AMERICAN_SAMOA_UNDER_THE_IMMIGRATION_LAWS_OF_AMERICAN_SAMOA { get; set; }
        public DocumentInformation? NS4_NON_CITIZEN_WHO_IS_LAWFULLY_PRESENT_IN_AMERICAN_SAMOA { get; set; }
        public DocumentInformation? VAWA_SELF_PETITIONER { get; set; }

    }
    public class DocumentInformation
    {
        public string? DocumentExpirationDate { get; set; }
        public string? AlienNumber { get; set; }
        public string? EmploymentAuthorizationCategoryIdentifier { get; set; }
        public string? SevisId { get; set; }
        public string? I94Number { get; set; }
        public string? PassportNumber { get; set; }
        public string? PassportIssuingCountry { get; set; }
        public string? CardNumber { get; set; }
        public string? NaturalizationCertificateNumber { get; set; }
        public string? CitizenshipNumber { get; set; }
        public Name? DocumentAlternateName { get; set; }
        public bool? NoIdentifiersProvidedIndicator { get; set; }
        public string? OtherTypeText { get; set; }
    }

    public class InsuranceCoverage
    {
        public bool? EnrolledInIchraIndicator { get; set; }
        public bool? OfferedIchraIndicator { get; set; }
        public List<HraOffer>? HraOffers { get; set; }
        public List<EnrolledCoverage>? EnrolledCoverages { get; set; }
        public Dictionary<string, EmployerSponsoredCoverageOffer>? EmployerSponsoredCoverageOffers { get; set; }
        public string? OfferedEmployeeCoverage { get; set; }
        public string? MedicareStartDate { get; set; }
    }

    public class HraOffer
    {
        public string? HraType { get; set; }
        public string? StartDate { get; set; }
        public string? NoticeDate { get; set; }
        public bool? EnrolledInOfferFromSameEmployerIndicator { get; set; }
        public bool? EnrolledInOfferFromSameEmployerUntilStartDateIndicator { get; set; }
        public string? PrimaryInsuredMemberIdentifier { get; set; }
        public string? EndDate { get; set; }
        public double? EmployeeSelfOnlyOfferAmount { get; set; }
        public string? EmployeeSelfOnlyOfferFrequencyType { get; set; }
        public bool? PrimaryInsuredMemberNotInTaxHhIndicator { get; set; }
        public Employer? Employer { get; set; }
    }

    public class Employer
    {
        public string? Name { get; set; }
        public string? EmployerIdentificationNumber { get; set; }
        public string? StreetName1 { get; set; }
        public string? StreetName2 { get; set; }
        public string? CityName { get; set; }
        public string? StateCode { get; set; }
        public string? ZipCode { get; set; }
        public string? Plus4Code { get; set; }
        public string? CountryCode { get; set; }
        public string? CountyName { get; set; }
        public string? CountyFipsCode { get; set; }
        public string? EmployerPhoneNumber { get; set; }
        public EmployerContact? Contact { get; set; }
    }

    public class EmployerContact
    {
        public Name? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class EnrolledCoverage
    {
        public string? InsuranceMarketType { get; set; }
        public string? InsurancePolicyMemberId { get; set; }
        public string? InsurancePolicyNumber { get; set; }
        public string? InsurancePlanName { get; set; }
    }


    public class EmployerSponsoredCoverageOffer
    {
        public bool? CobraAvailableIndicator { get; set; }
        public bool? DoNotKnowLcsopPremiumIndicator { get; set; }
        public bool? EmployeeWillDropCoverageIndicator { get; set; }
        public decimal? LcsopPremium { get; set; }
        public string? LcsopPremiumFrequencyType { get; set; }
        public string? LcsopName { get; set; }
        public string? EmployerOffersMinValuePlan { get; set; }
        public decimal? FamilyPlanPremiumAmount { get; set; }
        public string? FamilyPlanPremiumFrequencyType { get; set; }
        public bool? EmployerOffersFamilyMinValuePlanIndicator { get; set; }
        public bool? PlanToEnrollEscIndicator { get; set; }
        public string? PlanToEnrollEscDate { get; set; }
        public Employer? Employer { get; set; }
        public bool? EmployerWillChangeLcsopPremiumIndicator { get; set; }
        public bool? EmployerWillNoLongerOfferLcsopIndicator { get; set; }
        public string? EmployeeStatus { get; set; }
        public bool? EscEnrolledIndicator { get; set; }
        public string? NewEmployeeLcsopPremiumAmount { get; set; }
        public string? NewLcsopPremiumFrequencyType { get; set; }
        public bool? RetireePlanCoverageIndicator { get; set; }
        public bool? WaitingPeriodIndicator { get; set; }
        public string? PrimaryInsuredMemberIdentifier { get; set; }
        public string? InsurancePolicyMemberId { get; set; }
        public string? InsurancePolicyNumber { get; set; }
        public string? InsurancePlanName { get; set; }
    }

    public class Medicaid
    {
        public string? MedicaidDeniedDate { get; set; }
        public bool? MedicaidDeniedDueToImmigrationIndicator { get; set; }
        public bool? MedicaidDeniedIndicator { get; set; }
        public int? Parent1WeeklyWorkHourQuantity { get; set; }
        public int? Parent2WeeklyWorkHourQuantity { get; set; }
        public bool? UnpaidBillIndicator { get; set; }
        public bool? CoveredDependentChildIndicator { get; set; }
        public bool? EnrolledInHealthCoverageIndicator { get; set; }
        public List<EnrolledCoverage>? InsuranceCoverage { get; set; }
        public bool? InformationChangeSinceMedicaidDeniedIndicator { get; set; }
        public bool? ImmigrationStatusFiveYearIndicator { get; set; }
        public bool? ImmigrationStatusChangeSinceDeniedIndicator { get; set; }
        public bool? InformationChangeSinceMedicaidEndedIndicator { get; set; }
        public bool? MedicaidEndIndicator { get; set; }
        public string? MedicaidEndDate { get; set; }
    }

    public class Chip
    {
        public bool? CoverageEndedIndicator { get; set; }
        public bool? StateHealthBenefitIndicator { get; set; }
        public string? CoverageEndedReasonType { get; set; }
        public string? CoverageEndedReasonText { get; set; }
    }

    public class NonMagi
    {
        public bool? BlindOrDisabledIndicator { get; set; }
        public bool? LongTermCareIndicator { get; set; }
    }

    public class Other
    {
        public bool? AppliedDuringOeOrLifeChangeIndicator { get; set; }
        public ChangeInCircumstance? ChangeInCircumstance { get; set; }
        public AmericanIndianAlaskanNative? AmericanIndianAlaskanNative { get; set; }
        public bool? VeteranIndicator { get; set; }
        public string? IncarcerationType { get; set; }
        public string? ReconcilePtcIndicatorType { get; set; }
        public bool? VeteranSelfIndicator { get; set; }
        public List<string>? NonMemberVeteranRelationshipTypes { get; set; }
    }

    public class ChangeInCircumstance
    {
        public CircumstanceChange? GAINING_LAWFUL_PRESENCE { get; set; }
        public CircumstanceChange? RELEASE_FROM_INCARCERATION { get; set; }
        public LossOfMecChange? LOSS_OF_MEC { get; set; }
        public LossOfMecChange? FUTURE_LOSS_OF_MEC { get; set; }
        public RelocationChange? RELOCATION { get; set; }
        public MarriageChange? MARRIAGE { get; set; }
        public CircumstanceChange? ADOPTION { get; set; }
    }

    public class CircumstanceChange
    {
        public string? ChangeDate { get; set; }
    }

    public class LossOfMecChange : CircumstanceChange
    {
        public string? LossMecIssuerName { get; set; }
    }

    public class RelocationChange : CircumstanceChange
    {
        public bool? MovedFromForeignCountryIndicator { get; set; }
        public bool? Coverage60DayBeforeMoveIndicator { get; set; }
        public string? PrecedingZipCode { get; set; }
        public string? PrecedingStateCode { get; set; }
        public string? PrecedingCountyName { get; set; }
    }

    public class MarriageChange : CircumstanceChange
    {
        public bool? Coverage60DayBeforeMarriageIndicator { get; set; }
        public bool? LiveInForeignCountry60DayBeforeMarriageIndicator { get; set; }
    }

    public class AmericanIndianAlaskanNative
    {
        public string? FederallyRecognizedTribeName { get; set; }
        public bool? PersonRecognizedTribeIndicator { get; set; }
        public bool? ReceiveItuIndicator { get; set; }
        public bool? EligibleForItuIndicator { get; set; }
    }

}
