using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BookCreateDTO : BookDTO
    {
        public List<int> Authors { get; set; }
    }
}
