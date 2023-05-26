namespace LangSocials.Domain.Entities;

public class Location : Entity
{
    public required string Name { get; set; }
    public required string Street { get; set; }
    public required string PostalCode { get; set; }
    public required string Neighborhood { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Number { get; set; }
    public string Complement { get; set; } = string.Empty;

    public ICollection<SocialEvent> SocialEvents { get; set; } = new List<SocialEvent>();
    public LocationClaim? Claim { get; set; }

}
