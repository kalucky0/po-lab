namespace po_lab2
{
    public class ElectricScooter : Scooter
    {
        public int MaxRange { get; init; }
        protected int _batteriesLevel;
        public int BatteriesLevel
        {
            get { return _batteriesLevel; }
        }

        public void ChargeBatteries()
        {
            _batteriesLevel = 100;
        }

        public override decimal Drive(int distance)
        {
            if (_batteriesLevel > 0)
            {
                _mileage += distance;
                _batteriesLevel -= distance / MaxRange;
                return (decimal)(distance / (double)MaxSpeed);
            }

            return -1;
        }
    }
}
