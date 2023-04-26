namespace LangSocials.Domain.Entities;

public class SocialEvent : Entity
{
    public required string Name { get; set; }
    public required DateTime BeginsAt { get; set; }
    public required DateTime EndsAt { get; set; }
    public string? Description { get; set; }
    public required Location Location { get; set; }
    public required User Organizer { get; set; }
    public required ICollection<User> Participants { get; set; }
}
