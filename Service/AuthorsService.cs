using BookStore.Data;
using BookStore.Data.Paginated;
using BookStore.Migrations;
using BookStore.Model;
using BookStore.ViewModel;
using System.Text.RegularExpressions;

namespace BookStore.Service
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        private bool Name_isInValid(string name)
        {
            return (Regex.IsMatch(name, @"^\d|^\s"));
        }
        public List<Author> GetAllAuthors(int pageindex)
        {
            var authors = _context.Authors.ToList();
            int pagesize = 2;
            authors = PaginatedList<Author>.Create(authors, pageindex, pagesize);
            return authors;
        }
        public Author AddNewAuthor(AuthorVM author)
        {
            if (Name_isInValid(author.Name))
                throw new Exception("The Author Name Is InValid");
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
            if (author != null)
                return author;
            else
                throw new Exception("This Author Not Found");
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
            if (exauthor != null)
                return exauthor;
            else
                throw new Exception("This Author Not Found");
        }
        public List<Author> GetAuthorByName(string name)
        {
            var authors = _context.Authors.Where(x => x.Name.Contains(name)).ToList();
            return authors;
        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                throw new Exception("This Author Not Found");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public void UpdateAuthor(AuthorVM author, int id)
        {
            if (Name_isInValid(author.Name))
                throw new Exception("The Author Name Is InValid");
            var exauthor = _context.Authors.Find(id);
            if (exauthor == null)
                throw new Exception("This Author Not Found");
            exauthor.Name = author.Name;
            exauthor.Address = author.Address;
            exauthor.Phone = author.Phone;
            _context.SaveChanges();
        }
    }
}
