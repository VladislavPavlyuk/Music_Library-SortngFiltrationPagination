using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLib.BLL.DTO;

namespace MusicLib.Models
{
    public class UserListViewModel
    {
        public IEnumerable<SongDTO> Songs { get; set; } = new List<SongDTO>();
        public SelectList Genres { get; set; } = new SelectList(new List<GenreDTO>(), "Id", "Title");
        public SelectList Artists { get; set; } = new SelectList(new List<ArtistDTO>(), "Id", "Name");
    }
}
