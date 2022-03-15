namespace po_lab2
{
    public class KickScooter : Scooter
    {
        public override decimal Drive(int distance)
        {
            _mileage += distance;
            return (decimal)(distance / (double)MaxSpeed);
        }
    }
}
