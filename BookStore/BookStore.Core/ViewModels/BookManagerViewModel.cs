using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.ViewModels
{
    public class BookManagerViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<BookGenre> BookGenres { get; set; }
    }
}
