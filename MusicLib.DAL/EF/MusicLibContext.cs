using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MusicLib.DAL.Entities;
using System.Diagnostics;

namespace MusicLib.DAL.EF
{   
    public class MusicLibContext : DbContext
    { 

        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasOne<Genre>(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Song>()
                .HasOne<Artist>(s => s.Artist)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Song>()
                .HasOne<Video>(s => s.Video)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.VideoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Video> Videos { get; set; }
        public MusicLibContext(DbContextOptions<MusicLibContext> options)
                   : base(options)
        {
            if (Database.EnsureCreated())
            {
                Roles.Add(new Role { Title = "Admin" });
                Roles.Add(new Role { Title = "User" });
                Roles.Add(new Role { Title = "Candidate" });

                Users.Add(new User
                {
                    Email = "admin@admin.com",
                    Password = "63F66566834843057ECD47890F10987FBD0D2022BB2A8ED84ED04890B9644E1C",
                    Salt = "073B6AA3BED5420579D70404FD470461",
                    RoleId = 1
                });
                
                Genres.Add(new Genre { Title = "Rock" });
                Genres.Add(new Genre { Title = "Pop" });
                Genres.Add(new Genre { Title = "Rap" });
                Genres.Add(new Genre { Title = "Jazz" });
                Genres.Add(new Genre { Title = "Classic" });
                Genres.Add(new Genre { Title = "Metal" });
                Genres.Add(new Genre { Title = "Blues" });
                Genres.Add(new Genre { Title = "Country" });
                Genres.Add(new Genre { Title = "Electronic" });
                Genres.Add(new Genre { Title = "Folk" });
                Genres.Add(new Genre { Title = "Indie" });
                Genres.Add(new Genre { Title = "Reggae" });
                Genres.Add(new Genre { Title = "Latin" });
                Genres.Add(new Genre { Title = "Punk" });
                Genres.Add(new Genre { Title = "Soul" });
                Genres.Add(new Genre { Title = "R&B" });
                Genres.Add(new Genre { Title = "Gospel" });
                Genres.Add(new Genre { Title = "New Age" });
                Genres.Add(new Genre { Title = "World" });
                Genres.Add(new Genre { Title = "Experimental" });
                Genres.Add(new Genre { Title = "Easy Listening" });
                Genres.Add(new Genre { Title = "Soundtrack" });
                Genres.Add(new Genre { Title = "Comedy" });
                Genres.Add(new Genre { Title = "Children's" });
                Genres.Add(new Genre { Title = "Holiday" });
                Genres.Add(new Genre { Title = "Other" });
                
                Artists.Add(new Artist { Name = "The Beatles" });
                Artists.Add(new Artist { Name = "Elvis Presley" });
                Artists.Add(new Artist { Name = "Michael Jackson" });
                Artists.Add(new Artist { Name = "Elton John" });
                Artists.Add(new Artist { Name = "Madonna" });
                Artists.Add(new Artist { Name = "Led Zeppelin" });
                Artists.Add(new Artist { Name = "Pink Floyd" });
                Artists.Add(new Artist { Name = "Queen" });
                Artists.Add(new Artist { Name = "The Rolling Stones" });
                Artists.Add(new Artist { Name = "Bob Dylan" });
                Artists.Add(new Artist { Name = "David Bowie" });
                Artists.Add(new Artist { Name = "Bruce Springsteen" });
                Artists.Add(new Artist { Name = "Prince" });
                Artists.Add(new Artist { Name = "The Who" });
                Artists.Add(new Artist { Name = "Stevie Wonder" });
                Artists.Add(new Artist { Name = "Bob Marley" });
                Artists.Add(new Artist { Name = "James Brown" });
                Artists.Add(new Artist { Name = "U2" });
                Artists.Add(new Artist { Name = "The Doors" });
                Artists.Add(new Artist { Name = "Aretha Franklin" });
                Artists.Add(new Artist { Name = "Nirvana" });               

                Songs.Add(new Song { Title = "Bohemian Rhapsody", Release = "1975", GenreId = 1, ArtistId = 7, YoutubeLink = "https://www.youtube.com/watch?v=fJ9rUzIMcZQ" });
                Songs.Add(new Song { Title = "Imagine", Release = "1971", GenreId = 1, ArtistId = 4, YoutubeLink = "https://www.youtube.com/watch?v=DVg2EJvvlF8" });
                Songs.Add(new Song { Title = "Hotel California", Release = "1977", GenreId = 1, ArtistId = 20, YoutubeLink = "https://www.youtube.com/watch?v=EqPtz5qN7HM" });
                Songs.Add(new Song { Title = "Stairway to Heaven", Release = "1971", GenreId = 1, ArtistId = 6, YoutubeLink = "https://www.youtube.com/watch?v=QkF3oxziUI4" });
                Songs.Add(new Song { Title = "Like a Rolling Stone", Release = "1965", GenreId = 1, ArtistId = 10, YoutubeLink = "https://www.youtube.com/watch?v=JGfXiIXTpU0" });
                Songs.Add(new Song { Title = "Hey Jude", Release = "1968", GenreId = 1, ArtistId = 1, YoutubeLink = "https://www.youtube.com/watch?v=A_MjCqQoLLA" });
                Songs.Add(new Song { Title = "Smells Like Teen Spirit", Release = "1991", GenreId = 1, ArtistId = 19, YoutubeLink = "https://www.youtube.com/watch?v=hTWKbfoikeg" });
                Songs.Add(new Song { Title = "What's Going On", Release = "1971", GenreId = 1, ArtistId = 16, YoutubeLink = "https://www.youtube.com/watch?v=H-kA3UtBj4M" });
                Songs.Add(new Song { Title = "Born to Run", Release = "1975", GenreId = 1, ArtistId = 11, YoutubeLink = "https://www.youtube.com/watch?v=IxuThNgl3YA" });
                Songs.Add(new Song { Title = "I Want to Hold Your Hand", Release = "1963", GenreId = 1, ArtistId = 1, YoutubeLink = "https://www.youtube.com/watch?v=jenWdylTtzs" });
                Songs.Add(new Song { Title = "Purple Haze", Release = "1967", GenreId = 1, ArtistId = 21, YoutubeLink = "https://www.youtube.com/watch?v=ccvHJU5O4ZQ" });
                Songs.Add(new Song { Title = "A Change Is Gonna Come", Release = "1964", GenreId = 1, ArtistId = 16, YoutubeLink = "https://www.youtube.com/watch?v=wEBlaMOmKV4" });
                Songs.Add(new Song { Title = "Lose Yourself", Release = "2002", GenreId = 1, ArtistId = 3, YoutubeLink = "https://www.youtube.com/watch?v=_Yhyp-_hX2s" });
                Songs.Add(new Song { Title = "Let It Be", Release = "1970", GenreId = 1, ArtistId = 1, YoutubeLink = "https://www.youtube.com/watch?v=QDYfEBY9NM4" });           

                SaveChanges();
            }
        }
    }
    // Класс необходим исключительно для миграций
    public class SampleContextFactory : IDesignTimeDbContextFactory<MusicLibContext>
    {
        public MusicLibContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicLibContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new MusicLibContext(optionsBuilder.Options);
        }
    }
}
