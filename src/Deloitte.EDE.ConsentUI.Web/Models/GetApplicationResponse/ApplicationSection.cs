namespace Deloitte.EDE.Models.ResponseModels
{
    public class ApplicationSection
    {
        public LegalAttestations LegalAttestations { get; set; } = default!;

        public string InsuranceApplicationSecurityQuestionType { get; set; }

        public string InsuranceApplicationSecurityQuestionAnswer { get; set; } = default!;

        public List<ApplicationSignature> ApplicationSignatures { get; set; } = default!;

        public List<ApplicationAssistor> ApplicationAssistors { get; set; } = default!;

        public bool? RequestingFinancialAssistanceIndicator { get; set; }

        public string ContactMemberIdentifier { get; set; } = default!;

        public ContactInformation ContactInformation { get; set; } = default!;

        public string SpokenLanguageType { get; set; }

        public string WrittenLanguageType { get; set; }

        public string CoverageState { get; set; }

        public bool? AccountHolderIdentityProofedIndicator { get; set; }

        public string? Comments { get; set; }
        public List<string>? ContactMethod { get; set; }
    
    }
    public class LegalAttestations
    {
        public bool AbsentParentAgreementIndicator { get; set; }

        public bool ChangeInformationAgreementIndicator { get; set; }

        public bool MedicaidRequirementAgreementIndicator { get; set; }

        public double RenewEligibilityYearQuantity { get; set; }

        public bool NonIncarcerationAgreementIndicator { get; set; }

        public bool PenaltyOfPerjuryAgreementIndicator { get; set; }

        public bool RenewalAgreementIndicator { get; set; }

        public bool TerminateCoverageOtherMecFoundAgreementIndicator { get; set; }
    }

    public class ApplicationSignature
    {
        public string ApplicationSignatureType { get; set; }

        public string ApplicationSignatureText { get; set; } = default!;

        public string ApplicationSignatureDate { get; set; } = default!;
    }

    public class ApplicationAssistor
    {
        public string ApplicationAssistorType { get; set; }

        public string? AssistorOrganizationId { get; set; }
        public string? AssistorOrganizationName { get; set; }
        public string? AssistorFirstName { get; set; }
        public string? AssistorLastName { get; set; }
        public string? AssistorMiddleName { get; set; }

        public string? AssistorSuffix { get; set; }

        public double? AssistorNationalProducerNumber { get; set; }
        public string? AssistorSystemUserName { get; set; }
        public string? CreationDateTime { get; set; }
    }

    public class ContactInformation
    {
        public string? Email { get; set; }

        public PhoneNumber PrimaryPhoneNumber { get; set; } = default!;

        public PhoneNumber? SecondaryPhoneNumber { get; set; }
        public string? MobileNotificationPhoneNumber { get; set; }
    }

    public class PhoneNumber
    {
        public string Type { get; set; }

        public string Number { get; set; } = default!;

        public string? Ext { get; set; }
    }
}
