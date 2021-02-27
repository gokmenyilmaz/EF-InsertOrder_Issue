using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Intro;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WpfEF_RamdomProblem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BloggingContext dc = new BloggingContext();

            dc.Blogs.RemoveRange(dc.Blogs.ToList());
            dc.SaveChanges();
          
           // dc.Database.EnsureCreated();

            var bloglar = new List<Blog> { new Blog { Url = "A" }, new Blog { Url = "B" }, new Blog { Url = "C" } };

            //var bloglar = dc.Blogs.Include(s => s.Posts).ToList();


            var l = new List<Post>();

            l.Add(new Post { Title = "1" });
            l.Add(new Post { Title = "2" });
            l.Add(new Post { Title = "3" });
            l.Add(new Post { Title = "4" });
            l.Add(new Post { Title = "5" });
            l.Add(new Post { Title = "6" });

            foreach (var blog in bloglar)
            {
                var listeJson = JsonConvert.SerializeObject(l);
                var des = JsonConvert.DeserializeObject<List<Post>>(listeJson);

                blog.PostlariEkle(des);
            }

            dc.AddRange(bloglar);

            dc.SaveChanges();
        }
    }
}
