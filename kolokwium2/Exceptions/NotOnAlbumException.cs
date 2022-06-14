namespace kolokwium2.Exceptions;

public class NotOnAlbumException : Exception
{
    public NotOnAlbumException() : base("Track is not on album")
    {
    }
}