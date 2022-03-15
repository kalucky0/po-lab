namespace po_lab2
{
    public class ArrayIntAggregate : Aggregate
    {
        internal int[] array = { 1, 2, 3, 4, 5 };

        public override Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);
       }
    }
}
