namespace BookStore.ViewModel
{
    public class AuthorWithBooksVM
    {
        public string AuthorName { get; set; }
        public List<AuthorBooksListVM> AuthorBooksList { get; set; }
    }
    public class AuthorBooksListVM
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int Bookprice { get; set; }
    }
}
