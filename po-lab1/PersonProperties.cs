namespace po_lab
{
    public class PersonProperties
    {
        private string? _firstName;
        public string FirstName
        {
            get
            {
                return _firstName ?? "";
            }
            set
            {
                if (value.Length >= 2)
                {
                    _firstName = value;
                }
            }
        }
    }
}
