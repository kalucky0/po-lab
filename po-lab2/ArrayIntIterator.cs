namespace po_lab2
{
    public sealed class ArrayIntIterator : Iterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        public int GetNext()
        {
            return _aggregate.array[_index++];
        }
        public bool HasNext()
        {
            return _index < _aggregate.array.Length;
        }
    }
}
