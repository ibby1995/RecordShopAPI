using Microsoft.AspNetCore.Mvc;
using RecordShopAPI.Models;
using RecordShopAPI.Services;

namespace RecordShopAPI.Controllers
{
    [Route("/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET all albums
        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }

        // GET album by id
        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _albumService.GetAlbumById(id);
            if (album == null) return NotFound("Album not found.");
            return Ok(album);
        }

        // POST add new album
        [HttpPost]
        public IActionResult AddAlbum([FromBody] Album album)
        {
            var created = _albumService.AddAlbum(album);
            return Ok(created);
        }

        // PUT update album
        [HttpPut]
        public IActionResult UpdateAlbum([FromBody] Album album)
        {
            var updated = _albumService.UpdateAlbum(album);
            if (updated == null) return NotFound("Album not found.");
            return Ok(updated);
        }

        // DELETE album
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var deleted = _albumService.DeleteAlbum(id);
            if (!deleted) return NotFound("Album not found.");
            return Ok();
        }

        // GET albums by artist
        [HttpGet("artist/{artist}")]
        public IActionResult GetAlbumsByArtist(string artist)
        {
            var albums = _albumService.GetAlbumsByArtist(artist);
            return Ok(albums);
        }

        // GET albums by release year
        [HttpGet("year/{year}")]
        public IActionResult GetAlbumsByReleaseYear(int year)
        {
            var albums = _albumService.GetAlbumsByReleaseYear(year);
            return Ok(albums);
        }

        // GET albums by genre
        [HttpGet("genre/{genre}")]
        public IActionResult GetAlbumsByGenre(string genre)
        {
            var albums = _albumService.GetAlbumsByGenre(genre);
            return Ok(albums);
        }

        // GET album by name
        [HttpGet("name/{name}")]
        public IActionResult GetAlbumByName(string name)
        {
            var album = _albumService.GetAlbumByName(name);
            if (album == null) return NotFound("Album not found.");
            return Ok(album);
        }
    }
}