using System.Text.RegularExpressions;

namespace GarageClassLibrary.Validators
{
    public static class RegistrationNumberValidator
    {
        public static bool Validate(string registrationNumber)
        {
            //Regex regex = new Regex("^[A-HJ-NP-PR-TV-Z]{3}\\s?[0-9]{2}[0-9A-HJ-NP-PR-TV-Z]$\r\n");

            //return regex.IsMatch(registrationNumber);
            return true;
        }
    }
}
