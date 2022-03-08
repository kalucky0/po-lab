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

        public bool TryRefuel(int amount) {
            if (amount < 0)
                return false;
            if (amount > Capacity - _level)
                return false;
            _level += amount;
            return true;
        }

        public void Refuel(int amount) {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            if (amount > Capacity - _level)
                throw new ArgumentException("Amount cannot be greater than capacity");
            _level += amount;
        }

        public bool TryRefuel(Tank sourceTank, int amount) {
            if (sourceTank == null)
                throw new ArgumentNullException("sourceTank");
            if (amount < 0)
                return false;
            if (amount > sourceTank.Capacity - sourceTank.Level)
                return false;
            if (amount > Capacity - _level)
                return false;
            _level += amount;
            sourceTank.Level -= amount;
            return true;
        }

        public void Refuel(Tank sourceTank, int amount) {
            if (sourceTank == null)
                throw new ArgumentNullException("sourceTank");
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            if (amount > sourceTank.Capacity - sourceTank.Level)
                throw new ArgumentException("Amount cannot be greater than sourceTank.Capacity - sourceTank.Level");
            if (amount > Capacity - _level)
                throw new ArgumentException("Amount cannot be greater than capacity");
            _level += amount;
            sourceTank.Level -= amount;
        }

        public int RefuelAmount(int amount) {
            if(amount < 0 || _level == Capacity)
                return 0;
            if(amount > Capacity - _level)
            {
                int amountToRefuel = Capacity - _level;
                _level = Capacity;
                return amountToRefuel;
            }
            _level += amount;
            return amount;
        }

        public bool TryConsume(int amount) {
            if (amount < 0)
                return false;
            if (amount > _level)
                return false;
            _level -= amount;
            return true;
        }

        public void Consume(int amount) {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            if (amount > _level)
                throw new ArgumentException("Amount cannot be greater than level");
            _level -= amount;
        }

        public override string ToString() {
            return $"Tank: Capacity = {Capacity}, Level = {Level}";
        }
    }
}