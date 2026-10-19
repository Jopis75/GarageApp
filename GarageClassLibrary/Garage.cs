using GarageClassLibrary.Exceptions;
using GarageClassLibrary.Interfaces;
using System.Diagnostics.Metrics;

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

        public int CountVehicleTypes()
        {
            return 0;
        }

        public Vehicle FindVehicle(string registrationNumber)
        {
            var index = FindVehicleIndex(registrationNumber);

            return vehicles[index];
        }

        private int FindVehicleIndex(string registrationNumber)
        {
            var index = Array.FindIndex(vehicles, 0, v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.CurrentCultureIgnoreCase));

            if (index == -1)
            {
                throw new NotFoundException($"Could not find vehicle with registration number {registrationNumber}.");
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
    }

    // 0 1 2 3 4 5 - - -
    // 0 1 2 4 5 - - - -
    //
}
