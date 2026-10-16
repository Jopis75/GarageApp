using GarageClassLibrary.Enums;

namespace GarageClassLibrary.Interfaces
{
    public interface IVehicle
    {
        float CylinderVolume { get; }

        FuelType FuelType { get; }

        float Length { get; }

        int NumberOfEngines { get; }

        int NumberOfSeats { get; }

        string RegistrationNumber { get; }
    }
}
