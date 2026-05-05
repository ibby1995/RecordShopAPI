using RecordShopAPI.Data;
using RecordShopAPI.Models;

namespace RecordShopAPI.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordShopContext _context;

        public AlbumRepository(RecordShopContext context)
        {
            _context = context;
        }

        public List<Album> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album? GetAlbumById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.AlbumId == id);
        }

        public Album AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album;
        }

        public Album? UpdateAlbum(Album album)
        {
            var existing = _context.Albums.FirstOrDefault(a => a.AlbumId == album.AlbumId);
            if (existing == null) return null;
            existing.Name = album.Name;
            existing.Artist = album.Artist;
            existing.Genre = album.Genre;
            existing.ReleaseYear = album.ReleaseYear;
            existing.Stock = album.Stock;
            _context.SaveChanges();
            return existing;
        }

        public bool DeleteAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.AlbumId == id);
            if (album == null) return false;
            _context.Albums.Remove(album);
            _context.SaveChanges();
            return true;
        }

        public List<Album> GetAlbumsByArtist(string artist)
        {
            return _context.Albums.Where(a => a.Artist == artist).ToList();
        }

        public List<Album> GetAlbumsByReleaseYear(int year)
        {
            return _context.Albums.Where(a => a.ReleaseYear == year).ToList();
        }

        public List<Album> GetAlbumsByGenre(string genre)
        {
            return _context.Albums.Where(a => a.Genre == genre).ToList();
        }

        public Album? GetAlbumByName(string name)
        {
            return _context.Albums.FirstOrDefault(a => a.Name == name);
        }


    }
}