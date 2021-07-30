using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using SuperShop.Helpers;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            // Verifica se já existe base de dados, caso nao exista cria
            await _context.Database.MigrateAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

            if(!_context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Lisboa" });
                cities.Add(new City { Name = "Porto" });
                cities.Add(new City { Name = "Faro" });

                _context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Portugal"
                });

                await _context.SaveChangesAsync();
            }

            var user = await _userHelper.GetUserByEmailAsync("lalobia62@gmail.com");

            if(user == null)
            {
                user = new User
                {
                    FirstName = "Gonçalo",
                    LastName = "Alcobia",
                    Email = "lalobia62@gmail.com",
                    UserName = "lalobia62@gmail.com",
                    PhoneNumber = "919399400",
                    Address = "Rua Jau 33",
                    CityId = _context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    City = _context.Countries.FirstOrDefault().Cities.FirstOrDefault()
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            // Se nao existirem os produtos, crio alguns produtos
            if (!_context.Products.Any())
            {
                AddProduct("Iphone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series 4", user);
                AddProduct("iPad Mini", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
