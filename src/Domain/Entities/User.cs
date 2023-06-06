namespace LangSocials.Domain.Entities;

public class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string ImageURI { get; set; } = string.Empty;
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public bool ShowContactInfo { get; set; }
    public string? Description { get; set; }
    public ICollection<SocialEvent> Organizing { get; set; } = new List<SocialEvent>();
    public ICollection<SocialEvent> Participating { get; set; } = new List<SocialEvent>();
    public ICollection<Location> Locations { get; set; } = new List<Location>();
}
