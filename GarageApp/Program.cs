using GarageClassLibrary;
using GarageClassLibrary.Interfaces;

var garage = HandleCreateGarage();

HandleMainMenu(garage);



static IGarage HandleCreateGarage()
{
    var numberOfParkingSpaces = ReadNumberOfParkingSpaces();

    var garage = new Garage(numberOfParkingSpaces);

    return garage;
}

static void HandleMainMenu(IGarage garage)
{
    ReadMainMenuSelection(garage);
}

static void WriteGarageAppInfo()
{
    Console.WriteLine(" ▄██████ ██████▄  ██████▄  ██████▄   ▄██████  ▄██████      ██████▄  ██████▄  ██████▄ \r\n▒▒▒  ▀▀▀ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▀ ▄▄▄  ▒▒▒ ▒▒▒  ▀▀▀ ▒▒▒  ▀▀▀      ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒ ▄▄▄  ▒▒▒\r\n███  ▄▄▄ ████████ ██████▄  ████████ ███ ████ █████▀        ████████ ██████▀  ██████▀ \r\n▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▒▒▒ ▒▒▒  ▄▄▄      ▒▒▒  ▒▒▒ ▒▒▒      ▒▒▒     \r\n ▀██████ ███  ███ ███  ███ ███  ███  ▀██████  ▀██████      ███  ███ ███      ███     ");
    Console.WriteLine();
    Console.WriteLine("Welcome to the Garage App!");
    Console.WriteLine();
    Console.WriteLine();
}

static void WriteGarageStatusInfoLine(IGarage garage)
{
    var infoLine = $"The garage has a total of {garage.NumberOfParkingSpaces} parking spaces.";

    if (garage.IsEmpty)
    {
        infoLine += " The garage is empty.";
    }
    else if (garage.IsFull)
    {
        infoLine += " The garage is full.";
    }
    else
    {
        infoLine += " And there are currently {garage.NumberOfVehicles} vehicles in the garage.";
    }

    WriteInfoLine(infoLine);
}

static int ReadNumberOfParkingSpaces()
{
    var numberOfParkingSpacesInput = string.Empty;
    var numberOfParkingSpaces = 0;

    WriteGarageAppInfo();

    do
    {
        Console.Write($"Please enter the number of parking spaces (>= 1 and <= {int.MaxValue}): ");
        numberOfParkingSpacesInput = Console.ReadLine();
    }
    while (int.TryParse(numberOfParkingSpacesInput, out numberOfParkingSpaces) == false || numberOfParkingSpaces < 1 || numberOfParkingSpaces > int.MaxValue);

    return numberOfParkingSpaces;
}

static void ReadMainMenuSelection(IGarage garage)
{
    var quit = false;

    while (!quit)
    {
        Console.Clear();

        WriteGarageAppInfo();

        WriteGarageStatusInfoLine(garage);
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("What do you want to do?");
        Console.WriteLine();
        Console.WriteLine("1. Add vehicle to garage.");
        Console.WriteLine("2. Remove vehicle from garage.");
        Console.WriteLine("3. Find vehicle in garage.");
        Console.WriteLine("4. List all vehicles in garage.");
        Console.WriteLine("5. List all vehicle types in garage.");
        Console.WriteLine("6. Quit.");
        Console.WriteLine();
        Console.Write("Enter your selection: ");

        var selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                // OnAddVehicle();
                break;
            case "2":
                // OnRemoveVehicle();
                break;
            case "3":
                // OnFindVehicle();
                break;
            case "4":
                // OnListVehicles();
                break;
            case "5":
                // OnListVehicleTypes();
                break;
            case "6":
                quit = true;
                break;
        }
    }
}

static void WriteErrorLine(string message)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
}

static void WriteInfoLine(string message)
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
}
