using GarageApp.Helpers;
using GarageClassLibrary;
using GarageClassLibrary.Enums;
using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;

var garage = CreateGarage();

HandleMainMenu(garage);

static void HandleMainMenu(IGarage garage)
{
    try
    {
        ReadMainMenuSelection(garage);
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void HandleAddVehicle(IGarage garage)
{
    try
    {
        ReadAddVehicleMenuSelection(garage);
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
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

                Console.WriteLine("Remove vehicle from garage");
                Console.WriteLine("--------------------------");
                Console.WriteLine();

                ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
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

                Console.WriteLine("Remove vehicle from garage");
                Console.WriteLine("--------------------------");
                Console.WriteLine();

                var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

                Vehicle? removedVehicle = null;

                try
                {
                    removedVehicle = garage.RemoveVehicleByRegistrationNumber(registrationNumber);

                    Console.WriteLine();
                    ConsoleHelper.WriteSuccessLine("The vehicle was removed successfully.");
                }
                catch (VehicleNotFoundException ex)
                {
                    Console.WriteLine();
                    ConsoleHelper.WriteErrorLine($"The vehicle was not found: {ex.Message}");
                }

                Console.WriteLine();

                var @continue = ConsoleHelper.ReadYesNo("Do you want to remove another ('y', 'n')? ");

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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void HandleFindVehicles(IGarage garage)
{
    try
    {
        ReadFindVehiclesMenuSelection(garage);
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void HandleListVehicles(IGarage garage)
{
    try
    {
        if (garage.IsEmpty)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("List vehicles in garage");
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
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

            Console.WriteLine("List vehicles in garage");
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            garage.WriteVehicles();

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void HandleListVehicleTypes(IGarage garage)
{
    try
    {
        if (garage.IsEmpty)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("List vehicle types in garage");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            ConsoleHelper.WriteInfoLine("The garage is empty. Please add some vehicles.");
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

            Console.WriteLine("List vehicle types in garage");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Motorcycle);
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Car);
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Truck);
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Bus);
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Boat);
            Console.WriteLine();

            garage.WriteVehicleTypeCount(VehicleType.Airplane);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void ReadMainMenuSelection(IGarage garage)
{
    try
    {
        var quit = false;

        while (quit == false)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
            Console.WriteLine("1. Add a vehicle to the garage.");
            Console.WriteLine("2. Remove a vehicle from the garage.");
            Console.WriteLine("3. Find vehicle(s) in the garage.");
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
                    HandleFindVehicles(garage);
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
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void ReadAddVehicleMenuSelection(IGarage garage)
{
    try
    {
        var exit = false;

        while (exit == false)
        {
            if (garage.IsFull)
            {
                Console.Clear();

                ConsoleHelper.WriteGarageAppWelcomeInfo();
                ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

                Console.WriteLine();

                Console.WriteLine("What type of vehicle do you want to add?");
                Console.WriteLine();

                ConsoleHelper.WriteInfoLine("The garage is full.");
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
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void ReadFindVehiclesMenuSelection(IGarage garage)
{
    try
    {
        var exit = false;

        while (exit == false)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("How do you want to find the vehicles?");
            Console.WriteLine();

            Console.WriteLine("1. Find by registration number.");
            Console.WriteLine("2. Find by vehicle type.");
            Console.WriteLine("3. Find by vehicle type and fuel type.");
            Console.WriteLine("4. Exit to Main menu.");
            Console.WriteLine();
            Console.Write("Enter your selection: ");

            var selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    FindVehicleByRegistrationNumber(garage);
                    break;
                case "2":
                    FindByVehicleType(garage);
                    break;
                case "3":
                    FindByVehicleTypeAndFuelType(garage);
                    break;
                case "4":
                    exit = true;
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        ConsoleHelper.WriteErrorLine($"An unexpected error has occurred: {ex.Message}");
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static IGarage CreateGarage()
{
    try
    {
        Console.Clear();

        ConsoleHelper.WriteGarageAppWelcomeInfo();

        var numberOfParkingSpaces = ConsoleHelper.ReadInt($"Enter the number of parking spaces (> 0): ");

        var garage = new Garage(numberOfParkingSpaces);

        Console.WriteLine();

        var answer = ConsoleHelper.ReadYesNo("Do you want to add some vehicles to the garage ('y', 'n')? ");

        if (answer == true)
        {
            Vehicle[] vehicles =
            [
                new Car("ABC 12A", 4.0f, 4, 1, 2.0f, FuelType.Gasoline, 750.0f),
                new Car("DEF 34B", 4.5f, 5, 1, 2.0f, FuelType.Gasoline, 750.0f),
                new Truck("GHI 45C", 9.0f, 2, 1, 6.0f, FuelType.Gasoline, 40000.0f)
                //,new Bicycle("", 1.5f, 1)
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
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        throw;
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

                Console.WriteLine("Add vehicle to garage");
                Console.WriteLine("---------------------");
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

                Console.WriteLine("Add vehicle to garage");
                Console.WriteLine("---------------------");
                Console.WriteLine();

                var registrationNumber = string.Empty;

                while (true)
                {
                    registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

                    try
                    {
                        var vehilce = garage.FindVehicleByRegistrationNumber(registrationNumber);

                        Console.WriteLine();
                        ConsoleHelper.WriteErrorLine($"The registration number '{registrationNumber}' already exists.");
                        Console.WriteLine();
                    }
                    catch (VehicleNotFoundException)
                    {
                        break;
                    }
                }

                Vehicle? vehicle = null;

                var length = ConsoleHelper.ReadFloat("Enter the length in meters (> 0.0): ");
                var numberOfSeats = ConsoleHelper.ReadInt("Enter the number of seats (> 0): ");
                var numberOfEngines = ConsoleHelper.ReadInt("Enter the number of engines (> 0): ");
                var cylinderVolume = ConsoleHelper.ReadFloat("Enter the cylinder volume (> 0.0): ");
                var fuelType = ConsoleHelper.ReadEnum<FuelType>("Enter the fuel type ('Gasoline', 'Diesel'): ");

                if (motorVehicleType == MotorVehicleType.Motorcycle)
                {
                    var seatHeight = ConsoleHelper.ReadFloat("Enter the seat height (> 0.0): ");

                    vehicle = new Motorcycle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, seatHeight);
                }
                else if (motorVehicleType == MotorVehicleType.Car)
                {
                    var maxTrailerWeight = ConsoleHelper.ReadFloat("Enter the maximum trailer weight (> 0.0): ");

                    vehicle = new Car(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, maxTrailerWeight);
                }
                else if (motorVehicleType == MotorVehicleType.Truck)
                {
                    var maximumLoad = ConsoleHelper.ReadFloat("Enter the maximum load (> 0.0): ");

                    vehicle = new Truck(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, maximumLoad);
                }
                else if (motorVehicleType == MotorVehicleType.Bus)
                {
                    var numberOfPassengerSeats = ConsoleHelper.ReadInt("Enter the number of passenger seats (> 0): ");

                    vehicle = new Bus(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, numberOfPassengerSeats);
                }
                else if (motorVehicleType == MotorVehicleType.Boat)
                {
                    var draft = ConsoleHelper.ReadFloat("Enter the draft (> 0.0): ");

                    vehicle = new Boat(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, draft);
                }
                else if (motorVehicleType == MotorVehicleType.Airplane)
                {
                    var maxThrust = ConsoleHelper.ReadFloat("Enter the Max thrust (> 0.0): ");

                    vehicle = new Airplane(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType, maxThrust);
                }

                try
                {
                    garage.AddVehicle(vehicle!);

                    Console.WriteLine();
                    ConsoleHelper.WriteSuccessLine("The vehicle was added successfully.");
                    Console.WriteLine();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine();
                    ConsoleHelper.WriteErrorLine($"An error occurred while adding the vehicle: {ex.Message}");
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }

                var answer = ConsoleHelper.ReadYesNo("Do you want to add another ('y', 'n')? ");

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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void FindVehicleByRegistrationNumber(IGarage garage)
{
    try
    {
        if (garage.IsEmpty)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("Find vehicle by registration number");
            Console.WriteLine("-----------------------------------");
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

                Console.WriteLine("Find vehicle by registration number");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

                var registrationNumber = ConsoleHelper.ReadRegistrationNumber("Enter the registration number: ");

                try
                {
                    var vehicle = garage.FindVehicleByRegistrationNumber(registrationNumber);

                    Console.WriteLine();

                    vehicle.Write();
                }
                catch (VehicleNotFoundException ex)
                {
                    Console.WriteLine();
                    ConsoleHelper.WriteErrorLine($"The vehicle was not found: {ex.Message}");
                }

                Console.WriteLine();

                var answer = ConsoleHelper.ReadYesNo("Do you want to find another ('y', 'n')? ");

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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void FindByVehicleType(IGarage garage)
{
    try
    {
        if (garage.IsEmpty)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("Find vehicle(s) by vehicle type");
            Console.WriteLine("-------------------------------");
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

                Console.WriteLine("Find vehicle(s) by vehicle type");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();

                var motorVehicleType = ConsoleHelper.ReadEnum<MotorVehicleType>("Enter the vehicle type ('Motorcycle', 'Car', 'Truck', 'Bus', 'Boat', 'Airplane'): ");

                var vehicles = garage.FindVehiclesByMotorVehicleType(motorVehicleType);

                Console.WriteLine();

                if (vehicles.Length > 0)
                {
                    ConsoleHelper.WriteInfoLine($"Found {vehicles.Length} vehicles with vehicle type '{motorVehicleType}'.");
                    Console.WriteLine();

                    foreach (var vehicle in vehicles)
                    {
                        vehicle.Write();
                        Console.WriteLine();
                    }
                }
                else
                {
                    ConsoleHelper.WriteInfoLine($"Could not find any vehicles with vehicle type '{motorVehicleType}'.");
                    Console.WriteLine();
                }

                var answer = ConsoleHelper.ReadYesNo("Do you want to find another ('y', 'n')? ");

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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}

static void FindByVehicleTypeAndFuelType(IGarage garage)
{
    try
    {
        if (garage.IsEmpty)
        {
            Console.Clear();

            ConsoleHelper.WriteGarageAppWelcomeInfo();
            ConsoleHelper.WriteInfoLine(garage.GetStatusInfoString());

            Console.WriteLine();

            Console.WriteLine("Find vehicle(s) by vehicle type and fuel type");
            Console.WriteLine("---------------------------------------------");
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

                Console.WriteLine("Find vehicle(s) by vehicle type and fuel type");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();

                var motorVehicleType = ConsoleHelper.ReadEnum<MotorVehicleType>("Enter the vehicle type ('Motorcycle', 'Car', 'Truck', 'Bus', 'Boat', 'Airplane'): ");
                var fuelType = ConsoleHelper.ReadEnum<FuelType>("Enter the fuel type ('Gasoline', 'Diesel'): ");
            
                var vehicles = garage.FindVehiclesByMotorVehicleTypeAndFuelType(motorVehicleType, fuelType);

                Console.WriteLine();

                if (vehicles.Length > 0)
                {
                    ConsoleHelper.WriteInfoLine($"Found {vehicles.Length} vehicles with vehicle type '{motorVehicleType}' and fuel type '{fuelType}'.");
                    Console.WriteLine();

                    foreach (var vehicle in vehicles)
                    {
                        vehicle.Write();
                        Console.WriteLine();
                    }
                }
                else
                {
                    ConsoleHelper.WriteInfoLine($"Could not find any vehicles with vehicle type '{motorVehicleType}' and fuel type '{fuelType}'.");
                    Console.WriteLine();
                }

                var answer = ConsoleHelper.ReadYesNo("Do you want to find another ('y', 'n')? ");

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
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}