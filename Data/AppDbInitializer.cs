using BookStore.Model;

namespace BookStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder application)
        {
            using (var scope = application.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            Title = "Atoms First and The Chemical Principels",
                            Description = "Chemical book",
                            IsRead = false,
                            Price = 350,
                            Genre = "Chemistry",
                            CoverUrl = "...",
                            BookUrl = "...",
                            AddedDate = DateTime.Now
                        },
                        new Book()
                        {
                            Title = "The Great Gatsby",
                            Description = "The Great Gatsby book",
                            IsRead = false,
                            Price = 350,
                            Genre = "Chemistry",
                            CoverUrl = "...",
                            BookUrl = "...",
                            AddedDate = DateTime.Now
                        },
                        new Book()
                        {
                            Title = "Origami Omnibus",
                            Description = "Origami Omnibus book",
                            IsRead = false,
                            Price = 250,
                            Genre = "Chemistry",
                            CoverUrl = "...",
                            BookUrl = "...",
                            AddedDate = DateTime.Now
                        },
                        new Book()
                        {
                            Title = "Wuthering Heights",
                            Description = "Wuthering Heights book",
                            IsRead = false,
                            Price = 180,
                            Genre = "Chemistry",
                            CoverUrl = "...",
                            BookUrl = "...",
                            AddedDate = DateTime.Now
                        });
                    context.SaveChanges();
                }
                if(!context.Authors.Any())
                {
                    context.AddRange(
                        new Author()
                        {
                            Name = "Khalid Ayman"
                        },
                        new Author()
                        {
                            Name = "Mohamed Ahmed"
                        },
                        new Author()
                        {
                            Name = "Yousef Afif"
                        },
                        new Author()
                        {
                            Name = "Mohamed Yasser"
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.Publishers.Any())
                {
                    context.AddRange(
                        new Publisher()
                        {
                            Name = "Andrew Atef"
                        },
                        new Publisher()
                        {
                            Name = "Mohamed Ali"
                        },
                        new Publisher()
                        {
                            Name = "Hammad Ahmed"
                        },
                        new Publisher()
                        {
                            Name = "Mohamed Gaber"
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
