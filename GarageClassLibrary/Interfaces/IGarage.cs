namespace GarageClassLibrary.Interfaces
{
    public interface IGarage
    {
        int NumberOfParkingSpaces { get; }

        int NumberOfVehicles { get; }

        IEnumerable<Vehicle> Vehicles { get; }

        void AddVehicle(Vehicle vehicle);

        Vehicle FindVehicle(string registrationNumber);

        Vehicle RemoveVehicle(string registrationNumber);
    }
}
