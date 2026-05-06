using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using RecordShopAPI.Models;
using RecordShopAPI.Services;
using RecordShopAPI.Controllers;

namespace RecordShopAPI.Tests.Services
{
    [TestFixture]
    public class AlbumsControllerTests
    {
        private Mock<IAlbumService> _mockService;
        private AlbumsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IAlbumService>();
            _controller = new AlbumsController(_mockService.Object);
        }

        [Test]
        public void GetAlbumById_InvalidId_ReturnsBadRequest()
        {
            var result = _controller.GetAlbumById(0);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void GetAlbumById_NotFound_Returns404()
        {
            _mockService.Setup(s => s.GetAlbumById(99)).Returns((Album?)null);
            var result = _controller.GetAlbumById(99);
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void AddAlbum_NullAlbum_ReturnsBadRequest()
        {
            var result = _controller.AddAlbum(null!);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void AddAlbum_MissingName_ReturnsBadRequest()
        {
            var album = new Album { Artist = "50 Cent" };
            var result = _controller.AddAlbum(album);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void AddAlbum_MissingArtist_ReturnsBadRequest()
        {
            var album = new Album { Name = "Get Rich Or Die Tryin" };
            var result = _controller.AddAlbum(album);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void DeleteAlbum_InvalidId_ReturnsBadRequest()
        {
            var result = _controller.DeleteAlbum(0);
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public void DeleteAlbum_NotFound_Returns404()
        {
            _mockService.Setup(s => s.DeleteAlbum(99)).Returns(false);
            var result = _controller.DeleteAlbum(99);
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }
    }
}