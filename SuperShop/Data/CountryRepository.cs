using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using SuperShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddCityAsync(CityViewModel model)
        {
            var country = await this.GetCountryWithCitiesAsync(model.CountryId);
            if (country == null)
            {
                return;
            }

            country.Cities.Add(new City { Name = model.Name });
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }


        public async Task<int> DeleteCityAsync(City city)
        {
            var country = await _context.Countries
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id))
                .FirstOrDefaultAsync();
            if (country == null)
            {
                return 0;
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return country.Id;
        }

        public IQueryable GetCountriesWithCities()
        {
            return _context.Countries
                .Include(c => c.Cities)
                .OrderBy(c => c.Name);
        }

        public async Task<Country> GetCountryWithCitiesAsync(int id)
        {
            return await _context.Countries
                .Include(c => c.Cities)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }


        public async Task<int> UpdateCityAsync(City city)
        {
            var country = await _context.Countries
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id)).FirstOrDefaultAsync();
            if (country == null)
            {
                return 0;
            }

            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
            return country.Id;
        }


        public async Task<City> GetCityAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }


        public async Task<Country> GetCountryAsync(City city)
        {
            return await _context.Countries
                .Where(c => c.Cities.Any(ci => ci.Id == city.Id))
                .FirstOrDefaultAsync();
        }

    }
}
