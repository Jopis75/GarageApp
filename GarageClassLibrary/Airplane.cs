using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Airplane(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
    }
}
