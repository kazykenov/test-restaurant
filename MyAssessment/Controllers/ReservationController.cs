using Microsoft.AspNetCore.Mvc;
using MyAssessment.Data;
using MyAssessment.Model;
using MyAssessment.Form;
using MyAssessment.Services;

namespace MyAssessment.Controllers
{
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ILocationRepository _locationRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILocationAvailabilityService _locationAvailabilityService;

        public ReservationController(ILogger<WeatherForecastController> logger, 
            ApplicationDbContext context, 
            ILocationRepository locationRepository, 
            IRestaurantRepository restaurantRepository,
            ILocationAvailabilityService locationAvailabilityService)
        {
            _logger = logger;
            _context = context;
            _locationRepository = locationRepository;
            _restaurantRepository = restaurantRepository;
            _locationAvailabilityService = locationAvailabilityService;
        }

        [HttpGet("restaurants/{restaurantId}/locations/{locationId}")]
        public async Task<IEnumerable<Table>> Get(int restaurantId, int locationId, string date, int time)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            var location = await _context.Locations.FindAsync(locationId);

            if (restaurant == null)
            {
                throw new Exception("Not found");
            }

            return Enumerable.Range(1, 5).Select(index => new Table
            {
                TableId = restaurantId,
            })
            .ToArray();
        }

        [HttpPost("restaurants/{restaurantId}/locations/{locationId}/reserve")]
        public async Task Reserve([FromBody] ReservationForm form, int restaurantId, int locationId)
        {
            // var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            // var location = await _context.Locations.FindAsync(locationId);
            var restaurant = _restaurantRepository.GetRestaurantById(restaurantId);
            var location = _locationRepository.GetLocationById(locationId);

            // if (_locationAvailabilityService.IsDatetimeAvailable(location, form.DateTime))
            // {
            //     throw new Exception("invalid datetime");
            // }

            if (restaurant == null)
            {
                throw new Exception("Not found");
            }

            // return Enumerable.Range(1, 5).Select(index => new Table
            // {
            //     TableId = restaurantId,
            // })
            // .ToArray();
        }
    }
}