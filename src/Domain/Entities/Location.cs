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
    public string? Description { get; set; }
    public decimal ConsumptionRequiredValue { get; set; }
    public int MaximumAmountPeople { get; set; }
    public string Complement { get; set; } = string.Empty;
    public ICollection<SocialEvent> SocialEvents { get; set; } = new List<SocialEvent>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    /// <summary>
    /// Value stored in the database instead of being evaluated every time its read.
    /// This approach should be fine as long as there are no concurrent writes/reads.
    /// </summary>
    public int RatingAvarage { get; set; }
    /// <summary>
    /// This is used to avoid enumerating over every rating.
    /// </summary>
    public int RatingCounter { get; set; } = 0;
    public int OwnerId { get; set; }
    public User? Owner { get; set; }

    public void AddNewRating(Rating rating)
    {
        Ratings.Add(rating);
        RatingAvarage = ((RatingAvarage * RatingCounter) + rating.RatingValue) / (++RatingCounter);
    }
}
