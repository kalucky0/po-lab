namespace po_lab2
{
    public class ArrayIntAggregate : Aggregate
    {
        internal int[] array = { 1, 2, 3, 4, 5 };

        public Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);
        }

        public Iterator CreateReversedIterator()
        {
            return new ArrayIntReversedIterator(this);
        }
    }
}
