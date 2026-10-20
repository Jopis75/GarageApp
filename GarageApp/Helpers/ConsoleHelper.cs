using GarageClassLibrary.Validators;

namespace GarageApp.Helpers
{
    public static class ConsoleHelper
    {
        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct
        {
            var enumInput = string.Empty;
            TEnum @enum;

            do
            {
                Console.Write(prompt);
                enumInput = Console.ReadLine();
            }
            while (Enum.TryParse<TEnum>(enumInput, out @enum) == false);

            return @enum;
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

        public static string ReadRegistrationNumber(string prompt)
        {
            var registrationNumber = string.Empty;

            do
            {
                Console.Write(prompt);
                registrationNumber = Console.ReadLine();
            }
            while (registrationNumber != null && RegistrationNumberValidator.Validate(registrationNumber.ToUpper()) == false);

            return registrationNumber!;
        }

        public static bool ReadYesNo(string prompt)
        {
            var answerInput = string.Empty;

            do
            {
                Console.Write(prompt);
                answerInput = Console.ReadLine();
            }
            while (answerInput != null
                && answerInput.Equals("y", StringComparison.CurrentCultureIgnoreCase) == false
                && answerInput.Equals("n", StringComparison.CurrentCultureIgnoreCase) == false);

            return answerInput!.Equals("y", StringComparison.CurrentCultureIgnoreCase);
        }

        public static void WriteErrorLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WriteGarageAppWelcomeInfo()
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
            Console.WriteLine();
        }

        public static void WriteSuccessLine(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
