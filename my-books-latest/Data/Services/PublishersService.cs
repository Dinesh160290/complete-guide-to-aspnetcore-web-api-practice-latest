using my_books_latest.Data.Models;
using my_books_latest.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM pubisher)
        {
            var _publisher = new Publisher()
            {
                Name = pubisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();


            return _publisher;
        }

        public PublisherWithBooksIncludingAuthors GetPublisherWithBooksIncludingAuthors(int publisherId)
        {
            var _publisherWithBooksIncludingAuthors = _context.Publishers.Where(n => n.Id == publisherId).Select(publisher => new PublisherWithBooksIncludingAuthors()
            {
                Name = publisher.Name,
                BooksList = publisher.Books.Select(e => new BookWithAuthorsVM()
                {
                    Title = e.Title,
                    AuthorNames = e.Book_Authors.Select(f => f.Author.AuthorName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisherWithBooksIncludingAuthors;
        }


        public List<Publisher> GetAllPublishers(string ordername, string filterBy)
        {
            var publishers = new List<Publisher>();
            switch(ordername)
            {
                case "name_asc":
                    publishers = _context.Publishers.OrderBy(n => n.Name).ToList();
                    break;
                case "name_desc":
                    publishers = _context.Publishers.OrderByDescending(n => n.Name).ToList();
                    break;
                default:
                    publishers = _context.Publishers.ToList();
                    break;
            }


            if(!string.IsNullOrEmpty(filterBy))
            {
                publishers = publishers.Where(n => n.Name.Contains(filterBy, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return publishers;
        }



    }
}
