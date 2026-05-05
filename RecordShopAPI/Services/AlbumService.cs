using RecordShopAPI.Models;
using RecordShopAPI.Repository;

namespace RecordShopAPI.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }

        public Album? GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public Album AddAlbum(Album album)
        {
            return _albumRepository.AddAlbum(album);
        }

        public Album? UpdateAlbum(Album album)
        {
            return _albumRepository.UpdateAlbum(album);
        }

        public bool DeleteAlbum(int id)
        {
            return _albumRepository.DeleteAlbum(id);
        }

        public List<Album> GetAlbumsByArtist(string artist)
        {
            return _albumRepository.GetAlbumsByArtist(artist);
        }

        public List<Album> GetAlbumsByReleaseYear(int year)
        {
            return _albumRepository.GetAlbumsByReleaseYear(year);
        }

        public List<Album> GetAlbumsByGenre(string genre)
        {
            return _albumRepository.GetAlbumsByGenre(genre);
        }

        public Album? GetAlbumByName(string name)
        {
            return _albumRepository.GetAlbumByName(name);
        }
    }
}