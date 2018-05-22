using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.CommonLayer.Enum
{
    public class CommonEnum
    {
        /// <summary>
        /// Enumeration for master data for getting data from database on the basis on master table name
        /// </summary>
        public enum MasterDataEnum
        {
            MASTERCOUNTRY, MASTERDOCUMENTTYPE, MASTERETHNICITY, MASTERINSURANCEPCP, MASTERINSURANCETYPE, /*MASTEROCCUPATION,*/ /*MASTERPREFERREDLANGUAGE,*/
            MASTERRACE, MASTERSTATE, MASTERSTATUS, SUFFIX, MASTERPROVIDER, MARITALSTATUS, MASTERRELATIONSHIP, MASTERPROGRAM, MASTERSERVICE, PATIENTSTATUS, MASTERINSURANCECOMPANY,
            /*MASTERPATIENTCOMMPREFERENCES*/
            MASTERREFERRAL, MASTERGENDER, PHONETYPE, INSURANCEPLANTYPE, MASTERSERVICECODE, MASTERICD,
            MASTERVFC, MASTERIMMUNIZATION, MASTERMANUFACTURE, MASTERADMINISTRATIONSITE, MASTERROUTEOFADMINISTRATION, MASTERIMMUNITYSTATUS, MASTERREJECTIONREASON,
            SOCIALHISTORY, TRAVELHISTORY, ADDRESSTYPE, MASTERSTAFF, APPOINTMENTTYPE, LABTESTTYPE, MASTERLONIC, MASTERLABS, TIMETYPE, FREQUENCYTYPE, FREQUENCYDURATIONTYPE,
            MASTERALLERGIES, MASTERREACTION, AUTHORIZEDPROCEDURE, MASTERCUSTOMLABELS, MASTERCUSTOMLABELTYPE, MASTERPATIENTLOCATION, MASTERTAGS,
            MASTERCUSTOMLABELSTAFF, MASTERROLES, MASTERWEEKDAYS, MASTERUNITTYPE, MASTERROUNDINGRULES
            , MASTERLOCATION, MASTERTEMPLATES, ORGANIZATIONDATABASEDETAIL, MASTERORGANIZATION, MASTERRENDERINGPROVIDER,
            USERROLETYPE, MASTERPHONEPREFERENCES, MASTERCANCELTYPE, MASTERPAYMENTTYPE, MASTERPAYMENTDESCRIPTION,
            STAFFAVAILABILITY, ENCOUNTERSTATUS, EMPLOYEETYPE, REFERRALSOURCE, EMPLOYEEMENT
        }

        public enum ControllerNames
        {
            APPCONFIGURATIONCONTROLLER,
            APPOINTMENTFILTERCONTROLLER,
            APPOINTMENTTYPECONTROLLER,
            AUDITLOGCONTROLLER,
            AUTHORIZATIONCONTROLLER,
            AUTHORIZATIONPROCEDURESCONTROLLER,
            AVAILABILITYTEMPLATECONTROLLER,
            BASEJSONAPICONTROLLER,
            CLAIMCONTROLLER,
            COMMONCONTROLLER,
            CUSTOMJSONAPICONTROLLER,
            EDIGATEWAYCONTROLLER,
            ENCOUNTERCPTCONTROLLER,
            ENCOUNTERICDCONTROLLER,
            INSURANCECOMPANIESCONTROLLER,
            INSUREDPERSONCONTROLLER,
            AUTHENTICATIONCONTROLLER,
            MASTERCUSTOMLABELCONTROLLER,
            MASTERDATACONTROLLER,
            MASTERICDCONTROLLER,
            MASTERINSURANCECONTROLLER,
            MASTERINSURANCETYPECONTROLLER,
            MASTERLOCATION,//MASTERLOCATIONCONTROLLER
            MASTERMODULESCONTROLLER,
            MASTERSERVICECODECONTROLLER,
            MASTERTAGSCONTROLLER,
            MASTERTEMPLATECONTROLLER,
            ORGANIZATIONCONTROLLER,
            ORGANIZATIONDATABASECONTROLLER,
            PAPERCLAIMCONTROLLER,
            PATIENTADDRESSCONTROLLER,
            PATIENTALLERGYCONTROLLER,
            PATIENTAPPOINTMENTCONTROLLER,
            PATIENTAPPOINTMENTSCONTROLLER,
            PATIENTCOMMONCONTROLLER,
            PATIENTCONTROLLER,
            PATIENTCUSTOMLABELSCONTROLLER,
            PATIENTDIAGNOSISCONTROLLER,
            PATIENTENCOUNTERCONTROLLER,
            PATIENTGUARDIANCONTROLLER,
            PATIENTIMMUNIZATIONCONTROLLER,
            PATIENTINSURANCEDETAILCONTROLLER,
            PATIENTLABTESTCONTROLLER,
            PATIENTMEDICALFAMILYHISTORYCONTROLLER,
            PATIENTMEDICATIONCONTROLLER,
            PATIENTPASTILLNESSCONTROLLER,
            PATIENTPHONENUMBERCONTROLLER,
            PATIENTPREFERENCECONTROLLER,
            PATIENTSOCIALHISTORYCONTROLLER,
            PATIENTTAGSCONTROLLER,
            PATIENTVITALSCONTROLLER,
            PAYERACTIVITYCONTROLLER,
            PAYERAPPOINTMENTTYPESCONTROLLER,
            PAYERINFORMATIONCONTROLLER,
            STAFFCONTROLLER,
            STAFFCUSTOMLABELSCONTROLLER,
            STAFFTAGSCONTROLLER,
            USERCONTROLLER,
            USERFAVOURITECONTROLLER,
            USERROLESCONTROLLER

        }

        /// <summary>
        /// Enumeration for patient search parameters for getting data on the basis of passed parameters
        /// </summary>
        public enum PatientSearch
        {
            FIRSTNAME, MIDDLENAME, LASTNAME, SSN, FROMDATE, TODATE, FROMDOB, TODOB, SEARCHKEY, ID, PROVIDERNAME, GENDER, DOB, PATIENTINSURANCE, STAFFNAME, STARTWITH, PATIENTID, STAFFID, LOCATIONID, PATIENTTAGNAME,
            OPERATION,
            TAGS,
            ISACTIVE, ROLETYPEID, TYPEKEY,
            STAFFTAGNAME,
            ORGANIZATIONID
        }

        /// <summary>
        /// Enumeration for patient search parameters for getting data on the basis of passed parameters
        /// </summary>
        public enum StaffSearch
        {
            FIRSTNAME, MIDDLENAME, LASTNAME, SEARCHKEY, ID, PROVIDERNAME, GENDER, DOB, FROMDOB, TODOB, FROMDATE, TODATE, DOJ, FROMDOJ, TODOJ, ROLE, ROLEID,
            TAGS
        }

        /// <summary>
        /// Enumeration for all data types
        /// </summary>
        public enum DataType
        {
            System_Boolean = 0,
            System_Int32 = 1,
            System_Int64 = 2,
            System_Double = 3,
            System_DateTime = 4,
            System_String = 5

        }

        /// <summary>
        /// those attributes which are used under patch request
        /// </summary>
        public enum AttrToUpdate
        {
            PhotoPath,
            PhotoThumbnailPath,
            PhotoBase64,
            //For insurance
            InsurancePhotoPathFront,
            InsurancePhotoPathThumbFront,
            InsurancePhotoPathBack,
            InsurancePhotoPathThumbBack,
            //Vital
            BMI,
            Answer,
            FTPPassword
        }
        public enum CommonAttributes
        {
            PageSize = 10,
        }
        public enum HttpStatusCodes
        {
            // http://www.w3.org/Protocols/rfc2616/rfc2616-sec6.html#sec6.1.1

            Continue = 100,        // Section 10.1.1: Continue
            SwitchingProtocols = 101,        // Section 10.1.2: Switching Protocols

            OK = 200,                // Section 10.2.1: OK
            Created = 201,        // Section 10.2.2: Created
            Accepted = 202,        // Section 10.2.3: Accepted
            NonAuthoritativeInformation = 203,    // Section 10.2.4: Non-Authoritative Information
            NoContent = 204,        // Section 10.2.5: No Content
            ResetContent = 205,    // Section 10.2.6: Reset Content
            PartialContent = 206,    // Section 10.2.7: Partial Content

            MultipleChoices = 300,        // Section 10.3.1: Multiple Choices
            MovedPermanently = 301,        // Section 10.3.2: Moved Permanently
            Found = 302,            // Section 10.3.3: Found
            SeeOther = 303,        // Section 10.3.4: See Other
            NotModified = 304,    // Section 10.3.5: Not Modified
            UseProxy = 305,        // Section 10.3.6: Use Proxy
            TemporaryRedirect = 307,        // Section 10.3.8: Temporary Redirect

            BadRequest = 400,        // Section 10.4.1: Bad Request
            Unauthorized = 401,    // Section 10.4.2: Unauthorized
            PaymentRequired = 402,        // Section 10.4.3: Payment Required
            Forbidden = 403,        // Section 10.4.4: Forbidden
            NotFound = 404,        // Section 10.4.5: Not Found
            MethodNotAllowed = 405,        // Section 10.4.6: Method Not Allowed
            NotAcceptable = 406,    // Section 10.4.7: Not Acceptable
            ProxyAuthenticationRequired = 407,    // Section 10.4.8: Proxy Authentication Required
            RequestTimeout = 408,    // Section 10.4.9: Request Time-out
            Conflict = 409,        // Section 10.4.10: Conflict
            Gone = 410,            // Section 10.4.11: Gone
            LengthRequired = 411,    // Section 10.4.12: Length Required
            PreconditionFailed = 412,    // Section 10.4.13: Precondition Failed
            RequestEntityTooLarge = 413,    // Section 10.4.14: Request Entity Too Large
            RequestUriTooLarge = 414,    // Section 10.4.15: Request-URI Too Large
            UnsupportedMediaType = 415,    // Section 10.4.16: Unsupported Media Type
            RequestedRangeNotSatisfiable = 416,    // Section 10.4.17: Requested range not satisfiable
            ExpectationFailed = 417,        // Section 10.4.18: Expectation Failed
            UnprocessedEntity = 422,

            InternalServerError = 500,    // Section 10.5.1: Internal Server Error
            NotImplemented = 501,    // Section 10.5.2: Not Implemented
            BadGateway = 502,        // Section 10.5.3: Bad Gateway
            ServiceUnavailable = 503,    // Section 10.5.4: Service Unavailable
            GatewayTimeout = 504,        // Section 10.5.5: Gateway Time-out
            HttpVersionNotSupported = 505,        // Section 10.5.6: HTTP Ve
        }
        ///
        public enum AppConfigurationsEnum
        {
            CLINICIAN_SIGN,
            PATIENT_SIGN,
            GUARDIAN_SIGN
        }

        public enum EncounterStatus
        {
            Pending,
            Hold,
            Rendered
        }

        public enum OrganizationRoles
        {
            Patient,
            Admin,
            Client
        }
        public enum InsurancePlanType
        {
            Primary, Secondary, Tertiary
        }
        public enum EDISubmissionType
        {
            Original, Edited
        }
        public enum MasterStatusClaim
        {
            ReadyToBill = 1,
            Submitted = 2
        }
        public enum SQLObjects
        {
            //Staff
            APPOINTMENT_GetStaffAvailability,


            //Appointment
            APT_CheckIsValidAppointment,
            APT_GetAddressListOnScheduler,
            PAT_GetAuthDataForPatientAppointment,

            //Claims
            CLM_CreateClaim,
            CLM_GetAllClaimsWithServiceLines,
            CLM_GetAllClaimsWithServiceLinesForPayer,
            CLM_ApplyPayments,
            CLM_GetClaimDetailsById,
            CLM_GetClaims,
            CLM_GetClaimServiceLines,
            CLM_GetPaperClaimInfo,
            CLM_GetEDIInfo,
            CLM_GetBatchEDIInfo,
            CLM_GenerateClaim837BatchIdForSingleSubmit,
            CLM_GenerateClaim837BatchIdForBatchSubmit,
            CLM_UpdateBatchRequestStatus,
            CLM_SaveEDI835ResponseDetails,
            CLM_Apply835PaymentsToPatientAccount,
            CLM_GetProcessedClaims,
            CLM_GetClaimsForPatientLedger,
            CLM_GetClaimServiceLinesForPatientLedger,

            //Payments
            CLM_GetServiceLinePaymentDetailsForPatientLedger,
            //Role Permissions
            USR_GetUserRolePermissions,
            USR_SaveUserRolePermissions,

            // Patient
            PAT_GetActivitiesForPatientPayer,
            PAT_GetPatientActiveAuthorizationData,
            PAT_GetPatientAddressList,
            PAT_GetPatientPayerServiceCodes,
            PAT_GetAuthorizedServiceCodesForPatientAppointmentType,
            PAT_CheckServiceCodesAuthorizationForPatient,
            PAT_GetPatientGuarantor,

            //Patient Authorization
            PAT_GetAllAuthorizationsForPatient,

            //Common
            MTR_CheckRecordDepedencies,

            //Payer
            PAY_GetPayerServiceCodeDetail

        }
        public enum StaffAvailabilityEnum
        {
            WEEKDAY,
            AVAILABLE,
            UNAVAILABLE
        }
        public enum ImagesFolderEnum
        {
            //Organization images folder name
            Logo,
            Favicon,

            //encounter sign images
            ClinicianSign,
            PatientSign,
            GuardianSign
        }
    }
}
