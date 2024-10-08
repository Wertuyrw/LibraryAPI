﻿namespace Domain.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public List<BookAuthor> BookAuthors { get; set; } = new();
    }
}
