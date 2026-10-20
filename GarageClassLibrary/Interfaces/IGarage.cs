using GarageClassLibrary.Enums;

namespace GarageClassLibrary.Interfaces
{
    public interface IGarage
    {
        bool IsEmpty { get; }

        bool IsFull { get; }

        int NumberOfParkingSpaces { get; }

        int NumberOfVehicles { get; }

        void AddVehicle(Vehicle vehicle);

        int CountVehicleType(VehicleType vehicleType);

        Vehicle[] FindVehiclesByMotorVehicleType(MotorVehicleType motorVehicleType);

        Vehicle FindVehicleByRegistrationNumber(string registrationNumber);

        string GetStatusInfoString();

        Vehicle RemoveVehicle(string registrationNumber);

        void WriteVehicles();

        void WriteVehicleTypeCount(VehicleType vehicleType);
    }
}
