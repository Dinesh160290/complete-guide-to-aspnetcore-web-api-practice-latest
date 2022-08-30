using my_books_latest.Data.Models;
using my_books_latest.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                AuthorName = author.AuthorName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooksById(int authorId)
        {
            var _authorWithBooks = _context.Authors.Where(n => n.Id == authorId).Select(author => new AuthorWithBooksVM()
            {
                AuthorName = author.AuthorName,
                Author_With_Books = author.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _authorWithBooks;
        }



    }
}
