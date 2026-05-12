namespace BookStore.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> books { get; set; }
    }
}
