using Application.UseCases.LocationCases.GetLocationByName;
using LangSocials.Domain.Entities;
using LangSocials.Infraesctructure.LangSocialsDb;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Shared;

namespace Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly LangSocialsDbContext context;
        private readonly ILogger<WeatherForecastController> logger;
        private readonly ISender sender;

        public WeatherForecastController(LangSocialsDbContext context, ILogger<WeatherForecastController> logger, ISender sender)
        {
            this.context = context;
            this.logger = logger;
            this.sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                Name = $"Nome {DateTime.Now}",
                PasswordHash = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                PasswordSalt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                ShowContactInfo = true,
                Organizing = new List<SocialEvent>(),
                Participating = new List<SocialEvent>()
            };

            await context.AddAsync(user, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var location = new Location
            {
                PlaceId = "ChIJo4B945KzGgcRRZsrhf97Xhc",
                Name = "Escariz Jorge amado",
                SocialEvents = new List<SocialEvent> { }
            };

            await context.AddAsync(location, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var socialEvent = new SocialEvent
            {
                BeginsAt = DateTime.Now.AddMinutes(1),
                EndsAt = DateTime.Now.AddDays(2),
                Location = location,
                Organizer = user,
                Name = "Encontro com Ed",
                Participants = new List<User>()
            };

            await context.AddAsync(socialEvent, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var response = await sender.Send(new SearchLocationRequest("Shopping Parque"), cancellationToken);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}