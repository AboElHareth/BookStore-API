using BookStore.Data;
using BookStore.Model;
using BookStore.ViewModel;

namespace BookStore.Service
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public List<Author> GetAllAuthors()
        {
            var authors = _context.Authors.ToList();
            return authors;
        }
        public Author AddNewAuthor(AuthorVM author)
        {
            var newauthor = new Author()
            {
                Name = author.Name,
                Address = author.Address,
                Phone = author.Phone
            };
            _context.Authors.Add(newauthor);
            _context.SaveChanges();
            return newauthor;
        }
        public Author GetAuthorById(int id)
        {
            var author = _context.Authors.Find(id);
            return author;
        }
        public AuthorWithBooksVM GetAuthorByIdWithBooks(int id)
        {
            var exauthor = _context.Authors.Where(x => x.Id == id)
                .Select(author => new AuthorWithBooksVM
                {
                    AuthorName = author.Name,
                    AuthorBooksList = author.bookauthors.Select(x => new AuthorBooksListVM()
                    {
                        BookName = x.book.Title,
                        BookDescription = x.book.Description,
                        Bookprice = x.book.Price
                    }).ToList()
                })
                .FirstOrDefault();
            return exauthor;
        }
        public List<Author> GetAuthorByName(string name)
        {
            var authors = _context.Authors.Where(x => x.Name.Contains(name)).ToList();
            return authors;
        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public void UpdateAuthor(AuthorVM author, int id)
        {
            var exauthor = _context.Authors.Find(id);
            exauthor.Name = author.Name;
            exauthor.Address = author.Address;
            exauthor.Phone = author.Phone;
            _context.SaveChanges();
        }
    }
}
