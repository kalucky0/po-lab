using System;

namespace po_lab2
{
    public class Amphibian : Vehicle, Driveable, Swimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }
    }
}
