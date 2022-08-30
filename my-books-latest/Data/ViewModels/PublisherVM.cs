using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksIncludingAuthors
    {
        public string Name { get; set; }

        public List<BookWithAuthorsVM> BooksList { get; set; }


    }
}
