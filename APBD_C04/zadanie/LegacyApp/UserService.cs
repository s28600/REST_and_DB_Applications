using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateUserData(firstName, lastName, email, dateOfBirth)) return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            if (!CheckCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool ValidateUserData(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            
            return !string.IsNullOrEmpty(firstName) && 
                   !string.IsNullOrEmpty(lastName) &&
                   email.Contains("@") && 
                   email.Contains(".") && 
                   age >= 21;
        }

        private bool CheckCreditLimit(User user)
        {
            string clientType = ((Client)user.Client).Type;
            if (clientType == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
                return true;
            }
            
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                user.CreditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (clientType == "ImportantClient") user.CreditLimit *= 2;
            }
            
            return user.CreditLimit >= 500;
        }
    }
}
