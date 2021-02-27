install-package microsoft.entityframeworkcore.sqlserver -v 3.1.12

private void Button_Click(object sender, RoutedEventArgs e)
{
    BloggingContext dc = new BloggingContext();

    //  dc.Database.EnsureCreated();


    var bloglar = dc.Blogs
        .Include(s=>s.Posts)
        .ToList();

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


    dc.SaveChanges();
}