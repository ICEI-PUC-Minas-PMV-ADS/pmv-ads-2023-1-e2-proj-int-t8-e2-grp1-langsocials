namespace LangSocials.Domain.Entities;

public class Location : Entity
{
    public required string Name { get; set; }
    public required string PlaceId { get; set; }
    public double Avarege { get; set; }
    public int Voters { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public ICollection<SocialEvent> SocialEvents { get; set; } = default!;
    public ICollection<Rating> Ratings { get; set; } = default!;
    public LocationClaim? Claim { get; set; }

}
