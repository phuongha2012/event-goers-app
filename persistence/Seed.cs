using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        DisplayName = "Brian",
                        UserName = "brian",
                        Email = "brian@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        DisplayName = "Tracey",
                        UserName = "tracey",
                        Email = "tracey@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        DisplayName = "Taylor",
                        UserName = "taylor",
                        Email = "taylor@test.com"
                    },
                    new AppUser
                    {
                        Id = "d",
                        DisplayName = "Patrick",
                        UserName = "patrick",
                        Email = "patrick@test.com"
                    },
                    new AppUser
                    {
                        Id = "e",
                        DisplayName = "Gabrielle",
                        UserName = "gabrielle",
                        Email = "gabrielle@test.com"
                    },
                    new AppUser
                    {
                        Id = "f",
                        DisplayName = "Jack",
                        UserName = "jack",
                        Email = "jack@test.com"
                    },
                    new AppUser
                    {
                        Id = "g",
                        DisplayName = "Marina",
                        UserName = "maria",
                        Email = "maria@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Tribal Drum & Dance Jam",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Dancers are welcome to come along to enjoy dancing to live music and learn more about Middle Eastern rhythms - switch between drumming & dancing as suits you!",
                        Category = "Music",
                        City = "Christchurch",
                        Venue = "Showbiz Studios",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                            new UserActivity
                            {
                                AppUserId = "f",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                            new UserActivity
                            {
                                AppUserId = "e",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(1)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Lunch on the lawn",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Come along to start the Term with a delicious free BBQ! Free snag or vege pattie as a welcome back to Term 4, see ya there!",
                        Category = "Food",
                        City = "Auckland",
                        Venue = "Jamies Italian",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "d",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "e",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },
                            new UserActivity
                            {
                                AppUserId = "f",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(2)
                            },

                        }
                    },
                    new Activity
                    {
                        Title = "Gin Tasting at Riccarton House with Wine Divine",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "The lovely Laura will take you through the history of some of the world’s best loved boutique gins along with some lesser known & unique bottles. Explore your taste buds by adding different garnishes & tonics to each gin. Paired nibbles will be served throughout the tasting.",
                        Category = "Drinks",
                        City = "Canterbury",
                        Venue = "Riccarton House",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "f",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(3)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Banff Mountain Film Festival World Tour – WELLINGTON 2020",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Ignite your passion for adventure, action, and travel! The Banff Centre Mountain Film Festival World Tour will exhilarate you with amazing big-screen stories. Journey to exotic locations, paddle the wildest waters, and climb the highest peaks. Get your tickets today and be taken away to the most captivating places on earth.",
                        Category = "Culture",
                        City = "Wellington",
                        Venue = "Embassy Theatre",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(4)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(4)
                            },
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(4)
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "High Tea at Le Cordon Bleu",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Experience an exquisite selection of the finest French Pâtisserie prepared by our highly creative and talented Le Cordon Bleu NZ Students",
                        Category = "Drinks",
                        City = "Wellington",
                        Venue = "Le Cordon Bleu New Zealand",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "c",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                            new UserActivity
                            {
                                AppUserId = "g",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                            new UserActivity
                            {
                                AppUserId = "e",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(5)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Molly & the Chromatics live at Meow",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Molly & The Chromatics hit the road this month for two stand alone shows! The band have recently confirmed the release of their debut Album with the first track Goddess now out on all platforms. With impending releases on the very near horizon be sure to grab a ticket early to see this brand new live set from M&TC.",
                        Category = "Music",
                        City = "Wellington",
                        Venue = "Meow",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "f",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                            new UserActivity
                            {
                                AppUserId = "g",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(6)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Wellington Let’s Roam Treasure Hunt:Cultural Capital!",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "See the best of Wellington and delight your friends with some epic scavenger hunt ideas for adults. On, Cultural Capital, you will wander with purpose to see the most entertaining sights in Wellington, and learn about the history and culture while you’re at it. Snap silly photos, answer tough trivia, and have a blast with the Let’s Roam scavenger hunt app!",
                        Category = "Travel",
                        City = "Wellington",
                        Venue = "Frank Kitts Park",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "g",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                            new UserActivity
                            {
                                AppUserId = "a",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(7)
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Norma Jean - All Hail - Wellington",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Buckle up, US metalcore mainstays Norma Jean are bringing the heaviness to New Zealand shores this May for their long awaited return off the back of their highly reviewed album 'All Hail'.",
                        Category = "Drinks",
                        City = "Wellington",
                        Venue = "Valhalla",
                        UserActivities = new List<UserActivity>
                        {
                            new UserActivity
                            {
                                AppUserId = "b",
                                IsHost = true,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                            new UserActivity
                            {
                                AppUserId = "d",
                                IsHost = false,
                                DateJoined = DateTime.Now.AddMonths(8)
                            },
                        }
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}