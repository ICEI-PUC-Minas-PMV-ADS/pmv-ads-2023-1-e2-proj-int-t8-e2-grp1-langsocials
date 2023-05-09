namespace LangSocials.Domain.Entities;

public class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public bool ShowContactInfo { get; set; }
    public required ICollection<SocialEvent> Organizing { get; set; }
    public required ICollection<SocialEvent> Participating { get; set; }
    public required ICollection<LocationUser> LocationUsers { get; set; }
}
