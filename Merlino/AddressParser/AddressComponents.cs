using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merlino.AddressParser
{
    public class AddressComponents
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public override string ToString()
        {
            return $"Street: {Street}, House Number: {HouseNumber}, City: {City}, Postal Code: {PostalCode}";
        }
    }
}
