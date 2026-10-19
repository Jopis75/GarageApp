using GarageClassLibrary.Enums;
using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public abstract class Vehicle(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType) : IVehicle
    {
        public float CylinderVolume { get { return cylinderVolume; } set { cylinderVolume = value; } }

        public FuelType FuelType { get { return fuelType; } set { fuelType = value; } }

        public float Length { get { return length; } set { length = value; } }

        public int NumberOfEngines { get { return numberOfEngines; } set { numberOfEngines = value; } }

        public int NumberOfSeats { get { return numberOfSeats; } set { numberOfSeats = value; } }

        public string RegistrationNumber { get { return registrationNumber; } }

        public int NumberOfOccupiedParkingSpaces => throw new NotImplementedException();
    }
}
