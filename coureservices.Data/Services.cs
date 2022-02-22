using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coureservices.Data.Models;
using coureservices.Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace coureservices.Data
{
    public class Services: IServices
    {

        private CoureServicesDbContext service;

        public Services(CoureServicesDbContext db)
        {

            this.service = db;


              // this.AddCountry();
             // this.AddCountryDetails();
        }


        public async Task <ResponseModel> GetCotuntry( string countrycode, string phone)
        {

            var result = await (
            from x in service.Countries where x.CountryCode == countrycode
            select new ResponseModel
            {
                responseCode = "200",
                responseDescription = "Successful",
                number = phone,
                country = new CountryVM
                { CountryCode = x.CountryCode, CountryIso = x.CountryIso,
                    Name = x.Name, Created_At = x.Created_At },
                countryDetials = 
                 (from z in service.countryDetails where z.CountryId == x.CountryId  select new  
                  CountryDetialsVM{ Operator = z.Operator, OperatorCode = z.OperatorCode, Created_At = z.Created_At}
                  ).ToList()


            }).FirstOrDefaultAsync();

            return result;

        }

        public async Task <Country> FindCountrycode( string countcode)
        {

            var res=   await service.Countries.Where(z => z.CountryCode == countcode).FirstOrDefaultAsync();

            return res;
        }
       public async Task AddCountry()
        {

            Country country1 = new Country
            {
                CountryCode = "234",
                CountryIso = "NG",
                Name = "Nigeria ",
                Created_At = DateTime.Now
            };

            Country country2 = new Country
            {
                CountryCode = "233",
                CountryIso = "GH",
                Name = "Ghana",
                Created_At = DateTime.Now
            };

            Country country3 = new Country
            {
                CountryCode = "229",
                CountryIso = "BN",
                Name = "Benin Republic",
                Created_At = DateTime.Now
            };

            Country country4 = new Country
            {
                CountryCode = "225",
                CountryIso = "CIV",
                Name = "Côte d'Ivoire",
                Created_At = DateTime.Now
            };

            this.service.Countries.Add(country1);
            this.service.Countries.Add(country2);
            this.service.Countries.Add(country3);
            this.service.Countries.Add(country4);

            await  service.SaveChangesAsync();

        }

        public async Task AddCountryDetails()
        {

            CountryDetails obj1 = new CountryDetails
            {

               CountryId = 1,
                Operator = "MTN Nigeria",
                OperatorCode = "MTN NG",
                Created_At = DateTime.Now
            };     CountryDetails obj2 = new CountryDetails
            {

               CountryId = 1,
                Operator = " Airtel Nigeria",
                OperatorCode = "ANG",
                Created_At = DateTime.Now
            };     CountryDetails obj3 = new CountryDetails
            {

               CountryId = 1,
                Operator = "9 Mobile Nigeria ",
                OperatorCode = "ETN",
                Created_At = DateTime.Now
            };     CountryDetails obj4 = new CountryDetails
            {

               CountryId = 1,
                Operator = "Globacom Nigeria",
                OperatorCode = "GLO NG",
                Created_At = DateTime.Now
            };     CountryDetails obj5 = new CountryDetails
            {

               CountryId = 2,
                Operator = "Vodafone Ghana ",
                OperatorCode = "Vodafone GH",
                Created_At = DateTime.Now
            }; 
            CountryDetails obj6 = new CountryDetails
            {

               CountryId = 2,
                Operator = "MTN Ghana ",
                OperatorCode = "MTN Ghana ",
                Created_At = DateTime.Now
            };   CountryDetails obj7 = new CountryDetails
            {

               CountryId = 2,
                Operator = "Tigo Ghana",
                OperatorCode = "Tigo Ghana",
                Created_At = DateTime.Now
            };   CountryDetails obj8 = new CountryDetails
            {

               CountryId = 3,
                Operator = "MTN Benin",
                OperatorCode = "MTN Benin",
                Created_At = DateTime.Now
            }; 
            CountryDetails obj9 = new CountryDetails
            {

               CountryId = 3,
                Operator = "Moov Benin",
                OperatorCode = "Moov Benin",
                Created_At = DateTime.Now
            };   CountryDetails obj10 = new CountryDetails
            {

               CountryId = 4,
                Operator = "MTN Côte d'Ivoire ",
                OperatorCode = "MTN CIV",
                Created_At = DateTime.Now
            };

            service.countryDetails.Add(obj1);
            service.countryDetails.Add(obj2);
            service.countryDetails.Add(obj3);
            service.countryDetails.Add(obj4);
            service.countryDetails.Add(obj5);
            service.countryDetails.Add(obj6);
            service.countryDetails.Add(obj7);
            service.countryDetails.Add(obj8);
            service.countryDetails.Add(obj9);
            service.countryDetails.Add(obj10);

            await service.SaveChangesAsync();

        }


    }
}
