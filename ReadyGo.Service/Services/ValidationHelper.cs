using ReadyGo.Domain.Enum;
using ReadyGo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Service.Services
{
    public class ValidationHelper : IValidationHelper 
    {
        public string GetErrorStatus(List<string> emailExist, List<string> deletedEmail, List<string> duplicate, List<string> existingAxCode, List<string> duplicatAxCode, string email, string phoneNumber, string axCode, List<string> wrongRole = null, string role = null)
        {
            List<string> Errors = new List<string>();
            if (deletedEmail.Contains(email))
            {
                Errors.Add("Deleted");
            }
            else
            {
                if (emailExist.Contains(email))
                    Errors.Add("User already exists against this email");
                if (wrongRole !=null && wrongRole.Contains(email))
                    Errors.Add("Wrong role entered");
                if (existingAxCode.Contains(axCode) && !string.IsNullOrEmpty(axCode))
                    Errors.Add("The AxCode already exist.");
                if (duplicate.Contains(email))
                    Errors.Add("The Email should be unique.");
                if (duplicatAxCode.Contains(axCode))
                    Errors.Add("The AxCode should be unique.");
                if (role == Roles.Admin.ToString())
                    Errors.Add("User with admin role can't be added");
                if (string.IsNullOrEmpty(role))
                    Errors.Add("The Role field is required.");
            }
            return Errors.Count > 1 ? String.Join(",", Errors) : Errors.Count == 1 ? Errors.FirstOrDefault() : string.Empty;
        }

        public string GetErrorStatusCustomer(List<string> phoneExist, List<string> deletedPhone, List<string> duplicate, List<string> existAxCode, List<string> duplicatAxCode, string phoneNumber, string axCode, string routeName = null, List<string> routes = null)
        {
            List<string> Errors = new List<string>();
            if (deletedPhone.Contains(phoneNumber))
            {
                Errors.Add("Deleted");
            }
            else
            {
                if(phoneExist.Contains(phoneNumber))
                    Errors.Add("Customer already exists against this mobile number");
                if (duplicate.Contains(phoneNumber?.Split('+')[1]))
                    Errors.Add("The Mobile Number should be unique.");
                if (duplicatAxCode.Contains(axCode))
                    Errors.Add("The AxCode should be unique.");
                if (existAxCode.Contains(axCode) && !string.IsNullOrEmpty(axCode))
                    Errors.Add("The AxCode already exist.");
                    if (routes != null)
                {
                    var flag = false;
                    if (routeName == string.Empty)
                    {
                        flag = true;
                        Errors.Add("RouteName is required");
                    }
                    if (!routes.Contains(routeName, StringComparer.OrdinalIgnoreCase) && !flag)
                        Errors.Add("Invalid RouteName");
                }
            }
            return Errors.Count > 1 ? String.Join(",", Errors) : Errors.Count == 1 ? Errors.FirstOrDefault() : string.Empty;
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
