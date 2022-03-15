using System;

namespace po_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles =
            {
                new Bicycle(){Weight = 15, MaxSpeed = 30, isDriver = true},
                new Car(){Weight = 900, MaxSpeed = 120, isFuel = true, isEngineWorking = true},
                new Bicycle(){Weight = 21, MaxSpeed = 40, isDriver = true},
                new Bicycle(){Weight = 19, MaxSpeed = 35, isDriver = true},
                new Car(){Weight = 1200, MaxSpeed = 130, isFuel = true, isEngineWorking = true}
            };

            foreach (var vehicle in vehicles)
                Console.WriteLine("Time for distance: " + vehicle.Drive(45));

            int bicycleCounter = 0;
            int carCounter = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Bicycle)
                {
                    bicycleCounter++;
                    Bicycle bicycle = (Bicycle)vehicle;
                    Console.WriteLine("Czy rower ma kierowcę: " + bicycle.isDriver);
                }
                if (vehicle is Car)
                    carCounter++;
            }
            Console.WriteLine($"Liczba rowerów: {bicycleCounter}, liczba samochodów: {carCounter}");

            Vehicle[] army =
            {
                 new Amphibian(){MaxSpeed = 20},
                 new Hydroplane(){MaxSpeed = 800},
                 new Truck() {MaxSpeed = 100}
            };

            foreach (var vehicle in army)
            {
                if (vehicle is Hydroplane)
                {
                    Console.WriteLine("Hydroplane");
                    Hydroplane hydroplane = (Hydroplane)vehicle;
                    hydroplane.TakeOff();
                    hydroplane.Fly(100);
                    hydroplane.Land();
                }
            }

            Flyable[] flyables =
            {
                new Wasp(),
                new Hydroplane(),
                new Duck(),
            };

            int flySwimCounter = 0;
            foreach (var flyable in flyables)
            {
                if (flyable is Flyable && flyable is Swimmingable)
                    flySwimCounter++;
            }

            Console.WriteLine($"Liczba latających i pływających: {flySwimCounter}");

            Aggregate aggregate = new ArrayIntAggregate();
            for (var iterator = aggregate.CreateDivisibleIterator(2); iterator.HasNext();)
            {
                Console.WriteLine(iterator.GetNext());
            }
        }
    }
}
