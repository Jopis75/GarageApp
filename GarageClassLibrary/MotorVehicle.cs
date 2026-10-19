using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public abstract class MotorVehicle(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType) : Vehicle(registrationNumber, length, numberOfSeats)
    {
        public float CylinderVolume { get { return cylinderVolume; } set { cylinderVolume = value; } }

        public FuelType FuelType { get { return fuelType; } set { fuelType = value; } }

        public int NumberOfEngines { get { return numberOfEngines; } set { numberOfEngines = value; } }
    }
}
