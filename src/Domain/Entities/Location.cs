namespace LangSocials.Domain.Entities;

public class Location : Entity
{
    public required string Name { get; set; }
    public required string PlaceId { get; set; }
    public required ICollection<SocialEvent> SocialEvents { get; set; }
}
