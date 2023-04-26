namespace LangSocials.Domain.Entities;

public class Location : Entity
{
    public required string Name { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }

    public required ICollection<SocialEvent> SocialEvents { get; set; }
}
