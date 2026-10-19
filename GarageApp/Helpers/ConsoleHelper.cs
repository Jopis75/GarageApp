using GarageClassLibrary.Enums;
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

        public static float ReadFloat(string prompt)
        {
            var floatInput = string.Empty;
            var @float = 0.0f;

            do
            {
                Console.Write(prompt);
                floatInput = Console.ReadLine();
            }
            while (float.TryParse(floatInput, out @float) == false || !(@float > 0.0f) || @float > float.MaxValue);

            return @float;
        }

        public static FuelType ReadFuelType(string prompt)
        {
            var fuelTypeInput = string.Empty;
            FuelType fuelType;

            do
            {
                Console.Write(prompt);
                fuelTypeInput = Console.ReadLine();
            }
            while (Enum.TryParse<FuelType>(fuelTypeInput, out fuelType) == false);

            return fuelType;
        }

        public static int ReadInt(string prompt)
        {
            var intInput = string.Empty;
            var @int = 0;

            do
            {
                Console.Write(prompt);
                intInput = Console.ReadLine();
            }
            while (int.TryParse(intInput, out @int) == false || @int < 1 || @int > int.MaxValue);

            return @int;
        }

        public static int ReadNumberOfParkingSpaces(string prompt)
        {
            var numberOfParkingSpacesInput = string.Empty;
            var numberOfParkingSpaces = 0;

            WriteGarageAppWelcomeInfo();

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

        public static void WriteGarageAppWelcomeInfo()
        {
            Console.WriteLine(" ▄██████ ██████▄  ██████▄  ██████▄   ▄██████  ▄██████      ██████▄  ██████▄  ██████▄ \r\n▒▒▒  ▀▀▀ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▀ ▄▄▄  ▒▒▒ ▒▒▒  ▀▀▀ ▒▒▒  ▀▀▀      ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒\r\n███  ▄▄▄ ████████ ██████▄  ████████ ███ ████ █████▀        ████████ ██████▀  ██████▀ \r\n▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▄▄▄      ▒▒▒  ▒▒▒ ▒▒▒      ▒▒▒     \r\n ▀██████ ███  ███ ███  ███ ███  ███  ▀██████  ▀██████      ███  ███ ███      ███     ");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Garage App!");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteGarageAppThankYouForUsingInfo()
        {
            Console.WriteLine("█████████ ███  ███ ██████▄  ██████▄  ███  ███      ███  ███ ██████▄  ███  ███ ███\r\n▀▀ ▒▒▒ ▀▀ ▒▒▒  ▒▒▒ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒ ▒▒▒ ▄▒▒▀      ▒▒▒▄ ▒▒▒ ▄▄▄  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒\r\n   ███    ████████ ████████ ███  ███ ██████▄        ▀██████ ███  ███ ███  ███ ███\r\n   ▒▒▒    ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒ ▀▒▒▒          ▄▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▀▀▀\r\n   ███    ███  ███ ███  ███ ███  ███ ███  ███      ██████▀   ▀████▀   ▀████▀  ███");
            Console.WriteLine("Thank you for using the Garage App!");
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

        public static void WriteSuccessLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
