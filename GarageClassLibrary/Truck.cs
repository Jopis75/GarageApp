using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Truck(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float maximumLoad) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float MaximumLoad
        {
            get
            {
                return maximumLoad;
            }
            set
            {
                maximumLoad = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Maximum load: {MaximumLoad}");
        }
    }
}
