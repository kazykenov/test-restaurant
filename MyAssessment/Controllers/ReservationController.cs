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
        private readonly ITableService _tableService;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<WeatherForecastController> logger, 
            ApplicationDbContext context, 
            ILocationRepository locationRepository, 
            IRestaurantRepository restaurantRepository,
            ILocationAvailabilityService locationAvailabilityService,
            ITableService tableService,
            IReservationService reservationService)
        {
            _logger = logger;
            _context = context;
            _locationRepository = locationRepository;
            _restaurantRepository = restaurantRepository;
            _locationAvailabilityService = locationAvailabilityService;
            _tableService = tableService;
            _reservationService = reservationService;
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
            // TODO validate form and convert to the needed data type (do now allow accepting past data, validate it either here or in availabilityService)
            var datetime = DateTime.Parse(form.DateTime);

            var restaurant = _restaurantRepository.GetRestaurantById(restaurantId) ?? throw new Exception("Not Found"); // todo: rework exception
            var location = _locationRepository.GetLocationById(locationId) ?? throw new Exception("Not Found");// todo: rework exception

            if (!_locationAvailabilityService.IsDatetimeAvailable(location, datetime))
            {
                throw new Exception("location is not working at the given time");
            }

            var table = _tableService.GetTableForPeople(location, form.NumberOfPeople);
            var reservation = _reservationService.Reserve(table, datetime, form.NumberOfPeople);

            return;
        }
    }
}