using Moq;
using NUnit.Framework;
using RecordShopAPI.Models;
using RecordShopAPI.Repository;
using RecordShopAPI.Services;

namespace RecordShopAPI.Tests.Services
{
    [TestFixture]
    public class AlbumServiceTests
    {
        private Mock<IAlbumRepository> _mockRepository;
        private AlbumService _albumService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAlbumRepository>();
            _albumService = new AlbumService(_mockRepository.Object);
        }

        [Test]
        public void GetAllAlbums_ReturnsAllAlbums()
        {
            var albums = new List<Album>
            {
                new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Artist = "50 Cent" },
                new Album { AlbumId = 2, Name = "Burden Of Proof", Artist = "Benny The Butcher" }
            };
            _mockRepository.Setup(r => r.GetAllAlbums()).Returns(albums);

            var result = _albumService.GetAllAlbums();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAlbumById_ValidId_ReturnsAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Artist = "50 Cent" };
            _mockRepository.Setup(r => r.GetAlbumById(1)).Returns(album);

            var result = _albumService.GetAlbumById(1);

            Assert.That(result, Is.EqualTo(album));
        }

        [Test]
        public void GetAlbumById_InvalidId_ReturnsNull()
        {
            _mockRepository.Setup(r => r.GetAlbumById(99)).Returns((Album?)null);

            var result = _albumService.GetAlbumById(99);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddAlbum_ReturnsAddedAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Artist = "50 Cent" };
            _mockRepository.Setup(r => r.AddAlbum(album)).Returns(album);

            var result = _albumService.AddAlbum(album);

            Assert.That(result, Is.EqualTo(album));
        }

        [Test]
        public void UpdateAlbum_ValidAlbum_ReturnsUpdatedAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin Updated", Artist = "50 Cent" };
            _mockRepository.Setup(r => r.UpdateAlbum(album)).Returns(album);

            var result = _albumService.UpdateAlbum(album);

            Assert.That(result, Is.EqualTo(album));
        }

        [Test]
        public void UpdateAlbum_InvalidAlbum_ReturnsNull()
        {
            var album = new Album { AlbumId = 99, Name = "doesnt exist" };
            _mockRepository.Setup(r => r.UpdateAlbum(album)).Returns((Album?)null);

            var result = _albumService.UpdateAlbum(album);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void DeleteAlbum_ValidId_ReturnsTrue()
        {
            _mockRepository.Setup(r => r.DeleteAlbum(1)).Returns(true);

            var result = _albumService.DeleteAlbum(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteAlbum_InvalidId_ReturnsFalse()
        {
            _mockRepository.Setup(r => r.DeleteAlbum(99)).Returns(false);

            var result = _albumService.DeleteAlbum(99);

            Assert.That(result, Is.False);
        }
        [Test]
        public void GetAlbumsByArtist_ReturnsAlbums()
        {
            var albums = new List<Album>
    {
        new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Artist = "50 Cent" },
        new Album { AlbumId = 2, Name = "Burden Of Proof", Artist = "Benny The Butcher" }
    };
            _mockRepository.Setup(r => r.GetAlbumsByArtist("50 Cent")).Returns(albums);

            var result = _albumService.GetAlbumsByArtist("50 Cent");

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAlbumsByReleaseYear_ReturnsAlbums()
        {
            var albums = new List<Album>
    {
        new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", ReleaseYear = 2006 }
    };
            _mockRepository.Setup(r => r.GetAlbumsByReleaseYear(2006)).Returns(albums);

            var result = _albumService.GetAlbumsByReleaseYear(2006);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetAlbumsByGenre_ReturnsAlbums()
        {
            var albums = new List<Album>
    {
        new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Genre = "Rap" },
        new Album { AlbumId = 2, Name = "Burden Of Proof", Genre = "Rap" }
    };
            _mockRepository.Setup(r => r.GetAlbumsByGenre("Rap")).Returns(albums);

            var result = _albumService.GetAlbumsByGenre("Rap");

            Assert.That(result.Count, Is.EqualTo(2));
        }
        [Test]
        public void GetAlbumByName_ValidName_ReturnsAlbum()
        {
            var album = new Album { AlbumId = 1, Name = "Get Rich Or Die Tryin", Artist = "50 Cent" };
            _mockRepository.Setup(r => r.GetAlbumByName("Get Rich Or Die Tryin")).Returns(album);

            var result = _albumService.GetAlbumByName("Get Rich Or Die Tryin");

            Assert.That(result, Is.EqualTo(album));
        }

        [Test]
        public void GetAlbumByName_InvalidName_ReturnsNull()
        {
            _mockRepository.Setup(r => r.GetAlbumByName("Unknown")).Returns((Album?)null);

            var result = _albumService.GetAlbumByName("Unknown");

            Assert.That(result, Is.Null);
        }
        



    }
}