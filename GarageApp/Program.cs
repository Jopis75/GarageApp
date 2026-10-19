using GarageApp.Helpers;
using GarageClassLibrary;
using GarageClassLibrary.Enums;
using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;

var garage = HandleCreateGarage();

HandleMainMenu(garage);



static IGarage HandleCreateGarage()
{
    try
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();

        var numberOfParkingSpaces = ConsoleHelper.ReadInt($"Enter the number of parking spaces (> 0): ");

        var garage = new Garage(numberOfParkingSpaces);

        Console.WriteLine();

        var answer = ConsoleHelper.ReadYesNoAnswer("Do you want to pre populate the garage ('y', 'n')? ");

        if (answer == true)
        {
            Vehicle[] vehicles =
            [
                new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline),
                new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline),
                new Truck("GHI 45C", 9.0f, 2, 1, 6.0f, FuelType.Gasoline)
            ];

            var length = Math.Min(garage.NumberOfParkingSpaces, vehicles.Length);

            for (var i = 0; i < length; i++)
            {
                try
                {
                    garage.AddVehicle(vehicles[i]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine();
                    ConsoleHelper.WriteErrorLine($"An error occurred while adding the vehicle: {ex.Message}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        return garage;
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        throw;
    }
}

static void HandleMainMenu(IGarage garage)
{
    ReadMainMenuSelection(garage);
}

static void HandleAddVehicle(IGarage garage)
{
    ReadAddVehicleMenuSelection(garage);
}

static void HandleRemoveVehicle(IGarage garage)
{
    try
    {
        while (true)
        {
            if (garage.IsEmpty)
            {
                Console.Clear();

                ConsoleHelper.WriteGarageAppWelcomeInfo();
                ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Which vehicle do you want to remove?");
                Console.WriteLine();

                ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.Clear();

                ConsoleHelper.WriteGarageAppWelcomeInfo();
                ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Which vehicle do you want to remove?");
                Console.WriteLine();

                var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

                Vehicle? removedVehicle = null;

                try
                {
                    removedVehicle = garage.RemoveVehicle(registrationNumber);

                    Console.WriteLine();
                    ConsoleHelper.WriteSuccessLine("The vehicle was removed successfully.");
                    Console.WriteLine();
                }
                catch (VehicleNotFoundException ex)
                {
                    Console.WriteLine();
                    ConsoleHelper.WriteErrorLine($"The vehicle was not found: {ex.Message}");
                    Console.WriteLine();
                }

                Console.WriteLine();

                var @continue = ConsoleHelper.ReadYesNoAnswer("Do you want to remove another ('y', 'n')? ");

                if (@continue == false)
                {
                    break;
                }
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

static void HandleFindVehicle(IGarage garage)
{
    if (garage.IsEmpty)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Which vehicle do you want to find?");
        Console.WriteLine();

        ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        while (true)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Which vehicle do you want to find?");
            Console.WriteLine();

            var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

            try
            {
                var vehicle = garage.FindVehicle(registrationNumber);

                Console.WriteLine();
                Garage.WriteVehicle(vehicle as MotorVehicle);
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine();
                ConsoleHelper.WriteErrorLine($"The vehicle was not found: {ex.Message}");
                Console.WriteLine();
            }

            Console.WriteLine();

            var answer = ConsoleHelper.ReadYesNoAnswer("Do you want to find another ('y', 'n')? ");

            if (answer == false)
            {
                break;
            }
        }
    }
}

static void HandleListVehicles(IGarage garage)
{
    if (garage.IsEmpty)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("This is the list of vehicles.");
        Console.WriteLine();

        ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("This is the list of vehicles.");
        Console.WriteLine();

        garage.WriteVehicles();

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void HandleListVehicleTypes(IGarage garage)
{
    if (garage.IsEmpty)
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("This is the list of vehicle types.");
        Console.WriteLine();

        ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();
        ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("This is the list of vehicle types.");
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Motorcycle);
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Car);
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Truck);
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Bus);
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Boat);
        Console.WriteLine();

        garage.WriteVehicleTypeInfo(VehicleType.Airplane);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
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
                HandleAddVehicle(garage);
                break;
            case "2":
                HandleRemoveVehicle(garage);
                break;
            case "3":
                HandleFindVehicle(garage);
                break;
            case "4":
                HandleListVehicles(garage);
                break;
            case "5":
                HandleListVehicleTypes(garage);
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
        if (garage.IsFull)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("What type of vehicle do you want to add?");
            Console.WriteLine();

            ConsoleHelper.WriteInfoLine("The garage is full.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            break;
        }
        else
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("What type of vehicle do you want to add?");
            Console.WriteLine();
            Console.WriteLine("1. A bicycle.");
            Console.WriteLine("2. A motorcycle.");
            Console.WriteLine("3. A car.");
            Console.WriteLine("4. A truck.");
            Console.WriteLine("5. A bus.");
            Console.WriteLine("6. A boat.");
            Console.WriteLine("7. An airplane.");
            Console.WriteLine("8. Exit to Main menu.");
            Console.WriteLine();
            Console.Write("Enter your selection: ");

            var selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    // AddBicycle(garage, ???);
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
}

static void AddMotorVehicle(IGarage garage, MotorVehicleType motorVehicleType)
{
    try
    {
        while (true)
        {
            if (garage.IsFull)
            {
                Console.Clear();

                ConsoleHelper.WriteGarageAppWelcomeInfo();
                ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("What type of vehicle do you want to add?");
                Console.WriteLine();

                ConsoleHelper.WriteInfoLine("The garage is full.");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.Clear();

                ConsoleHelper.WriteGarageAppWelcomeInfo();
                ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

                Console.WriteLine();
                Console.WriteLine();

                var registrationNumber = string.Empty;

                while (true)
                {
                    registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

                    try
                    {
                        var vehilce = garage.FindVehicle(registrationNumber);

                        Console.WriteLine();
                        ConsoleHelper.WriteErrorLine($"The registration number '{registrationNumber}' already exists.");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    catch (VehicleNotFoundException ex)
                    {
                        break;
                    }
                }

                var length = ConsoleHelper.ReadFloat("Enter the length in meters (> 0.0): ");
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

                var answer = ConsoleHelper.ReadYesNoAnswer("Do you want to add another ('y', 'n')? ");

                if (answer == false)
                {
                    break;
                }
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