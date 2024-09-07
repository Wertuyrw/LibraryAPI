using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BookTakenDTO : BookDTO
    {
        public int Id { get; set; }
        public List<AuthorCreateDTO> Authors { get; set; }
        public DateTime CheckoutDate { get; init; }
        public DateTime ReturnDate { get; init; }
    }
}
