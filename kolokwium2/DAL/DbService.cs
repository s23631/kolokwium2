using kolokwium2.DTOs;
using kolokwium2.Exceptions;
using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.DAL;

public class DbService
{
    private readonly MusicDbContext _context;

    public DbService(MusicDbContext context)
    {
        _context = context;
    }

    public IEnumerable<MusicianDto> GetMusician(int id)
    {
        return _context.Musician.Where(m => m.IdMusician == id).Select(e => new MusicianDto()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Nickname = e.Nickname,
            Tracks = e.Tracks.Select(t => new TracksDto()
            {
                TrackName = t.TrackName,
                Duration = t.Duration
            }).OrderBy(d => d.Duration).ToList()
        }).ToList();
    }

    public void DeleteMusician(int id)
    {
        var musician = _context.Musician.Include(m => m.Tracks).FirstOrDefault(m => m.IdMusician == id);
        if (musician == null)
        {
            return;
        }

        if (musician.Tracks == null)
        {
            return;
        }

        var musicianHasTracksWithoutAlbum = musician.Tracks.Any(t => t.IdMusicAlbum == null);
        
        if (musicianHasTracksWithoutAlbum)
        {
            _context.Musician.Remove(musician);
            _context.SaveChanges();
        }
        else
        {
            throw new NotOnAlbumException();
        }
    }
}