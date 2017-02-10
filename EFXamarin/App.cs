using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xamarin.Forms;

namespace EFXamarin
{
    public class App : Application
    {
        public App(string dbPath)
        {
            List<Blog> itemSource;

            // Create Database & Tables
            using (var db = new DatabaseContext(dbPath))
            {
                // Ensure database is created
                db.Database.EnsureCreated();

                // Insert Data
                db.Add(new Blog() { BlogId = 1, Rating = 5, Url = "https://exrin.net" });
                db.Add(new Blog() { BlogId = 2, Rating = 5, Url = "https://xamarinhelp.com" });
                db.SaveChanges();

                // Retreive Data
                itemSource = db.Blogs.ToList();
            }

            // Show Data
            MainPage = new ContentPage()
            {
                Content = new ListView()
                {
                    ItemsSource = itemSource
                }
            };

        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        private string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }

    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
