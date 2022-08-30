using Microsoft.EntityFrameworkCore;
using my_books_latest.Data;
using my_books_latest.Data.Models;
using my_books_latest.Data.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace my_books_latest_tests
{
    public class PublisherServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbLatestTest")
            .Options;

        AppDbContext context;
        PublishersService _publisherService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            _publisherService = new PublishersService(context);

           
        }

        [Test, Order(1)]
        public void GetAllPublishers_WithNoSortBy_WithNoSearchString()
        {
            var result = _publisherService.GetAllPublishers("", "");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);

        }


        [Test, Order(3)]
        public void GetAllPublishers_WithSortBy_WithNoSearchString()
        {
            var result = _publisherService.GetAllPublishers("name_desc", "");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);

        }

        [Test, Order(2)]
        public void GetAllPublishers_WithSortBy_WithSearchString()
        {
            var result = _publisherService.GetAllPublishers("name_desc", "3");
            Publisher finalResult = new();
            foreach (var item in result)
            {
                finalResult = item;
            }

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.AreEqual(result.Count, 1);
            Assert.That(finalResult.Name.ToString(), Is.EqualTo("Publisher 3"));
        }

        [Test, Order(4)]

        public void GetPublisherByIdTest()
        {
            var result = _publisherService.GetPublisherWithBooksIncludingAuthors(1);
            Assert.That(result.Name, Is.EqualTo("Publisher 1"));
        }

        [Test, Order(5)]
        public void GetPublisherByIdWithoutResponseTest()
        {
            var result = _publisherService.GetPublisherWithBooksIncludingAuthors(88);
            Assert.That(result,Is.Null);
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    Name = "Publisher 1"
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "Publisher 2"
                },
                new Publisher()
                {
                    Id = 3,
                    Name = "Publisher 3"
                }
            };

            context.Publishers.AddRange(publishers);


            var authors = new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    AuthorName = "Author 1"
                },
                new Author
                {
                    Id = 2,
                    AuthorName = "Author 2"
                },
                new Author
                {
                    Id = 3,
                    AuthorName = "Author 3"
                }
            };


            context.Authors.AddRange(authors);

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Book 1",
                    CoverUrl = "http://book1",
                    isRead = false,
                    PublisherId = 1,
                    Description = "This is the book 1",
                    DateAdded = DateTime.Now,
                },
                new Book
                {
                    Id = 2,
                    Title = "Book 2",
                    CoverUrl = "http://book2",
                    isRead = false,
                    PublisherId = 2,
                    Description = "This is the book 2",
                    DateAdded = DateTime.Now,
                }
            };

            context.Books.AddRange(books);

            var book_authors = new List<Book_Author>()
            {
                new Book_Author
                {
                    Id = 1,
                    AuthorId = 1,
                    BookId = 1
                },
                new Book_Author
                {
                    Id = 2,
                    AuthorId = 1,
                    BookId = 2
                },
                new Book_Author
                {
                    Id = 3,
                    AuthorId = 1,
                    BookId = 1
                },
                 new Book_Author
                {
                    Id = 4,
                    AuthorId = 2,
                    BookId = 2
                },
                 new Book_Author
                {
                    Id = 5,
                    AuthorId = 3,
                    BookId = 2
                }
            };

            context.Books_Authors.AddRange(book_authors);

            context.SaveChanges();
        }
        
    }
}