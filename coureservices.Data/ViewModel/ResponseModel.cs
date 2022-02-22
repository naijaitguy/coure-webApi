using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coureservices.Data.ViewModel
{
    public class ResponseModel
    {

        public string number { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }

        public CountryVM country { get; set; }

        public List<CountryDetialsVM> countryDetials { get; set; }


    }
}
