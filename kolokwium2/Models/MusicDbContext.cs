using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Models;

public class MusicDbContext : DbContext
{
    public DbSet<Album> Album { get; set; }
    public DbSet<Musician> Musician { get; set; }
    public DbSet<MusicLabel> MusicLabel { get; set; }
    public DbSet<Track> Track { get; set; }

    public MusicDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MusicLabel>().HasData(
            new MusicLabel {IdMusicLabel = 1, Name = "EMI"},
            new MusicLabel {IdMusicLabel = 2, Name = "Sony"},
            new MusicLabel {IdMusicLabel = 3, Name = "Warner"}
        );
        modelBuilder.Entity<Album>().HasData(
            new Album {IdAlbum = 1, AlbumName = "Album1", PublishDate = DateTime.Now, IdMusicLabel = 1},
            new Album {IdAlbum = 2, AlbumName = "Album2", PublishDate = DateTime.Now, IdMusicLabel = 2},
            new Album {IdAlbum = 3, AlbumName = "Album3", PublishDate = DateTime.Now, IdMusicLabel = 3}
        );
        modelBuilder.Entity<Musician>().HasData(
            new Musician {IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", Nickname = "Janek"},
            new Musician {IdMusician = 2, FirstName = "Stachu", LastName = "Jones", Nickname = null},
            new Musician {IdMusician = 3, FirstName = "Jan", LastName = "Paweł", Nickname = "Lolek"});

        modelBuilder.Entity<Track>().HasData(
            new Track {IdTrack = 1, TrackName = "Track1", Duration = 1.5f, IdMusicAlbum = 1},
            new Track {IdTrack = 2, TrackName = "Track2", Duration = 2f, IdMusicAlbum = null},
            new Track {IdTrack = 3, TrackName = "Track3", Duration = 3f, IdMusicAlbum = 2}
        );
        
        modelBuilder.Entity<Musician>()
            .HasMany(left => left.Tracks)
            .WithMany(right => right.Musicians)
            .UsingEntity("MusicianTrack", typeof(Dictionary<string, object>),
                right => right.HasOne(typeof(Track)).WithMany().HasForeignKey("IdTrack"),
                left => left.HasOne(typeof(Musician)).WithMany().HasForeignKey("IdMusician"),
                join => join.ToTable("MusicianTrack")
            );


        modelBuilder.Entity("MusicianTrack").HasData(
            new {IdMusician = 1, IdTrack = 1},
            new {IdMusician = 2, IdTrack = 2}
        );
    }
}