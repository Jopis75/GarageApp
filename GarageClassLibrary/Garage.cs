using GarageClassLibrary.Enums;
using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public class Garage(int numberOfParkingSpaces) : IGarage
    {
        private int numberOfVehicles = 0;

        private readonly Vehicle[] vehicles = new Vehicle[numberOfParkingSpaces];

        public bool IsEmpty => NumberOfVehicles == 0;

        public bool IsFull => NumberOfVehicles >= numberOfParkingSpaces;

        public int NumberOfParkingSpaces => numberOfParkingSpaces;

        public int NumberOfVehicles => numberOfVehicles;

        public void AddVehicle(Vehicle vehicle)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException("The garage is full.");
            }

            vehicles[numberOfVehicles] = vehicle;

            numberOfVehicles++;
        }

        public int CountVehicleType(VehicleType vehicleType)
        {
            var vehicleTypeName = vehicleType.ToString();

            var count = 0;

            for (var i = 0; i < numberOfVehicles; i++)
            {
                if (vehicles[i].GetType().Name == vehicleTypeName)
                {
                    count++;
                }
            }

            return count;
        }

        public Vehicle FindVehicle(string registrationNumber)
        {
            var index = FindVehicleIndex(registrationNumber);

            return vehicles[index];
        }

        private int FindVehicleIndex(string registrationNumber)
        {
            var index = Array.FindIndex(vehicles, 0, v => v != null && v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));

            if (index == -1)
            {
                throw new VehicleNotFoundException(registrationNumber);
            }

            return index;
        }

        public string GetStatusInfoString()
        {
            var infoLine = $"The garage has a total of {numberOfParkingSpaces} parking spaces.";

            if (IsEmpty)
            {
                infoLine += " The garage is empty.";
            }
            else if (IsFull)
            {
                infoLine += " The garage is full.";
            }
            else
            {
                infoLine += $" There are currently {numberOfVehicles}" + (numberOfVehicles == 1 ? " vehicle" : " vehicles") + " in the garage.";
            }

            return infoLine;
        }

        private Vehicle RemoveVehicle(int index)
        {
            var vehicle = vehicles[index];

            var tempVehicles = new Vehicle[numberOfParkingSpaces];

            for (int i = 0, j = 0; i < numberOfVehicles; i++)
            {
                if (i != index)
                {
                    tempVehicles[j] = vehicles[i];
                    j++;
                }
            }

            Array.Copy(tempVehicles, vehicles, tempVehicles.Length);

            numberOfVehicles--;

            return vehicle;
        }

        public Vehicle RemoveVehicle(string registrationNumber)
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The garage is empty.");
            }

            var index = FindVehicleIndex(registrationNumber);

            var vehicle = RemoveVehicle(index);

            return vehicle;
        }

        public static void WriteVehicle(MotorVehicle motorVehicle)
        {
            Console.WriteLine($"Vehicle type: {motorVehicle.GetType().Name}");
            Console.WriteLine($"Registration number: {motorVehicle.RegistrationNumber}");
            Console.WriteLine($"Length: {motorVehicle.Length}");
            Console.WriteLine($"Number of seats: {motorVehicle.NumberOfSeats}");
            Console.WriteLine($"Number of engines: {motorVehicle.NumberOfEngines}");
            Console.WriteLine($"Cylinder volumne: {motorVehicle.CylinderVolume}");
            Console.WriteLine($"Fuel type: {motorVehicle.FuelType}");
        }

        public void WriteVehicles()
        {
            var i = 0;
            for (; i < numberOfVehicles - 1; i++)
            {
                vehicles[i].Write();
                Console.WriteLine();
            }

            vehicles[i].Write();
        }

        public void WriteVehicleTypeInfo(VehicleType vehicleType)
        {
            var count = CountVehicleType(vehicleType);

            Console.WriteLine($"Vehicle type: {vehicleType}");
            Console.WriteLine($"Count: {count}");
        }
    }

    // 0 1 2 3 4 5 - - -
    // 0 1 2 4 5 - - - -
    //
}
