using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Service.Interfaces
{
    public interface IValidationHelper
    {
        public string GetErrorStatus(List<string> emailExist, List<string> deletedEmail, List<string> duplicate, List<string> existingAxCode, List<string> duplicatAxCode, string email, string phoneNumber, string axCode, List<string> wrongRole = null, string userRole = null);
        public string GetErrorStatusCustomer(List<string> phoneExist, List<string> deletedPhone, List<string> duplicate, List<string> existAxCode, List<string> duplicatAxCode, string phoneNumber, string axCode, string routeName = null, List<string> routes = null);
        public bool IsDigitsOnly(string str);
    }
}
