using GarageClassLibrary.Validators;

namespace GarageApp.Helpers
{
    public static class ConsoleHelper
    {

        public static bool ReadContinue(string prompt)
        {
            var continueInput = string.Empty;
            
            do
            {
                Console.Write(prompt);
                continueInput = Console.ReadLine();
            }
            while (continueInput != null
                && continueInput.Equals("y", StringComparison.CurrentCultureIgnoreCase) == false
                && continueInput.Equals("n", StringComparison.CurrentCultureIgnoreCase) == false);

            return continueInput!.Equals("y", StringComparison.CurrentCultureIgnoreCase);
        }

        public static int ReadNumberOfParkingSpaces(string prompt)
        {
            var numberOfParkingSpacesInput = string.Empty;
            var numberOfParkingSpaces = 0;

            WriteGarageAppInfo();

            do
            {
                Console.Write(prompt);
                numberOfParkingSpacesInput = Console.ReadLine();
            }
            while (int.TryParse(numberOfParkingSpacesInput, out numberOfParkingSpaces) == false || numberOfParkingSpaces < 1 || numberOfParkingSpaces > int.MaxValue);

            return numberOfParkingSpaces;
        }

        public static string ReadRegistrationNumber(string prompt)
        {
            var registrationNumber = string.Empty;

            do
            {
                Console.Write(prompt);
                registrationNumber = Console.ReadLine();
            }
            while (registrationNumber != null && RegistrationNumberValidator.Validate(registrationNumber) == false);

            return registrationNumber!;
        }

        public static void WriteErrorLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void WriteGarageAppInfo()
        {
            Console.WriteLine(" ▄██████ ██████▄  ██████▄  ██████▄   ▄██████  ▄██████      ██████▄  ██████▄  ██████▄ \r\n▒▒▒  ▀▀▀ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▀ ▄▄▄  ▒▒▒ ▒▒▒  ▀▀▀ ▒▒▒  ▀▀▀      ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒\r\n███  ▄▄▄ ████████ ██████▄  ████████ ███ ████ █████▀        ████████ ██████▀  ██████▀ \r\n▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▄▄▄      ▒▒▒  ▒▒▒ ▒▒▒      ▒▒▒     \r\n ▀██████ ███  ███ ███  ███ ███  ███  ▀██████  ▀██████      ███  ███ ███      ███     ");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Garage App!");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteInfoLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
