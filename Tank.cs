namespace po_lab
{
    public class Tank {
        public readonly int Capacity;
        private int _level;

        public Tank(int capacity) {
            Capacity = capacity;
            _level = 0;
        }

        public int Level {
            get { return _level; }
            set {
                if (value < 0)
                    throw new ArgumentException("Level cannot be negative");
                if (value > Capacity)
                    throw new ArgumentException("Level cannot be greater than capacity");
                _level = value;
            }
        }

        public bool refuel(int amount) {
            if (amount < 0)
                return false;
            if (amount > Capacity - _level)
                return false;
            _level += amount;
            return true;
        }
    }
}