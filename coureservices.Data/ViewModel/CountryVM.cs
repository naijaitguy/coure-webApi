using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coureservices.Data.ViewModel
{
    public class CountryVM
    {

        public string Name { get; set; }
        public string CountryCode { get; set; }

        public string CountryIso { get; set; }
        public DateTime Created_At { get; set; }
    }
}
