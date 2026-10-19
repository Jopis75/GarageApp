using GarageApp.Helpers;
using GarageClassLibrary;
using GarageClassLibrary.Enums;
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

static void ReadMainMenuSelection(IGarage garage)
{
    var quit = false;

    while (!quit)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("What do you want to do?");
        Console.WriteLine();
        Console.WriteLine("1. Add a vehicle to the garage.");
        Console.WriteLine("2. Remove a vehicle from the garage.");
        Console.WriteLine("3. Find a vehicle in the garage.");
        Console.WriteLine("4. List all vehicles in the garage.");
        Console.WriteLine("5. List all vehicle types in the garage.");
        Console.WriteLine("6. Quit.");
        Console.WriteLine();
        Console.Write("Enter your selection: ");

        var selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                ReadAddVehicleMenuSelection(garage);
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

static void ReadAddVehicleMenuSelection(IGarage garage)
{
    var exit = false;

    while (!exit)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("What type of vehicle do you want to add the garage?");
        Console.WriteLine();
        Console.WriteLine("1. A bicycle.");
        Console.WriteLine("2. A motorcycle.");
        Console.WriteLine("3. A car.");
        Console.WriteLine("4. A truck.");
        Console.WriteLine("5. A bus.");
        Console.WriteLine("6. A boat.");
        Console.WriteLine("7. An airplane.");
        Console.WriteLine("8. Exit.");
        Console.WriteLine();
        Console.Write("Enter your selection: ");

        var selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                // AddBicycle();
                break;
            case "2":
                AddMotorVehicle(garage, MotorVehicleType.Motorcycle);
                break;
            case "3":
                AddMotorVehicle(garage, MotorVehicleType.Car);
                break;
            case "4":
                AddMotorVehicle(garage, MotorVehicleType.Truck);
                break;
            case "5":
                AddMotorVehicle(garage, MotorVehicleType.Bus);
                break;
            case "6":
                AddMotorVehicle(garage, MotorVehicleType.Boat);
                break;
            case "7":
                AddMotorVehicle(garage, MotorVehicleType.Airplane);
                break;
            case "8":
                exit = true;
                break;
        }
    }
}

static void AddMotorVehicle(IGarage garage, MotorVehicleType motorVehicleType)
{
    try
    {
        while (true)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();
            Console.WriteLine();

            var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");
            var length = ConsoleHelper.ReadInt("Enter the length in meters (> 0.0): ");
            var numberOfSeats = ConsoleHelper.ReadInt("Enter the number of seats (> 0): ");
            var numberOfEngines = ConsoleHelper.ReadInt("Enter the number of engines (> 0): ");
            var cylinderVolume = ConsoleHelper.ReadFloat("Enter the cylinder volume (> 0.0): ");
            var fuelType = ConsoleHelper.ReadFuelType("Enter the fuel type ('Gasoline', 'Diesel'): ");

            Vehicle vehicle = motorVehicleType switch
            {
                MotorVehicleType.Motorcycle => new Motorcycle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType),
                MotorVehicleType.Car => new Car(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType),
                MotorVehicleType.Truck => new Truck(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType),
                MotorVehicleType.Bus => new Bus(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType),
                MotorVehicleType.Boat => new Boat(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType),
                MotorVehicleType.Airplane => new Airplane(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
            };

            try
            {
                garage.AddVehicle(vehicle);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine();
                ConsoleHelper.WriteErrorLine($"An error occurred while adding the vehicle: {ex.Message}");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine();
            ConsoleHelper.WriteSuccessLine("The vehicle was added successfully.");
            Console.WriteLine();
            Console.WriteLine();

            var @continue = ConsoleHelper.ReadContinue("Do you want to add another ('y', 'n')? ");

            if (@continue == false)
            {
                break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}
