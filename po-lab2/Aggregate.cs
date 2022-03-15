namespace po_lab2
{
    public interface Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract Iterator CreateReversedIterator();
    }
}
