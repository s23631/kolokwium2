using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

public class Album
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAlbum { get; set; }
    [Required]
    [MaxLength(30)]
    public string AlbumName { get; set; }
    [Required]
    public DateTime PublishDate { get; set; }
    public virtual ICollection<Track> Tracks { get; set; }
    
    public int IdMusicLabel { get; set; }
    [ForeignKey("IdMusicLabel")]
    [Required]
    public MusicLabel MusicLabel { get; set; }
}