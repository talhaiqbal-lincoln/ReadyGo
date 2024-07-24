using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

namespace ReadyGo.Domain.Constants
{
    public static class AppConstants
    {
        public static readonly string Admin = new Guid("F4EA0102-2C6D-453E-8365-CB45C956CC44").ToString();
        public static readonly string AdminUser = new Guid("569411C1-88EF-45B6-AB57-79665FBCD9A4").ToString();
        public static readonly string MarketingManager = new Guid("1570902E-48BB-4B03-850C-8EBD63261E33").ToString();
        public static readonly Guid MM_CustomerManagement = new Guid("300a3996-9801-4e9d-9fb3-048ac824589f");
        public static readonly Guid MM_SalesPersonManagement = new Guid("823f8343-acfc-4bf2-90de-6ec2d4bbf427");
        public static readonly Guid MM_StockManagement = new Guid("e1a248ed-6925-4252-95c5-a97982987508");
        public static readonly string SalePerson = new Guid("C057793D-9D0D-4F1D-9FB0-2335480D82E2").ToString();
        public static readonly string SalesManager = new Guid("4CE95B9B-0760-4F11-B576-71DFAA053E74").ToString();
        public static readonly Guid SM_CustomerManagement = new Guid("df802ea6-ffec-45b1-85e0-a6dd74c8bea4");
        public static readonly Guid SM_SalesPersonManagement = new Guid("26c69ac9-68cd-4f80-83a8-979770f3a826");
        public static readonly Guid SM_StockManagement = new Guid("64f495e3-8fa4-498e-b825-f8df85857e76");
        public static readonly Guid SM_DiscountThrashHold = new Guid("2581015c-adb0-4a25-932e-89c9807903a3");
        public static readonly Guid MM_DiscountThrashHold = new Guid("6d8f467b-a509-4556-b6c3-3327e1782709");
        public static readonly Guid TermsConditions = new Guid("AAC6F69D-5A41-4B2A-A4DA-7D5834A347A1");
    }

    public static class EmailConstants
    {
        public static readonly string InvitationBody = "Please accept the invite by registering ";
        public static readonly string InvitationSubject = "ReadyGo Invitation";
        public static readonly string PasswordResetBody = @"<div style='width:500px'>
                                                                <div>
                                                                    <p>Dear {0},</p>
                                                                </div>
                                                                <div>
                                                                    <p style='text-align: justify;text-justify: inter-word;'>We have received your request for Password Reset. To Reset Password, please click on button below.</p>
                                                                </div>
                                                                <div style='text-align: center;'>
                                                                    <a style='border: 1px solid black;padding: 5px 10px;text-decoration: none;border-radius: 3px;background-color: #efefef;color: black;' href='{1}'>Reset Password</a>
                                                                </div>
                                                                <div style='text-align:center'>
                                                                    <p>--or--</p>
                                                                </div>
                                                                <div>
                                                                    <p style='text-align: justify;text-justify: inter-word;'>Copy and paste the following link in your browser.Link:</p>
                                                                    <a style='overflow-wrap:break-word;' href='{1}'>{1}</a>
                                                                </div>
                                                                <div>
                                                                    <p style='text-align: justify;text-justify: inter-word;'>If you didn't initiate this request, please ignore this email.</p>
                                                                </div>
                                                                <br/>
                                                                <div>
                                                                    <span>Regards,</span><br/>
                                                                    <span>ReadyGo Admin</span>
                                                                </div>
                                                            </div>";
        public static readonly string PasswordResetSubject = "ReadyGo Password Reset";
        public static readonly string SendFail = "Could not send email ";
        public static readonly string SendSuccess = "Email sent successfully!";
        public static readonly string TestEmailBody = "This is a test email";
        public static readonly string TestEmailSubject = "Test email";
        public static readonly string EmailBodyHtml = @"<div style='width:500px'>
                                                            <div>
                                                                <p>Dear {0},</p>
                                                            </div>
                                                            <div>
                                                                <p style='text-align: justify;text-justify: inter-word;'>You have been invited to create an account for ReadyGo application. To complete your account
                                                                    creation, please click on button below.</p>
                                                            </div>
                                                            <div style='text-align: center;'>
                                                                <a style='border: 1px solid black;padding: 5px 10px;text-decoration: none;border-radius: 3px;background-color: #efefef;color: black;' href='{1}'>Click Here</a>
                                                            </div>
                                                            <div style='text-align:center'>
                                                                <p>--or--</p>
                                                            </div>
                                                            <div>
                                                                <p style='text-align: justify;text-justify: inter-word;'>Copy and paste the following link in your browser.Link:</p>
                                                                <a style='overflow-wrap:break-word;' href='{1}'>{1}</a>
                                                            </div>
                                                            <br/>
                                                            <div>
                                                                <span>Regards,</span><br/>
                                                                <span>ReadyGo Admin</span>
                                                            </div>
                                                        </div>";
        public static readonly string ContactUsSubject = "Customer want to contact";
    }

    public static class ErrorMessageConstants
    {
        public static readonly string AllCsvRecordsInvalid = "All records in the file are invalid.";
        public static readonly string AlreadyExistingDiscount = "{0} already exists {1}.";
        public static readonly string AlreadyExistsDeleted = "{0} already exist but deleted {1}.";
        public static readonly string CreateFail = "{0} creation failed.";
        public static readonly string DeleteFail = "{0} deletion failed.";
        public static readonly string UpdateFail = "{0} updation failed.";
        public static readonly string EmailUnconfirmed = "Please register by accepting the invite sent to your email.";
        public static readonly string Error = "An error occurred while processing this request.";
        public static readonly string InActive = "{0} is in-active.";
        public static readonly string InactiveLogin = "Sorry! Your account has been deactivated. Please contact the admin to reactivate your account.";
        public static readonly string InvalidEmailOrPassword = "Invalid Email or Password.";
        public static readonly string InvalidToken = "Invalid token detected.";
        public static readonly string LoginFailed = "Login Failed.";
        public static readonly string MoreThanFiftyRecords = "You can only insert a maximum of 500 records in one import.";
        public static readonly string MoreThanthousandRecords = "You can only insert a maximum of 1000 records in one import.";
        public static readonly string EmptyCsv = "File is empty.";
        public static readonly string NotFound = "{0} not found.";
        public static readonly string NotValid = "{0} is invalid.";
        public static readonly string SalesPersonLogin = "Sorry! SalesPerson can only login through the mobile app.";
        public static readonly string SetPasswordError = "{0} Registration Failed.";
        public static readonly string DeletedRegistration = "Sorry! your account may have been deleted. We are sorry for the inconvenience";
        public static readonly string RepeatedPassword = "Old and new passwords are same";
        public static readonly string CsvFields = "Please fill required fields as per instruction";
        public static readonly string MissingAPIKey = "The Api Key was not provided in the header.";
        public static readonly string InvalidAPIKey = "The Api Key is not valid.";
        public static readonly string InvalidHeader = "Must need to add BEARER keyword before API key.";
        public static readonly string InvalidGuid = "{0} not a valid Guid";

        public static readonly string RouteAlreadyExists = "Route Already Exists.";
        public static readonly string Required = "{0} is required.";
        public static readonly string StockAssigned = "Stock is already assigned to route for today.";
        public static readonly string NoRouteAssigned = "No route assigned to sales person";
        public static readonly string InvalidPromotion = "Selected promotions are not applicable";
        public static readonly string MultiplePromotions = "A product can only be assigned one promotion";

        // Client Api Constants
        public static readonly string InvalidDate = "Start Date must be less then End Date";
        public static readonly string InvalidAmount = "{0} must be greater then 0.";
        public static readonly string AlreadyExists = "{0} already exists.";
        public static readonly string InvalidPriceHistoryDate = "From date must be greater or equal to today's date";
    }

    public static class LabelConstants
    {
        public const int AddressMaxLength = 100;
        public const int AddressMinLength = 7;
        public const int NameMaxLength = 100;
        public const int CityMaxLength = 25;
        public const int NameMinLength = 2;
        public const int PasswordMaxLength = 16;
        public const int PasswordMinLength = 6;
    }

    public static class QuestionMessageConstants
    {
        public static readonly string ReAdd = "Do you wish to re-add ";
    }

    public static class RegexConstants
    {
        public const string OnlyAlphabets = @"^(?! |.* $)[A-Za-z ]+$";
        public const string Names = @"^(?! |.* $)[A-Za-z0-9 ]+$";
    }

    public static class SuccessMessageConstants
    {
        public static readonly string CreateSuccess = "{0} created successfully!";
        public static readonly string AddedSuccess = "{0} added successfully!";
        public static readonly string DefaultSuccess = "Operation executed successfully!";
        public static readonly string RecordNotFound = "No record exist!";
        public static readonly string DeleteSuccess = "{0} deleted successfully!";
        public static readonly string UserActiveSuccess = "{0} app access granted!";
        public static readonly string UserInactiveSuccess = "{0} app access blocked!";
        public static readonly string PasswordReset = "Password reset successfully!";
        public static readonly string ReAddSuccess = "{0} re-added successfully!";
        public static readonly string ResetPasswordLink = "Reset password link sent successfully!";
        public static readonly string ActiveSuccess = "{0} enabled successfully";
        public static readonly string InactiveSuccess = "{0} disabled successfully";
        public static readonly string UpdateSuccess = "{0} updated successfully!";
        public static readonly string AssignedSuccess = "{0} assigned successfully!";
        public static readonly string ApprovedSuccess = "{0} approved successfully";
        public static readonly string ReAdjustSuccess = "{0} re-adjusted successfully";
        public static readonly string UnMarkSuccess = "{0} un-marked successfully";
    }

    public static class ValidationErrorConstants
    {
        public const string AlphabetsError = "{0} must contains aplhanumeric characters only without leading and trailing spaces.";
        public const string MinLength = "{0} must be at least {2} characters long.";
        public const string MaxLength = "{0} must be less than {2} characters long.";
        public const string NoEmailFound = "No account is associated with this email.";
        public const string NotValid = "{0} is not valid.";
        public const string EmailNotValid = "Please enter email in valid format (someone@abc.xyz)";
        public const string NotValidOrInactive = "The Email Address doesn't exist or is in-active.";
        public const string PassMismatch = "Passwords do not match.";
        public const string PasswordFormat = "Password must contain 1 uppercase, 1 lowercase character and 1 number.";
        public const string RePassword = "Please enter the password again.";
        public const string RequiredError = "{0} is required.";
        public const string WrongDateError = "Date should be valid and cannot be from the past";
        public const string InvalidCsvError = "File format is invalid. Please verify format with sample file.";
    }
    public static class JwtAuthenticationConstants
    {
        public const string AuthenticationScheme = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme;
    }
    public static class NotificationConstants
    {
        public static readonly string TestNotificationCreation = "This notification is for testing  purposes. Redirect to url will be added once other modules are completed.";
        public static readonly string DiscountApproval = "Your approval is required for discounted order#{0}.";
        public static readonly string MarkedOrder = "Order# {0} is marked by {1} ({2}).";
        public static readonly string MarkedPayment = "Payment# {0} is marked by {1} ({2}).";
        public static readonly string UnMarkedOrder = "Order# {0} is unmark by admin ({1}).";
        public static readonly string UnMarkedPayment = "Payment# {0} is unmark by admin ({1}).";
        public static readonly string ReAdjustOrder = "Order# {0} is re adjusted by {1} ({2}).";
        public static readonly string ApproveOrder = "Order# {0} is approved by {1} ({2}).";
        public static readonly string CustomerAdded = "New customer ({0}) added by {1} ({2}).";
        public static readonly string RouteComplete = "{0} is completed by {1} ({2})";
        public static readonly string MultipleCustomers = "Multiple Customer are created againts {0}";
        public static readonly string TempRouteAssigned = "You have been assigned Route: {0} {1}.";
        public static readonly string RouteAssigned = "Your route is assigned to another salesperson {0}.";
    }
}