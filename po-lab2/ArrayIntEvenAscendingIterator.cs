namespace po_lab2
{
    internal class ArrayIntEvenAscendingIterator : Iterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntEvenAscendingIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
            var even = Array.FindAll(_aggregate.array, (e) => e % 2 == 0);
            var odd = Array.FindAll(_aggregate.array, (e) => e % 2 != 0);
            Array.Sort(even, odd);
            Array.Reverse(odd);

            _aggregate.array = even.Concat(odd).ToArray();
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