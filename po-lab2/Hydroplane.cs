using System;

namespace po_lab2
{
    public class Hydroplane : Vehicle, Flyable, Swimmingable
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
        public bool TakeOff()
        {
            Console.WriteLine("TAKE OFF");
            return true;
        }
        public decimal Fly(int distance)
        {
            Console.WriteLine("FLY");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("LAND");
            return true;
        }
    }
}
