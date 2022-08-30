using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using my_books_latest.Controllers;
using my_books_latest.Data;
using my_books_latest.Data.Models;
using my_books_latest.Data.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_latest_tests
{
    public class PublisherControllerTest
    {

        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
          .UseInMemoryDatabase(databaseName: "BookDbLatestControllerTest")
          .Options;


        AppDbContext context;
        PublishersService _publisherService;
        PublisherController _publisherController;

        [OneTimeSetUp]
        public void Setup()
        {
            context           = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            _publisherService = new PublishersService(context);
            _publisherController = new PublisherController(_publisherService, new NullLogger<PublisherController>());
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


        [Test]

        public void GetAllPublishersTest()
        {
            IActionResult iActionResult = _publisherController.GetAllPublishers("", "Publisher 1");
            Assert.That(iActionResult, Is.TypeOf<OkObjectResult>());
            var actionResultData = (iActionResult as OkObjectResult).Value as List<Publisher>;
            foreach (var finalResult in actionResultData)
            {
                Assert.That(finalResult.Name, Is.EqualTo("Publisher 1"));
                Assert.That(actionResultData.Count, Is.EqualTo(1));
            }
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

            context.SaveChanges();
        }







    }
}
