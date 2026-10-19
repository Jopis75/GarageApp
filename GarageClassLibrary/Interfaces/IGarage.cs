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

        Vehicle FindVehicle(string registrationNumber);

        string GetStatusInfoString();

        Vehicle RemoveVehicle(string registrationNumber);

        void WriteVehicles();

        void WriteVehicleTypeInfo(VehicleType vehicleType);
    }
}
