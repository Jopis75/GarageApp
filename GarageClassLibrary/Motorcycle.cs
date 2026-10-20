using GarageClassLibrary.Enums;

namespace GarageClassLibrary
{
    public class Motorcycle(string registrationNumber, float length, int numberOfSeats, int numberOfEngines, float cylinderVolume, FuelType fuelType, float seatHeight) : MotorVehicle(registrationNumber, length, numberOfSeats, numberOfEngines, cylinderVolume, fuelType)
    {
        public float SeatHeight
        {
            get
            {
                return seatHeight;
            }
            set
            {
                seatHeight = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Seat height: {SeatHeight}");
        }
    }
}
