using Shopping.Data.Entities;
using Shopping.Enums;
using Shopping.Helpers;

namespace Shopping.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

       public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoryAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1122814141", "Leiner", "Solano", "ingleiner@yopmail.com", "304 356 0784", "Cra 22 # 24-14", UserType.Admin);
          //  await CheckUserAsync("1066302336", "Mariana", "Solano", "mariana@yopmail.com", "304 356 0784", "Cra 22 # 24-14", UserType.User);

        }

        private async Task<User> CheckUserAsync(
            string document, 
            string firstName, 
            string lastName, 
            string email, 
            string phone, 
            string address, 
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    { 
                        new State
                        { 
                            Name = "Cesar",
                            Cities = new List<City>()
                            {
                                new City { Name = "Valledupar"},
                                new City { Name = "La Paz"},
                                new City { Name = "San Diego"},
                                new City { Name = "Pueblo Bello"},
                                new City { Name = "Bosconia"},
                                new City { Name = "La Jagua"},
                                new City { Name = "Aguachica"},
                                new City { Name = "Curimaní"},
                                new City { Name = "Chimichagua"},
                                new City { Name = "Manaure"},
                                new City { Name = "El Paso"},
                                new City { Name = "Codazzi"},
                                new City { Name = "San Alberto"},
                            }
                        },
                        new State
                        {
                            Name = "La Guajira",
                            Cities= new List<City>()
                            {
                                new City { Name = "Riohacha"},
                                new City { Name = "Maicao"},
                                new City { Name = "Barrancas"},
                                new City { Name = "Fonsenca"},
                                new City { Name = "San Juan"},
                                new City { Name = "Villa Nueva"},
                                new City { Name = "Urumita"},
                                new City { Name = "Hatonuevo"},
                                new City { Name = "Manaure"},
                                new City { Name = "Uribia"},
                                new City { Name = "Distracción"},

                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Venezuela",
                    States = new List<State>()
                    {
                        new State
                        {
                            Name = "Zulia",
                            Cities = new List<City>()
                            {
                                new City { Name = "Maracaibo"},
                                new City { Name = "La Concepción"},
                                new City { Name = "Palito Blanco"},
                            }
                        },
                        new State
                        {
                            Name = "Lara",
                            Cities = new List<City>()
                            {
                                new City { Name = "Barquisimeto"}
                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                    }
                });
            await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCategoryAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Ropda" });
                _context.Categories.Add(new Category { Name = "Librería" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Comida" });
                _context.Categories.Add(new Category { Name = "Bebidas" });
                _context.Categories.Add(new Category { Name = "Mac" });
                _context.Categories.Add(new Category { Name = "Intel" });
                _context.Categories.Add(new Category { Name = "Electrodomésticos" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
