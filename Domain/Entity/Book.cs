namespace Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<BookAuthor> BookAuthors { get; set; } = new();
        //public bool IsCheckedOut { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
