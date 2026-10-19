namespace GarageClassLibrary.Interfaces
{
    public interface IGarage
    {
        bool IsEmpty { get; }

        bool IsFull { get; }

        int NumberOfParkingSpaces { get; }

        int NumberOfVehicles { get; }

        void AddVehicle(Vehicle vehicle);

        int CountVehicleTypes();

        Vehicle FindVehicle(string registrationNumber);

        string GetStatusInfoString();

        Vehicle RemoveVehicle(string registrationNumber);
    }
}
