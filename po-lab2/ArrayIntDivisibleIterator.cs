namespace po_lab2
{
    internal class ArrayIntDivisibleIterator : Iterator
    {
        private int _index = 0;
        private int _divider = 1;
        private ArrayIntAggregate _aggregate;

        public ArrayIntDivisibleIterator(ArrayIntAggregate aggregate, int k)
        {
            _aggregate = aggregate;
            _divider = k;
        }
        public int GetNext()
        {
            while(_index < _aggregate.array.Length && _aggregate.array[_index] % _divider != 0)
                _index++;

            return _aggregate.array[_index++];
        }

        public bool HasNext()
        {
            int i = _index;

            while (i < _aggregate.array.Length && _aggregate.array[i] % _divider != 0)
                i++;

            return i < _aggregate.array.Length;
        }
    }
}