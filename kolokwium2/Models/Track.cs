using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

public class Track
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTrack { get; set; }
    [Required]
    [MaxLength(20)]
    public string TrackName { get; set; }
    [Required]
    public float Duration { get; set; }
    
    public virtual ICollection<Musician> Musicians { get; set; }
    
    public int? IdMusicAlbum { get; set; }
    [ForeignKey("IdMusicAlbum")]
    public Album? Album { get; set; }
}