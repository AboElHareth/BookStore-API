using BookStore.Data;
using BookStore.Data.Paginated;
using BookStore.Model;
using BookStore.ViewModel;
using System.Text.RegularExpressions;

namespace BookStore.Service
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        private bool Name_isInValid(string name)
        {
            return (Regex.IsMatch(name, @"^\d|^\s"));
        }
        public List<Publisher> GetAllPublishers(int pageindex)
        {
            var publishers = _context.Publishers.ToList();
            int pagesize = 2;
            publishers = PaginatedList<Publisher>.Create(publishers, pageindex, pagesize);
            return publishers;
        }
        public Publisher AddNewPublisher(PublisherVM publisher)
        {
            if (Name_isInValid(publisher.Name))
                throw new Exception("The Publisher Name Is InValid");
            var newpublisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(newpublisher);
            _context.SaveChanges();
            return newpublisher;
        }
        public Publisher GetPublisherById(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher != null)
                return publisher;
            else
                throw new Exception("This Publisher Not Found");
        }
        public PublisherWithBooksVM GetPublisherByIdWithBooks(int id)
        {
            var expublisher = _context.Publishers.Where(x => x.Id == id)
                .Select(publisher => new PublisherWithBooksVM()
                {
                    PublisherName = publisher.Name,
                    PublisherBooksList = publisher.books.Select(book => new PublisherBooksListVM()
                    {
                        BookName = book.Title,
                        BookDescription = book.Description,
                        Bookprice = book.Price,
                        BookAuthorsList = book.bookauthors.Select(x => new BookAuthorsListVM()
                        {
                            AuthorName = x.author.Name,
                            AuthorAddress = x.author.Address,
                            AuthorPhone = x.author.Phone
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefault();
            if (expublisher != null)
                return expublisher;
            else
                throw new Exception("This Publisher Not Found");
        }
        public List<Publisher> GetPublisherByName(string name)
        {
            var publishers = _context.Publishers.Where(x => x.Name.Contains(name)).ToList();
            return publishers;
        }
        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher == null)
                throw new Exception("This Publisher Not Found");
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
        public void UpdatePublisher(PublisherVM publisher, int id)
        {
            if (Name_isInValid(publisher.Name))
                throw new Exception("The Publisher Name Is InValid");
            var expublisher = _context.Publishers.Find(id);
            if (expublisher == null)
                throw new Exception("This Publisher Not Found");
            expublisher.Name = publisher.Name;
            _context.SaveChanges();
        }
    }
}
