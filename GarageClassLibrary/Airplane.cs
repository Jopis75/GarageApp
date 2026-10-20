using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Airplane(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float maxThrust) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float MaxThrust
        {
            get
            {
                return maxThrust;
            }
            set
            {
                if (float.IsPositive(value) == false)
                {
                    throw new ArgumentException("MaxThrust must be a positive value.");
                }

                maxThrust = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Max thrust: {MaxThrust}");
        }
    }
}
