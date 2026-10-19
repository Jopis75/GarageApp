using GarageApp.Helpers;
using GarageClassLibrary;
using GarageClassLibrary.Interfaces;

var garage = HandleCreateGarage();

HandleMainMenu(garage);



static IGarage HandleCreateGarage()
{
    var numberOfParkingSpaces = ConsoleHelper.ReadNumberOfParkingSpaces($"Enter the number of parking spaces (>= 1 and <= {int.MaxValue}): ");

    var garage = new Garage(numberOfParkingSpaces);

    return garage;
}

static void HandleMainMenu(IGarage garage)
{
    ReadMainMenuSelection(garage);
}

static void HandleAddVehicleMenu(IGarage garage)
{
    var quit = false;

    while (quit == false)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

        Console.WriteLine();

        var @continue = ConsoleHelper.ReadContinue("Do you want to add another (y/n)? ");

        if (@continue == false)
        {
            quit = true;
        }
    }
}

static void ReadMainMenuSelection(IGarage garage)
{
    var quit = false;

    while (!quit)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

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
                HandleAddVehicleMenu(garage);
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


