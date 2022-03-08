namespace po_lab
{
    public class Student {
        public string Surname { get; set; }
        public string Name { get; set; }
        public decimal Average { get; set; }

        public Student(string surname, string name, decimal average) {
            Surname = surname;
            Name = name;
            Average = average;
        }
    }
}