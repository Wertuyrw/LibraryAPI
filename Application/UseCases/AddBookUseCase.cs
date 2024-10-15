using Application.Services.Interfaces;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AddBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public AddBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //public async Task<Book> ExecuteAsync(Book book)
        //{
        //    // Perform validations and business logic here
        //    return await _bookRepository.AddAsync(book);
        //}
    }
}
