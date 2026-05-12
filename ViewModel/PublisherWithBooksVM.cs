namespace BookStore.ViewModel
{
    public class PublisherWithBooksVM
    {
        public string PublisherName { get; set; }
        public List<PublisherBooksListVM> PublisherBooksList { get; set; }
    }
    public class PublisherBooksListVM
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int Bookprice { get; set; }
        public List<BookAuthorsListVM> BookAuthorsList { get; set; }
    }
    public class BookAuthorsListVM
    {
        public string AuthorName { get; set; }
        public string AuthorAddress { get; set; }
        public string AuthorPhone { get; set; }
    }
}
