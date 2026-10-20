namespace GarageClassLibrary
{
    public class Bicycle(string registrationNumber, float length, int numberOfSeats, int numberOfGears) : Vehicle(registrationNumber, length, numberOfSeats)
    {
        public int NumberOfGears
        {
            get
            {
                return numberOfGears;
            }
            set
            {
                numberOfGears = value;
            }
        }

        public override void Write()
        {
            Console.WriteLine($"Vehicle type: {GetType().Name}");

            base.Write();

            Console.WriteLine($"Number of gears: {NumberOfGears}");
        }
    }
}
