using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Data.Static;
using MovieTickets.Data.Models;

namespace MovieTickets.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedMovies(services);
            SeedProducers(services);
            SeedActors(services);
            SeedCinemas(services);
            SeedMovieActors(services);
           

            return app;
        }

        public static void SeedMovies(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();

            if (!data.Movies.Any())
            {
                data.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            CinemaId = 3,
                            Description = "This is the Life movie description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(10),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            Language="English",
                            Price = 39.50,
                            ProducerId = 3,
                             Resolution = Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now.AddDays(-10),
                            Title = "Life",
                        },
                        new Movie()
                        {
                            CinemaId = 1,
                            Description = "This is the Shawshank Redemption description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(3),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                             Language="English",
                            Price = 29.50,
                            ProducerId = 1,
                             Resolution =Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now,
                            Title = "The Shawshank Redemption",
                        },
                        new Movie()
                        {
                            CinemaId = 4,
                            Description = "This is the Ghost movie description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(7),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                             Language="English",
                            Price = 39.50,
                            ProducerId = 4,
                             Resolution = Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now,
                            Title = "Ghost",
                        },
                        new Movie()
                        {
                            CinemaId = 1,
                            Description = "This is the Race movie description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(-5),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "cinemacity.jpeg",
                             Language="English",
                            Price = 39.50,
                            ProducerId = 2,
                             Resolution = Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now.AddDays(-10),
                            Title = "Race",
                        },
                        new Movie()
                        {
                            CinemaId = 1,
                            Description = "This is the Scoob movie description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(-2),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                             Language="English",
                            Price = 39.50,
                            ProducerId = 3,
                             Resolution = Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now.AddDays(-10),
                            Title = "Scoob",
                        },
                        new Movie()
                        {
                            CinemaId = 1,
                            Description = "This is the Cold Soles movie description",
                            Duration=120,
                            EndDate = DateTime.Now.AddDays(20),
                            Genre = Data.Models.Enums.Genre.Adventures,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            Language="English",
                            Price = 39.50,
                            ProducerId = 5,
                            Resolution = Data.Models.Enums.Resolution.FourKX,
                            StartDate = DateTime.Now.AddDays(3),
                            Title = "Cold Soles",
                        }
                    });
                data.SaveChanges();
            }

            //data.Movies.AddRange(SupplementsSeeder.GetSupplements());


        }

        public static void SeedProducers(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();

            if (!data.Producers.Any())
            {
                data.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-1.jpeg",
                            FullName = "Producer 1",
                            Age = 42,
                            Biography = "This is the Bio of the first actor",

                        },
                        new Producer()
                        {
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-2.jpeg",
                            FullName = "Producer 2",
                             Age = 43,
                            Biography = "This is the Bio of the second actor",
                        },
                        new Producer()
                        {
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-3.jpeg",
                            FullName = "Producer 3",
                             Age = 44,
                            Biography = "This is the Bio of the second actor",
                        },
                        new Producer()
                        {
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-4.jpeg",
                            FullName = "Producer 4",
                             Age = 45,
                            Biography = "This is the Bio of the second actor",
                        },
                        new Producer()
                        {
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-5.jpeg",
                            FullName = "Producer 5",
                             Age = 46,
                            Biography = "This is the Bio of the second actor",
                        }
                    });
                data.SaveChanges();
            }
        }
        public static void SeedActors(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();

            if (!data.Actors.Any())
            {
                data.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Biography = "This is the Bio of the first actor",
                            Age = 34,
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Biography = "This is the Bio of the second actor",
                             Age = 35,
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Biography = "This is the Bio of the second actor",
                             Age = 36,
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Biography = "This is the Bio of the second actor",
                             Age = 37,
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Biography = "This is the Bio of the second actor",
                             Age = 38,
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
            }
            data.SaveChanges();
        }
        public static void SeedCinemas(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();

            if (!data.Cinemas.Any())
            {
                data.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            CinemaAddress = "This is the description of the first cinema",
                            CinemaName = "Cinema 1",
                             City="Sofia",
                            Logo = "cinemacity.jpeg",
                        },
                        new Cinema()
                        {
                            CinemaAddress = "This is the description of the first cinema",
                            CinemaName = "Cinema 2",
                             City="Sofia",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        },
                        new Cinema()
                        {
                            CinemaAddress = "This is the description of the first cinema",
                            CinemaName = "Cinema 3",
                            City="Sofia",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        },
                    });
                data.SaveChanges();
            }
        }
        public static void SeedMovieActors(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();

            if (!data.MovieActors.Any())
            {
                data.MovieActors.AddRange(new List<MovieActor>()
                            {
                                new MovieActor()
                                {
                                    ActorId = 1,
                                    MovieId = 1
                                },
                                new MovieActor()
                                {
                                    ActorId = 3,
                                    MovieId = 1
                                },

                                 new MovieActor()
                                {
                                    ActorId = 1,
                                    MovieId = 2
                                },
                                 new MovieActor()
                                {
                                    ActorId = 4,
                                    MovieId = 2
                                },

                                new MovieActor()
                                {
                                    ActorId = 1,
                                    MovieId = 3
                                },
                                new MovieActor()
                                {
                                    ActorId = 2,
                                    MovieId = 3
                                },
                                new MovieActor()
                                {
                                    ActorId = 5,
                                    MovieId = 3
                                },


                                new MovieActor()
                                {
                                    ActorId = 2,
                                    MovieId = 4
                                },
                                new MovieActor()
                                {
                                    ActorId = 3,
                                    MovieId = 4
                                },
                                new MovieActor()
                                {
                                    ActorId = 4,
                                    MovieId = 4
                                },


                                new MovieActor()
                                {
                                    ActorId = 2,
                                    MovieId = 5
                                },
                                new MovieActor()
                                {
                                    ActorId = 3,
                                    MovieId = 5
                                },
                                new MovieActor()
                                {
                                    ActorId = 4,
                                    MovieId = 5
                                },
                                new MovieActor()
                                {
                                    ActorId = 5,
                                    MovieId = 5
                                },


                                new MovieActor()
                                {
                                    ActorId = 3,
                                    MovieId = 6
                                },
                                new MovieActor()
                                {
                                    ActorId = 4,
                                    MovieId = 6
                                },
                                new MovieActor()
                                {
                                    ActorId = 5,
                                    MovieId = 6
                                },
                            });
            }
            data.SaveChanges();
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<MovieTicketsDbContext>();
            data.Database.Migrate();
        }
        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}