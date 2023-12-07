using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment5_Meduna_Naumann.Data;
using System;
using System.Linq;


namespace Assignment5_Meduna_Naumann.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Assignment5_Meduna_NaumannContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Assignment5_Meduna_NaumannContext>>()))
        {
            // Look for any songs.
            if (context.Song.Any())
            {
                return;   // DB has been seeded
            }
            context.Song.AddRange(
                new Song
                {
                    title = "I Saw Her Standing There",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 5.00m
                },
                new Song
                {
                    title = "Misery",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 5.00m
                },
                new Song
                {
                    title = "Anna (Go to Him)",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 5.00m
                },
                new Song
                {
                    title = "Chains",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 1.09m
                },
                new Song
                {
                    title = "Boys",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = .99m
                },
                new Song
                {
                    title = "Ask Me Why",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 1.00m
                },
                new Song
                {
                    title = "Please Please Me",
                    release_date = DateTime.Parse("1963-04-22"),
                    genre = "Rock",
                    artist = "The Beatles",
                    price = 1.00m
                },
                new Song
                {
                    title = "My Old Man",
                    release_date = DateTime.Parse("2017-05-5"),
                    genre = "Indie-Rock",
                    artist = "Mac DeMarco",
                    price = 1.25m
                },
                new Song
                {
                    title = "This Old Dog",
                    release_date = DateTime.Parse("2017-05-5"),
                    genre = "Indie-Rock",
                    artist = "Mac DeMarco",
                    price = 1.25m
                },
                new Song
                {
                    title = "Still Beating",
                    release_date = DateTime.Parse("2017-05-5"),
                    genre = "Indie-Rock",
                    artist = "Mac DeMarco",
                    price = 1.25m
                },
                new Song
                {
                    title = "Wesley's Theory",
                    release_date = DateTime.Parse("2015-03-16"),
                    genre = "Rap",
                    artist = "Kendrick Lamar",
                    price = 1.75m
                },
                new Song
                {
                    title = "King Kunta",
                    release_date = DateTime.Parse("2015-03-16"),
                    genre = "Rap",
                    artist = "Kendrick Lamar",
                    price = 1.75m
                },
                new Song
                {
                    title = "Alright",
                    release_date = DateTime.Parse("2015-03-16"),
                    genre = "Rap",
                    artist = "Kendrick Lamar",
                    price = 1.75m
                }
            );
            context.SaveChanges();
        }
    }

    }
}
