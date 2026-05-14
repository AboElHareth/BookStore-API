using BookStore.Data;
using BookStore.Data.Paginated;
using BookStore.Migrations;
using BookStore.Model;
using BookStore.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks(string sort, string search, int pageindex)
        {
            var books = _context.Books
                .Where(x => x.Title.Contains(search) || x.Description.Contains(search)).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                switch (sort)
                {
                    case "name":
                        books = books.OrderBy(x => x.Title).ToList();
                        break;
                    case "name-desc":
                        books = books.OrderByDescending(x => x.Title).ToList();
                        break;
                    case "price":
                        books = books.OrderBy(x => x.Price).ToList();
                        break;
                    case "price-desc":
                        books = books.OrderByDescending(x => x.Price).ToList();
                        break;
                    case "rating":
                        books = books.OrderBy(x => x.Rate).ToList();
                        break;
                    default:
                        break;
                }
            }
            int pagesize = 2;
            books = PaginatedList<Book>.Create(books, pageindex, pagesize);
            return books;
        }
        public void AddNewBook(BookVM book)
        {
            var newbook = new Book()
            {
                Title = book.Title,
                Price = book.Price,
                Description = book.Description,
                IsRead = book.IsRead,
                ReadDate = book.ReadDate,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                BookUrl = book.BookUrl,
                AddedDate = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(newbook);
            _context.SaveChanges();
            foreach (var id in book.AuthorsId)
            {
                var bookauthor = new BookAuthor()
                {
                    AuthorId = id,
                    BookId = newbook.Id
                };
                _context.BookAuthors.Add(bookauthor);
                _context.SaveChanges();
            }
        }
        public Book GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
                return book;
            else
                throw new Exception("This Book Not Found");
        }
        public BookWithPublisherVM GetBookByIdWithPublisher(int id)
        {
            var exbook = _context.Books.Where(x => x.Id == id)
                .Select(book => new BookWithPublisherVM
                {
                    Title = book.Title,
                    Description = book.Description,
                    Price = book.Price,
                    PublisherName = book.publisher.Name,
                    AuthorsName = book.bookauthors.Select(x => x.author.Name).ToList()
                })
                .FirstOrDefault();
            if (exbook != null)
                return exbook;
            else
                throw new Exception("This Book Not Found");
        }
        public List<BookWithPublisherVM> GetAllBooksWithPublisher()
        {
            var exbooks = _context.Books.Include(x => x.publisher)
                .Include(x => x.bookauthors).ThenInclude(x => x.author).ToList();
            var books = new List<BookWithPublisherVM>();
            foreach (var exbook in exbooks)
            {
                var book = new BookWithPublisherVM()
                {
                    Title = exbook.Title,
                    Description = exbook.Description,
                    Price = exbook.Price,
                    PublisherName = exbook.publisher.Name,
                    AuthorsName = exbook.bookauthors.Select(x => x.author.Name).ToList()
                };
                books.Add(book);
            }
            return books;
        }
        public List<BookWithPublisherVM> GetBooksByNameWithPublisher(string Name)
        {
            var exbooks = _context.Books.Include(x => x.publisher)
                .Include(x => x.bookauthors).ThenInclude(x => x.author)
                .Where(x => x.Title.Contains(Name)).ToList();
            var books = new List<BookWithPublisherVM>();
            foreach (var exbook in exbooks)
            {
                var book = new BookWithPublisherVM()
                {
                    Title = exbook.Title,
                    Description = exbook.Description,
                    Price = exbook.Price,
                    PublisherName = exbook.publisher.Name,
                    AuthorsName = exbook.bookauthors.Select(x => x.author.Name).ToList()
                };
                books.Add(book);
            }
            return books;
        }
        public List<Book> GetBooksByName(string title)
        {
            var books = _context.Books.Where(x => x.Title.Contains(title) || x.Description.Contains(title)).ToList();
            return books;
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                throw new Exception("This Book Not Found");
            _context.Books.Remove(book);
            _context.SaveChanges();
            var exbookauthor = _context.BookAuthors.Where(x => x.BookId == id).ToList();
            _context.RemoveRange(exbookauthor);
            _context.SaveChanges();
        }
        public void UpdateBook(BookVM book, int id)
        {
            var exbook = _context.Books.Find(id);
            if (exbook == null)
                throw new Exception("This Book Not Found");
            exbook.Title = book.Title;
            exbook.Price = book.Price;
            exbook.Description = book.Description;
            exbook.IsRead = book.IsRead;
            exbook. ReadDate = book.ReadDate;
            exbook.Rate = book.Rate;
            exbook.Genre = book.Genre;
            exbook.CoverUrl = book.CoverUrl;
            exbook.BookUrl = book.BookUrl;
            exbook.UpdatedDate = DateTime.Now;
            exbook.PublisherId = book.PublisherId;
            _context.SaveChanges();
            var exbookauthor = _context.BookAuthors.Where(x => x.BookId == id).ToList();
            _context.RemoveRange(exbookauthor);
            _context.SaveChanges();
            foreach (var x in book.AuthorsId)
            {
                var bookauthor = new BookAuthor()
                {
                    AuthorId = x,
                    BookId = exbook.Id
                };
                _context.BookAuthors.Add(bookauthor);
                _context.SaveChanges();
            }
        }   
    }
}
