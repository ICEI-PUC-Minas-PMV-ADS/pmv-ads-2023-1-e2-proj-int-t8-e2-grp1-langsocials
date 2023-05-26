namespace LangSocials.Domain.Entities;

public class Rating : Entity
{
    public required int RatingValue { get; set; }
    public required string Comment { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}