namespace po_lab2
{
    public sealed class ArrayIntReversedIterator : Iterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntReversedIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
            _index = _aggregate.array.Length - 1;
        }
        public int GetNext()
        {
            return _aggregate.array[_index--];
        }

        public bool HasNext()
        {
            return _index >= 0;
        }
    }
}
