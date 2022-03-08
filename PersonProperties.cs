using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
