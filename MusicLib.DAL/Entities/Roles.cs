﻿namespace MusicLib.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
