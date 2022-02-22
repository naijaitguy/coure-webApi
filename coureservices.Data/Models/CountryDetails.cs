using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coureservices.Data.Models
{
  public    class CountryDetails
    {

       [ Key]
        public int Id { get; set; }
        public string Operator { get; set; }
        public int   CountryId { get; set; }

         [ForeignKey("CountryId")]
        public virtual  Country GetCountry { get; set; }
        public string OperatorCode { get; set; }

        public DateTime Created_At { get; set; }


    }
}
