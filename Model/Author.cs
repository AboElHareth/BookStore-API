namespace BookStore.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public List<BookAuthor> bookauthors { get; set; }
    }
}
