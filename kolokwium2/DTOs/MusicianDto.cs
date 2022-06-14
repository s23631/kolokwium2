namespace kolokwium2.DTOs;

public class MusicianDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Nickname { get; set; }
    public IEnumerable<TracksDto> Tracks { get; set; }
}