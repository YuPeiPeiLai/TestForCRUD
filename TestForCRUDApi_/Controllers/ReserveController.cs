using Microsoft.AspNetCore.Mvc;
using TestForCRUDApi.Model;

namespace TestForCRUDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReserveController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ReserveController> _logger;

        public ReserveController(ILogger<ReserveController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetReserve")]
        public IEnumerable<Reserve> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Reserve
            {
                ID= index,
                ReserveUserName = Summaries[Random.Shared.Next(Summaries.Length)],
                ReserveUserPhone="",
                NumberOfPeople=1,
                ReserveDate = DateTime.Now.AddDays(index)
            })
            .ToArray();
        }
    }
}
