﻿using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;

namespace MusicLib.DAL.Repositories
{
    public class ArtistRepository : IRepository<Artist>
    {
        private MusicLibContext db;

        public ArtistRepository(MusicLibContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await db.Artists.ToListAsync();
        }

        public async Task<Artist> Get(int id)
        {
            Artist? artist = await db.Artists.FindAsync(id);
            return artist!;
        }

        public async Task<Artist> Get(string name)
        {
            var artists = await db.Artists.Where(a => a.Name == name).ToListAsync();
            Artist? artist = artists?.FirstOrDefault();
            return artist!;
        }

        public async Task Create(Artist artist)
        {
            await db.Artists.AddAsync(artist);
        }

        public void Update(Artist artist)
        {
            db.Entry(artist).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Artist? artist = await db.Artists.FindAsync(id);
            if (artist != null)
                db.Artists.Remove(artist);
        }

        public async Task<IEnumerable<Artist>> GetSortedAsync(string sortOrder)
        {
            var items = from i in db.Artists
                        select i;

            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(i => i.Name);
                    break;
                case "date":
                    items = items.OrderBy(i => i.BirthDate);
                    break;
                case "date_desc":
                    items = items.OrderByDescending(i => i.Name);
                    break;
                default:
                    items = items.OrderBy(i => i.BirthDate);
                    break;
            }

            return await items.ToListAsync();
        }
    }
}
