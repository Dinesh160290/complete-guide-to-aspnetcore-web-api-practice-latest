﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public List<Book_Author> Book_Authors { get; set; }
    }
}
