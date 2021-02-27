using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Intro
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseSqlServer(@"Server=localhost,1433;Database=MyDb;user id=sa;password=Ankara!06;Application Name=Pandap")
              ;
        }
    }

    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public Blog()
        {
            Posts = new List<Post>();
        }
        public List<Post> Posts { get; set; }

        public void PostlariEkle(List<Post> liste)
        {
            foreach (var item in liste)
            {
                item.BlogId = this.Id;
                Posts.Add(item);
            }
        }
    }

    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }

   

    }
}