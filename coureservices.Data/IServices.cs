using coureservices.Data.Models;
using coureservices.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coureservices.Data
{
   public  interface IServices
    {

        Task  <ResponseModel> GetCotuntry( string countrycode, string phone);

        Task<Country> FindCountrycode(string countcode);

        Task AddCountry();
       Task    AddCountryDetails();
    }
}
