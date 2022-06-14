using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

public class MusicLabel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMusicLabel { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public virtual ICollection<Album> Albums { get; set; }
}