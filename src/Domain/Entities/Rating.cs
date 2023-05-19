namespace LangSocials.Domain.Entities;

public class Rating : Entity
{
    public int RatingValue { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int LocationId { get; set; }


    public Location Location { get; set; } = default!;
    public User User { get; set; } = default!;
}