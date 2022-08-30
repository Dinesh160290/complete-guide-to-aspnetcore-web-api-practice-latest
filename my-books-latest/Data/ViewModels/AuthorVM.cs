using my_books_latest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data.ViewModels
{
    public class AuthorVM
    {
        public string AuthorName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string AuthorName { get; set; }

        public List<string> Author_With_Books{ get; set; }
    }
}
