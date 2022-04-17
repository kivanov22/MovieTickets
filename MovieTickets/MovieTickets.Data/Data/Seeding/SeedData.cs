using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data.Data.Static;
using MovieTickets.Data.Models;

namespace MovieTickets.Data.Data.Seeding
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieTicketsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieTicketsDbContext>>()))
            {
                //Cinemas
                //if (!context.Cinemas.Any())
                //{
                //    context.Cinemas.AddRange(new List<Cinema>()
                //    {
                //        new Cinema()
                //        {
                //            CinemaAddress = "This is the description of the first cinema",
                //            CinemaName = "Cinema 1",
                //             City="Sofia",
                //            Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Cinemax_2016.svg/1200px-Cinemax_2016.svg.png",
                //        },
                //        new Cinema()
                //        {
                //            CinemaAddress = "This is the description of the first cinema",
                //            CinemaName = "Cinema 2",
                //             City="Sofia",
                //            Logo = "https://drive.google.com/file/d/1DBukf3ZJhdXdG2vIDpgepADphf4Mai6T/view?usp=sharing",
                //        },
                //        new Cinema()
                //        {
                //            CinemaAddress = "This is the description of the first cinema",
                //            CinemaName = "Cinema 3",
                //            City="Sofia",
                //            Logo = "https://drive.google.com/file/d/14Gk4GxQ0oCE7D4JeWA4C9srkrkoBjZF8/view?usp=sharing",
                //        },
                //    });
                //    context.SaveChanges();
                //}

                //Actors
                //if (!context.Actors.Any())
                //{
                //    context.Actors.AddRange(new List<Actor>()
                //    {
                //        new Actor()
                //        {
                //            FullName = "Actor 1",
                //            Biography = "This is the Bio of the first actor",
                //            Age = 34,
                //            ProfilePicture = "https://drive.google.com/file/d/1glgOb79osjf2Le2_MdpxF7p0T6rN8P6b/view?usp=sharing"

                //        },
                //        new Actor()
                //        {
                //            FullName = "Actor 2",
                //            Biography = "This is the Bio of the second actor",
                //             Age = 35,
                //            ProfilePicture = "https://drive.google.com/file/d/1_emYwD18nvuHOuAnWe7M9Ik6UvxD015t/view?usp=sharing"
                //        },
                //        new Actor()
                //        {
                //            FullName = "Actor 3",
                //            Biography = "This is the Bio of the second actor",
                //             Age = 36,
                //            ProfilePicture = "https://drive.google.com/file/d/1Upl_NssEDLqZhn0a32Px5xdyZtv5biSZ/view?usp=sharing"
                //        },
                //        new Actor()
                //        {
                //            FullName = "Actor 4",
                //            Biography = "This is the Bio of the second actor",
                //             Age = 37,
                //            ProfilePicture = "https://drive.google.com/file/d/1V80wh4Qxkkksic2Cld9QVNAyZ5k6kOle/view?usp=sharing"
                //        },
                //        new Actor()
                //        {
                //            FullName = "Actor 5",
                //            Biography = "This is the Bio of the second actor",
                //             Age = 38,
                //            ProfilePicture = "https://drive.google.com/file/d/1HBUjP1MfUZTYppwKtypHFkYXdpUf2JPx/view?usp=sharing"
                //        }
                //    });
                //    context.SaveChanges();
                //}

                //Producers
                //if (!context.Producers.Any())
                //{
                //    context.Producers.AddRange(new List<Producer>()
                //    {
                //        new Producer()
                //        {
                //            ProfilePicture = "https://drive.google.com/file/d/1Fhs7B5qJ1LHVbyGY14tBusGX3s1UMM0M/view?usp=sharing",
                //            FullName = "Producer 1",
                //            Age = 42,
                //            Biography = "This is the Bio of the first actor",

                //        },
                //        new Producer()
                //        {
                //            ProfilePicture = "https://drive.google.com/file/d/1e5YM4rlJOGt-9_wL5EnoTEnuIBXNW6R7/view?usp=sharing",
                //            FullName = "Producer 2",
                //             Age = 43,
                //            Biography = "This is the Bio of the second actor",
                //        },
                //        new Producer()
                //        {
                //            ProfilePicture = "https://drive.google.com/file/d/1EXJmNWLg0HoPbthMIxwsdaQfEdtW1QDN/view?usp=sharing",
                //            FullName = "Producer 3",
                //             Age = 44,
                //            Biography = "This is the Bio of the second actor",
                //        },
                //        new Producer()
                //        {
                //            ProfilePicture = "https://drive.google.com/file/d/1t-iqNh7BNSWm43z-SxJqhsQCjzmODyU_/view?usp=sharing",
                //            FullName = "Producer 4",
                //             Age = 45,
                //            Biography = "This is the Bio of the second actor",
                //        },
                //        new Producer()
                //        {
                //            ProfilePicture = "https://drive.google.com/file/d/1N3esl2eyvoIkSW8BmGRBJfbS0XjBb532/view?usp=sharing",
                //            FullName = "Producer 5",
                //             Age = 46,
                //            Biography = "This is the Bio of the second actor",
                //        }
                //    });
                //    context.SaveChanges();
                //}

                //Movies
                //if (!context.Movies.Any())
                //{
                //    context.Movies.AddRange(new List<Movie>()
                //    {
                //        new Movie()
                //        {
                //            CinemaId = 3,
                //            Description = "This is the Life movie description",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(10),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://drive.google.com/file/d/141-GXa6Wf1PkkCdNoZ1soajHpfKgHRdS/view?usp=sharing",
                //            Language="English",
                //            Price = 39.50,
                //            ProducerId = 3,
                //             Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now.AddDays(-10),
                //            Title = "Life",
                //        },
                //        new Movie()
                //        {
                //            CinemaId = 1,
                //            Description = "This is the Shawshank Redemption description",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(3),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://drive.google.com/file/d/1IMCpBysSxa6yLtUON4d9eMbLrSzzLBBQ/view?usp=sharing",
                //             Language="English",
                //            Price = 29.50,
                //            ProducerId = 1,
                //             Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now,
                //            Title = "The Shawshank Redemption",
                //        },
                //        new Movie()
                //        {
                //            CinemaId = 4,
                //            Description = "This is the Ghost movie description",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(7),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://drive.google.com/file/d/1rzFzi1JJ200NIhcMFTGn_Gkl5EMf1db7/view?usp=sharing",
                //             Language="English",
                //            Price = 39.50,
                //            ProducerId = 4,
                //             Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now,
                //            Title = "Ghost",
                //        },
                //        new Movie()
                //        {
                //            CinemaId = 1,
                //            Description = "Cold Soles",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(-5),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://drive.google.com/file/d/1swU_GsHoUUJXgV1VicgL4gEER2mGrskD/view?usp=sharing",
                //             Language="English",
                //            Price = 39.50,
                //            ProducerId = 2,
                //             Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now.AddDays(-10),
                //            Title = "Race",
                //        },
                //        new Movie()
                //        {
                //            CinemaId = 1,
                //            Description = "This is the Scoob movie description",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(-2),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://drive.google.com/file/d/1Nq2-HBgDTZORrXSl4-ROs244Jni1_SUF/view?usp=sharing",
                //             Language="English",
                //            Price = 39.50,
                //            ProducerId = 3,
                //             Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now.AddDays(-10),
                //            Title = "Scoob",
                //        },
                //        new Movie()
                //        {
                //            CinemaId = 1,
                //            Description = "Bad Boys",
                //            Duration=120,
                //            EndDate = DateTime.Now.AddDays(20),
                //            Genre = Models.Enums.Genre.Adventures,
                //            ImageUrl = "https://mmtvmusic.com/wp-content/uploads/2020/01/sony-produljenie-bad-boys-4-mmtv-01-f.jpg",
                //            Language="English",
                //            Price = 39.50,
                //            ProducerId = 5,
                //            Resolution = Models.Enums.Resolution.FourKX,
                //            StartDate = DateTime.Now.AddDays(3),
                //            Title = "Cold Soles",
                //        }
                //    });
                //    context.SaveChanges();
                //}

                //Actors & Movies
                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActor>()
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
                    context.SaveChanges();
                }
            }
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

