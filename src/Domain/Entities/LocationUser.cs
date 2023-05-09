namespace LangSocials.Domain.Entities;

public class LocationUser : Entity
{
    public int UserId { get; set; }
    public required User User { get; set; }
    public int LocationId { get; set; }
    public required Location Location { get; set; }

}
