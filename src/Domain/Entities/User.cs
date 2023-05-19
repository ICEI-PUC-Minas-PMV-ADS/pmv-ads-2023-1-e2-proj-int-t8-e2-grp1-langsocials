namespace LangSocials.Domain.Entities;

public class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public bool ShowContactInfo { get; set; }
    public string? Description { get; set; }
    public ICollection<SocialEvent> Organizing { get; set; } = new List<SocialEvent>();
    public ICollection<SocialEvent> Participating { get; set; } = new List<SocialEvent>();
    public ICollection<LocationClaim> LocationClaims { get; set; } = new List<LocationClaim>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
