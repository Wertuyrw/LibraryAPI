namespace Application.DTO
{
    public class AuthorTakenDTO : AuthorDTO
    {
        public int AuthorId { get; set; }
        public List<int> BooksId { get; set; }
    }
}
