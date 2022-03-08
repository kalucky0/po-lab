namespace po_lab
{
    public class Tank {
        public readonly int Capacity;
        private int _level;

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

        /// <summary>
        /// Constructor of Tank class
        /// </summary>
        /// <param name="capacity">Capacity of tank</param>
        public Tank(int capacity) {
            Capacity = capacity;
            _level = 0;
        }

        /// <summary>
        /// Method that fills tank
        /// </summary>
        /// <param name="amount">Amount of substance to fill tank</param>
        /// <returns>Boolean value that indicates if tank was filled</returns>
        public bool TryRefuel(int amount) {
            if (amount < 0)
                return false;
            if (amount > Capacity - _level)
                return false;
            _level += amount;
            return true;
        }

        /// <summary>
        /// Method that fills tank
        /// </summary>
        /// <param name="amount">Amount of substance to fill tank</param>
        /// <exception cref="ArgumentException">Thrown when amount is negative or greater than capacity</exception>
        public void Refuel(int amount) {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            if (amount > Capacity - _level)
                throw new ArgumentException("Amount cannot be greater than capacity");
            _level += amount;
        }

        /// <summary>
        /// Method that fills tank from other tank
        /// </summary>
        /// <param name="sourceTank">Tank to fill from</param>
        /// <param name="amount">Amount of substance to fill tank</param>
        /// <returns>Boolean value that indicates if tank was filled</returns>
        public bool TryRefuel(Tank sourceTank, int amount) {
            if (sourceTank == null)
                return false;
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

        /// <summary>
        /// Method that fills tank from other tank
        /// </summary>
        /// <param name="sourceTank">Tank to fill from</param>
        /// <param name="amount">Amount of substance to fill tank</param>
        /// <exception cref="ArgumentNullException">Thrown when sourceTank is null</exception>
        /// <exception cref="ArgumentException">Thrown when amount is greater than sourceTank.Capacity - sourceTank.Level</exception>
        /// <exception cref="ArgumentException">Thrown when amount is greater than capacity </exception>
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

        /// <summary>
        /// Method that fills tank and returns amount of substance that was filled
        /// </summary>
        /// <param name="amount">Amount of substance to fill tank</param>
        /// <returns>Amount of substance that was filled</returns>
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

        /// <summary>
        /// Method that consumes substance from tank
        /// </summary>
        /// <param name="amount">Amount of substance to consume</param>
        /// <returns>Boolean value that indicates if substance was consumed</returns>
        public bool TryConsume(int amount) {
            if (amount < 0)
                return false;
            if (amount > _level)
                return false;
            _level -= amount;
            return true;
        }

        /// <summary>
        /// Method that consumes substance from tank
        /// </summary>
        /// <param name="amount">Amount of substance to consume</param>
        /// <exception cref="ArgumentException">Thrown when amount is negative or greater than level</exception>
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