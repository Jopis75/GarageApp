using GarageClassLibrary.Interfaces;

namespace GarageClassLibrary
{
    public abstract class Vehicle(string registrationNumber, float length, int numberOfSeats) : IVehicle
    {
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                numberOfSeats = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
        }

        public virtual void Write()
        {
            Console.WriteLine($"Registration number: {RegistrationNumber}");
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Number of seats: {NumberOfSeats}");
        }
    }
}
