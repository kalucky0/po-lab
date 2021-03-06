namespace po_lab
{
    public class Student : IComparable<Student> {
        public string Surname { get; set; }
        public string Name { get; set; }
        public decimal Average { get; set; }

        /// <summary>
        /// Constructor of Student class
        /// </summary>
        /// <param name="surname">Surname of student</param>
        /// <param name="name">Name of student</param>
        /// <param name="average">Average of student</param>
        public Student(string surname, string name, decimal average) {
            Surname = surname;
            Name = name;
            Average = average;
        }
        
        /// <summary>
        /// Method that compares two students
        /// </summary>
        /// <param name="other">Student to compare with</param>
        public int CompareTo(Student? other)
        {
            if (ReferenceEquals(null, other)) return 1;
            if (ReferenceEquals(this, other)) return 0;
            var surnameComparison = Surname.CompareTo(other.Surname);
            if (surnameComparison != 0) return surnameComparison;
            var nameComparison = Name.CompareTo(other.Name);
            if (nameComparison != 0) return nameComparison;
            return Average.CompareTo(other.Average);
        }
    }
}