using BookStore.Data;
using BookStore.Model;
using BookStore.ViewModel;

namespace BookStore.Service
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public List<Publisher> GetAllPublishers()
        {
            var publishers = _context.Publishers.ToList();
            return publishers;
        }
        public Publisher AddNewPublisher(PublisherVM publisher)
        {
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
            return publisher;
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
            return expublisher;
        }
        public List<Publisher> GetPublisherByName(string name)
        {
            var publishers = _context.Publishers.Where(x => x.Name.Contains(name)).ToList();
            return publishers;
        }
        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
        public void UpdatePublisher(PublisherVM publisher, int id)
        {
            var expublisher = _context.Publishers.Find(id);
            expublisher.Name = publisher.Name;
            _context.SaveChanges();
        }
    }
}
