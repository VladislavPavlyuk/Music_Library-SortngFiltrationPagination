namespace MusicLib.Models
{
    public class SortViewModel
    {
        public SortState ArtistNameSort { get; set; } // значение для сортировки по имени артиста
        public SortState ArtistBirthDateSort { get;  set; }    // значение для сортировки по дате рождения по артиста
        public SortState GenreTitleSort { get;  set; }    // значение для сортировки по жанру         
        public SortState SongTitleSort { get;  set; }    // значение для сортировки по названию песни         
        public SortState SongReleaseDateSort { get;  set; }    // значение для сортировки по дате релиза песни 
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            ArtistNameSort = SortState.ArtistNameAsc;
            ArtistBirthDateSort = SortState.ArtistBirthDateAsc;
            GenreTitleSort = SortState.GenreTitleAsc;
            SongTitleSort = SortState.SongTitleAsc;
            SongReleaseDateSort = SortState.SongReleaseDateAsc;

            ArtistNameSort = sortOrder == SortState.ArtistNameAsc ? SortState.ArtistNameDesc : SortState.ArtistNameAsc;
            ArtistBirthDateSort = sortOrder == SortState.ArtistBirthDateAsc ? SortState.ArtistBirthDateDesc : SortState.ArtistBirthDateAsc;
            GenreTitleSort = sortOrder == SortState.GenreTitleAsc ? SortState.GenreTitleDesc : SortState.GenreTitleAsc;
            SongTitleSort = sortOrder == SortState.SongTitleAsc ? SortState.SongTitleDesc : SortState.SongTitleAsc;
            SongReleaseDateSort = sortOrder == SortState.SongReleaseDateAsc ? SortState.SongReleaseDateDesc : SortState.SongReleaseDateAsc;

            Current = sortOrder;
            Console.WriteLine(Current);
        }
    }
}
