using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coureservices.Data.Models
{
   public class Country
    {


        [Key]
        public int CountryId { get; set; }
        public string Name   { get; set; }
        public string CountryCode { get; set; }

        public string CountryIso { get; set; }
         public DateTime Created_At { get; set; }



    }
}
