using RecordShopAPI.Models;

namespace RecordShopAPI.Repository
{
    public interface IAlbumRepository
    {
        List<Album> GetAlbumsByArtist(string artist);
        List<Album> GetAlbumsByReleaseYear(int year);
        List<Album> GetAlbumsByGenre(string genre);
        Album? GetAlbumByName(string name);
        List<Album> GetAllAlbums();
        Album? GetAlbumById(int id);
        Album AddAlbum(Album album);
        Album? UpdateAlbum(Album album);
        bool DeleteAlbum(int id);
    }
}