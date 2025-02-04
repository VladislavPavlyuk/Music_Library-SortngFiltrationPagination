using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class SongService : ISongService
    {
        IUnitOfWork Database { get; set; }

        public SongService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateSong(SongDTO songDto)
        {
            var song = new Song
            {
                Id = songDto.Id,
                Title = songDto.Title,
                Release = songDto.Release,
                GenreId = songDto.GenreId,
                ArtistId = songDto.ArtistId,
                VideoId = songDto.VideoId
            };
            await Database.Songs.Create(song);

            await Database.Save();
        }

        public async Task UpdateSong(SongDTO songDto)
        {
            var song = new Song
            {
                Id = songDto.Id,
                Title = songDto.Title,
                Release = songDto.Release,
                GenreId = songDto.GenreId,
                ArtistId = songDto.ArtistId,
                VideoId = songDto.VideoId
            };
            Database.Songs.Update(song);

            await Database.Save();
        }

        public async Task DeleteSong(int id)
        {
            await Database.Songs.Delete(id);

            await Database.Save();
        }

        public async Task<SongDTO> GetSong(int id)
        {
            var song = await Database.Songs.Get(id);

            if (song == null)
                throw new ValidationException("Wrong song!", "");

            return new SongDTO
            {
                Id = song.Id,
                Title = song.Title,
                Release = song.Release,
                GenreId = song.GenreId,
                Genre = song.Genre?.Title,
                ArtistId = song.ArtistId,
                Artist = song.Artist?.Name,
                VideoId = song.VideoId,
                Video = song.Video?.FileName
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.

        public async Task<IEnumerable<SongDTO>> GetSongs()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Song, SongDTO>()
            .ForMember("Genre", opt => opt.MapFrom(c => c.Genre.Title))
            .ForMember("Artist", opt => opt.MapFrom(c => c.Artist.Name))
            .ForMember("Video", opt => opt.MapFrom(c => c.Video.FileName))
            );

            var mapper = new Mapper(config);

            return mapper.Map<IEnumerable<Song>, IEnumerable<SongDTO>>(await Database.Songs.GetAll());
        }

        public async Task<IEnumerable<SongDTO>> GetSortedItemsAsync(string sortOrder)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Song, SongDTO>()
            .ForMember("Genre", opt => opt.MapFrom(c => c.Genre.Title))
            .ForMember("Artist", opt => opt.MapFrom(c => c.Artist.Name))
            .ForMember("Video", opt => opt.MapFrom(c => c.Video.FileName))
            );

            var mapper = new Mapper(config);

            return mapper.Map<IEnumerable<Song>, IEnumerable<SongDTO>>(await Database.Songs.GetSortedAsync(sortOrder));
            
        }
    }
}
