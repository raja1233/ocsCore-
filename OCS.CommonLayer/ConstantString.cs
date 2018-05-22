using System;
using System.Collections.Generic;
using System.Text;

namespace OCS.CommonLayer
{
    public class ConstantString
    {

    }
    public static class DatabaseTables
    {
        public const string ClaimServiceLine = "ClaimServiceLine";
        public static string DatabaseEntityName(string entityName)
        {
            switch (entityName)
            {

                case "MasterServiceCode":
                    entityName = "MasterServiceCode";
                    break;
                case "MasterRoundingRules":
                    entityName = "MasterRoundingRules";
                    break;
                case "MasterCustomLabels":
                    entityName = "MasterCustomLabels";
                    break;
                case "MasterICD":
                    entityName = "MasterICD";
                    break;
                case "MasterImmunization":
                    entityName = "MasterImmunization";
                    break;
                case "MasterTags":
                    entityName = "MasterTags";
                    break;
                case "MasterInsuranceTypes":
                    entityName = "MasterInsuranceTypes";
                    break;
                case "UserRoles":
                    entityName = "UserRoles";
                    break;
                case "AppointmentType":
                    entityName = "AppointmentType";
                    break;
                case "Location":
                    entityName = "Location";
                    break;
                case "SecurityQuestions":
                    entityName = "SecurityQuestions";
                    break;
                case "EDIGateway":
                    entityName = "EDIGateway";
                    break;
                case "User":
                    entityName = "User";
                    break;
                case "InsuranceCompanies":
                    entityName = "InsuranceCompanies";
                    break;
                case "PayerServiceCodes":
                    entityName = "PayerServiceCodes";
                    break;

            }
            return entityName;
        }
    }
    public static class UserAccountNotification
    {
        public const string EmailNotFound = "Email Id not found";
        public const string AccountDeactiveOrExpirePass = "Your account has been locked out or temporarily deactivated. Please contact your office";
        public const string AccountDeactive = "Your account has been locked out or temporarily deactivated. Please contact your office";
        public const string Success = "Successfully Logged in";
        public const string UserDeleted = "User Deleted Successfully";
        public const string InvalidPassword = "The password provided is incorrect";
        public const string PasswordExpired = "The user name or password provided is incorrect.";

        public const string LoginFailed = "Something went wrong, please try after some time or contact system administration";
        public const string EmailAlreadyExists = "The email address entered is already in use";
        public const string PrimaryEmailAlreadyExists = "Primary Email and Secondary Email should not be same";
        public const string AccountNoResponseTeam = "Sorry, your account seems not associated with any role";
        public const string LoginFailedStatus = "Failed Login";
        public const string LoginStatus = "Login";
        public const string AccountTrialExpired = "Your trial subscription package has been expired. Please subscribe to other package";
        public const string AccountNotExists = "Sorry we didn't recognize your login details or something went wrong with your account";
        public const string AccountNotAuthorize = "Your account is not authorized to use this service";
        public const string UserNamePasswordNotVaild = "User name or password is not valid";
        public const string FollowInstructionsForChangePassword = "Please check your email and follow the instructions to change password";
        public const string UsernameIncorrect = "The user name provided is incorrect";
        public const string ExpiredLink = "You may have clicked the expire link";
        public const string ProvidedEmailAlreadyExists = "The provided email address already registered. Please use another email";
        public const string ResetPassword = "Reset Password";
        public const string ComplexPasswordMinimumLength = "Password must contain minimum 10 characters, including numeric characters (0–9), uppercase alphabetic characters (A–Z), lowercase alphabetic characters (a–z) and special characters";
        public const string SimplePasswordMinimumLength = "Password must contain minimum 6 characters, including numeric characters (0–9), uppercase alphabetic characters (A–Z), lowercase alphabetic characters (a–z)";
        public const string ClientNotActiveOrDeleted = "It seems that your client currently not active or deleted";
        public const string CheckUserUpdatingError = "Error while updating";
        public const string EmailIDAlreadyExists = "This email id already in use";
        public const string AdminUserCreated = "Admin user created successfully";
        public const string UserCreated = "User created successfully";
        public const string BusinessImpactDescriptor = "Business impact descriptor data saved successfully";
        public const string SystemCategories = "System categories cannot be deleted";
        public const string YourCurrentPassword = "Your current password does not match";
        public const string YourPasswordChanged = "Your password has been changed successfully";
        public const string IncidentAssessmentQuestions = "Incident assessment questions data saved successfully";
        public const string NameOfYourApplication = "Name of Your Application";
        public const string NoDataFound = "No record(s) found!!";
        public const string ClientProfileUpdated = "Client profile updated successfully";
        public const string ClientProfileAdded = "Client profile added successfully";
        public const string AdminUserUpdated = "Admin user updated successfully";
        public const string UserAlreadyAssigned = "There is a user already assigned for this subset on this role and response team";

    }

    public static class StatusMessage
    {
        public const string VerifiedBusinessName = "Domain verified";
        public const string UnVerifiedBusinessName = "This domain not available please contact admin";
        public const string InvalidUserOrPassword = "Invalid username or password.";
        public const string UnknownError = "Sorry, we have encountered an error";
        public const string Success = "Data has been successfully inserted";
        public const string UserCustomFieldSaved = "User's custom fields has been saved successfully";
        public const string AgencySaved = "Agency has been saved successfully.";
        public const string AgencyUpdatedSuccessfully = "Agency has been updated successfully.";
        public const string AgencyAlredyExist = "Agency name already in use";
        public const string SoapSuccess = "Client encounter has been saved successfully.";
        public const string UserCustomFieldUpdated = "User's custom fields has been updated successfully";
        public const string UpdatedSuccessfully = "Data has been updated successfully";
        public const string UserCustomFieldDeleted = "User's custom fields has been deleted successfully";
        public const string Delete = "Data has been deleted successfully";
        public const string InvalidData = "Please enter valid data";
        public const string ModelState = "Model state is not valid";
        public const string InvalidToken = "Please enter valid token";
        public const string NotFound = "Data not found";
        public const string InvalidCredentials = "Please enter valid credentials.";
        public const string TokenRequired = "Token Required";
        public const string ResetPassword = "Reset password's email sent to user";
        public const string ServerError = "Internal Server error";
        public const string FetchMessage = "Success";
        public const string ClaimUpdated = "Claim has been updated successfully";
        public const string ClaimNotExist = "Claim doesn't exist";
        public const string AlreadyExists = "You cannot remove this record as it is associated somewhere in the application";
        public const string ServiceCodeAdded = "Service code has been saved successfully";
        public const string ServiceCodeUpdated = "Service code has been updated successfully";
        public const string ServiceCodeNotExists = "The service code do not exist";
        public const string ServiceCodeDelete = "Service code has been deleted successfully";
        public const string ServiceCodeAlreadyExists = "Service code already exist in the claim";
        public const string PatientAlreadyExist = "Client already exist";
        public const string StaffAlreadyExist = "Staff already exist";
        public const string AppointmentAlreadyExist = "Appointment type already exist";
        public const string QuestionAlreadyExist = "This question already exist";
        public const string AppointmentTypeAlreadyAssigned = "Appointment type already assigned to payer";
        public const string ClearingHouseAlreadyExist = "Clearing House already exist";
        public const string LocationAlreadyExist = "Location already exist.";
        public const string TagAlreadyExist = "Tag already exist";
        public const string AppConfigurationAlreadyExist = "This configuration already exist";
        public const string InsuranceCompaniesAlreadyExist = "Insurance company already exist";
        public const string CustomLabelAlreadyExist = "Custom field already exist";
        public const string ICDAlreadyExist = "Diagnosis code already exist";
        public const string UserAlreadyExist = "User already exist";
        public const string ModuleAlreadyExist = "Module already exist";
        public const string TemplateAlreadyExist = "Template already exist";
        public const string PatientICDAlreadyLink = "Client already linked with this diagnosis code";
        public const string PatientAllergyAlreadyLink = "Client already linked with this allergy";
        public const string PatientImmunizationAlreadyLink = "Client already linked with this immunization";
        public const string PatientInsuranceAlreadyLink = "Client already linked with this insurance company";
        public const string StaffCustomValue = "Can't insert duplicate values";
        public const string InsuarnceTypeAlreadyExist = "This insurance type already exist";
        public const string RecordAlreadyExists = "[string] already exist";// in table [table]";
        public const string RecordNotExists = "available";
        public const string AddAppointment = "Appointment has been saved successfully";
        public const string UpdateAppointment = "Appointment has been updated successfully";
        public const string DeleteAppointment = "Appointment has been deleted successfully";
        public const string CancelAppointment = "Appointment has been cancelled successfully";
        public const string DeleteAppointmentRecurrence = "Appointment recurring series has been deleted successfully";
        public const string AppointmentNotExists = "Appointment doesn't exist or has been deleted";
        public const string UserRoleAlreadyExist = "Role name already exist";
        public const string UserRoleAlreadyAssignedToUser = "This role is already assigned to user";

        public const string ClientPortalActivated = "Client portal activated successfully";
        public const string ClientPortalDeactivated = "Client portal deactivated successfully";

        public const string ClientActiveStatus = "Your profile is not active, please contact with your system administrator";
        public const string ClientPortalDeactivedAtLogin = "Your portal is not active, please contact with your system administrator";

        public const string ClientActivation = "Client activated successfully";
        public const string ClientDeactivation = "Client deactivated successfully";

        public const string UserActivation = "User activated successfully";
        public const string UserDeactivation = "User deactivated successfully";

        public const string LocationSaved = "Location has been saved successfully.";
        public const string LocationUpdated = "Location has been updated successfully.";

        public const string UserBlocked = "[RoleName] has been locked successfully.";
        public const string UserUnblocked = "[RoleName] has been unlocked successfully.";

        public const string StaffUpdated = "Staff has been updated";

        public const string CustomLabelSaved = "Custom field has been saved successfully.";
        public const string CustomLabelUpdated = "Custom field has been updated successfully.";
        public const string CustomLabelDeleted = "Custom field has been deleted successfully.";

        public const string APISavedSuccessfully = "[controller] has been saved successfully";
        public const string APIUpdatedSuccessfully = "[controller] has been updated successfully";
        public const string DeletedSuccessfully = "[controller] has been deleted successfully";

        public const string ErrorOccured = "Unfortunately, some error was encountered.";
        public const string AuthorizationProcedureSaved = "Authorization procedure has been saved successfully";
        public const string RoundingRuleNotDeleted = "Rounding rule can't deleted as its already assigned to some service codes";
        public const string RoundingRuleDeleted = "Rounding rule has been deleted sucessfully";

        public const string InvalidFile = "Please select a valid CCDA file";

        public const string CCDAImportedSuccessfully = "Patient information imported successfully";
        public const string CCDAError = "Error occured while importing Patient information";

        public const string EDI837SuccessfullyUploaded = "Claim file has been sent succesfully";
        public const string EDI837UploadError = "Some error occurred while sending claim file";
        public const string EDI837GenerationError = "Some error occurred while generating claim file";
        //public const string EDI837GenerationError = "Some error occurred while creating claim file";
        public const string EDI837ClientDataError = "Some error occurred while sending claim file due to incomplete client(s) data";
        public const string PaymentAdded = "Payment details have been added successfully";
        public const string PaymentUpdated = "Payment details have been updated successfully";
        public const string PaymentDetailNotExists = "Payment details you are trying to update do not exists in our records";

        public const string SavedStaffAvailability = "Staff availability has been saved successfully";
    }

    public static class PaymentStatusMessages
    {
        public const string PaymentSuccess = "Your transaction has been completed successfully";
        public const string PaymentFail = "We are sorry your transaction has not been completed";
        public const string PaymentDeclined = "Unfortunately your transaction has been declined by the bank";
        public const string PaymentRejected = "Unfortunately your transaction has been rejected by the bank";
        public const string PaymentUnknownError = "Unfortunately some unknown errors has occurred";
        public const string ReferenceGenerationError = "Unfortunately some errors has occurred while generating customer number";
        public const string PaymentRefund = "Unfortunately some errors has occurred while registering your account, your amount will be refunded in next 5-7 business days on same payment type. {0}";
        public const string PaymentRefundUpgradeDowngrade = "Unfortunately some errors has occurred while updating your account, your amount will be refunded in next 5-7 business days on same payment type. {0}";
        public const string NoPaymentRefund = "Unfortunately some errors has occurred while registering your account";
        public const string DuplicateTransaction = "Possible duplicate payment attempt. Please check your statement and confirm whether transaction has been processed before retrying";
        public const string PaymentConfirmationMessage = "The process has been completed successfully. A confirmation email has been sent to you";
    }

    public static class EntityStatusNotification
    {
        public const string EntityCreated = "Entity created succesfully";
        public const string EntityUpdated = "Entity has been updated successfully";
        public const string EntityDeleted = "Entity deleted successfully";

    }

    public static class OfficesStatusNotification
    {
        public const string OfficeCreated = "Office created succesfully";
        public const string OfficeUpdated = "Office has been updated successfully";
        public const string OfficeDeleted = "Office deleted successfully";

    }

    public static class RoleStatusNotification
    {
        public const string RoleCreated = "Role Created";
        public const string RoleUpdated = "Role Updated";
        public const string RoleDeleted = "Role Deleted";

    }

    public static class HullTypeStatusNotification
    {
        public const string HullTypeCreated = "HullType Created";
        public const string HullTypeUpdated = "HullType Updated";
        public const string HullTypeDeleted = "HullType Deleted";

    }
    public static class CommonErrorMessages
    {
        public const string UnknownError = "Sorry, we have encountered an error";
    }
    //public static class ImagesPath
    //{
    //    public const string PatientInsurancePhotos = "//Images//PatientInsurancePhotos//pic_";
    //    public const string PatientInsuranceThumbPhotos = "//Images//PatientInsurancePhotos//thumb//pic_thumb_";
    //    public const string PatientPhotos = "//Images//PatientPhotos//";
    //    public const string PatientThumbPhotos = "//Images//PatientPhotos//thumb//";
    //    public const string StaffPhotos = "//Images//StaffPhotos//";
    //    public const string StaffThumbPhotos = "//Images//StaffPhotos//thumb//";
    //    public const string PatientInsuranceFront = "//Images//PatientInsuranceFront//";
    //    public const string PatientInsuranceFrontThumb = "//Images//PatientInsuranceFront//thumb//";
    //    public const string PatientInsuranceBack = "//Images//PatientInsuranceBack//";
    //    public const string PatientInsuranceBackThumb = "//Images//PatientInsuranceBack//thumb//";
    //    public const string OrganizationImages = "//Images//Organization//"; //its used for both logo and favicon of the organization
    //    public const string EncounterSignImages = "//Images//Encounter//"; //its used for both logo and favicon of the organization
    //}

    public static class AuditLogsScreen
    {
        public const string PatientEncounter = "Patient Encounter";
        public const string Login = "Login";
        public const string Billing = "Billing";
        public const string AddServiceLine = "Add Service Line";
        public const string UpdateServiceLine = "Update Service Line";
        public const string DeleteServiceLine = "Delete Service Line";
        public const string UpdateClaim = "Update Claim";
        public const string CreateStaff = "Create Staff";
        public const string UpdateStaff = "Update Staff";
        public const string DeleteStaff = "Delete Staff";
        public const string UpdatePayerInfo = "Update Payer Information";
        public const string CreatePayerInfo = "Create Payer Information";
        public const string DeletePayerInfo = "Delete Payer Information";

        public const string UpdatePayerServiceCodes = "Update Payer ServiceCodes";
        public const string CreatePayerServiceCodes = "Create Payer ServiceCodes";
        public const string DeletePayerServiceCodes = "Delete Payer ServiceCodes";

        public const string UpdatePayerActivity = "Update Payer Activity";
        public const string CreatePayerActivity = "Create Payer Activity";
        public const string DeletePayerActivity = "Delete Payer Activity";

        public const string UpdateAppointmentType = "Update Appointment Type";
        public const string CreateAppointmentType = "Create Appointment Type";
        public const string DeleteAppointmentType = "Delete Appointment Type";

        public const string CreateRoundingRule = "Create Rounding Rule";
        public const string UpdateRoundingRule = "Update Rounding Rule";
        public const string DeleteRoundingRule = "Delete Rounding Rule";

        public const string CreateRoundingRuleDetails = "Create Rounding Rule Details";
        public const string UpdateRoundingRuleDetails = "Update Rounding Rule Details";
        public const string DeleteRoundingRuleDetails = "Delete Rounding Rule Details";
    }
    public static class AuditLogAction
    {
        public const string Create = "Create";
        public const string Modify = "Modify";
        public const string Delete = "Delete";
        public const string Access = "Access";
        public const string Login = "Login";
    }

    public static class LoginLogLoginAttempt
    {
        public const string Failed = "Failed";
        public const string Success = "Success";
    }
    public static class SecurityQuestionNotification
    {
        public const string RequiredAnswers = "Please give answers of these questions.";
        public const string AtleastOneAnswer = "Please answer any one from these questions.";
        public const string IncorrectAnswer = "Answer doesn't match please retry.";
    }

    public static class OCSConnectionStringEnum
    {
        //public const string Server = "108.168.203.227,7007";
        //public const string Database = "HC_Patient_Merging";
        //public const string User = "HC_Patient";
        //public const string Password = "HC_Patient";
        public const string Host = "OCS_ConnectionString";
    }
    //public static class OCSMasterConnectionStringEnum
    //{
    //    public const string Server = "108.168.203.227,7007";
    //    public const string Database = "HC_Patient_Master";
    //    public const string User = "HC_Patient";
    //    public const string Password = "HC_Patient";
    //    public const string Host = "HC_Patient";
    //}

}
