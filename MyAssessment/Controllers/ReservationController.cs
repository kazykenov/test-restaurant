using Microsoft.AspNetCore.Mvc;
using MyAssessment.DTOs;
using MyAssessment.Form;
using MyAssessment.Model;
using MyAssessment.Services;

namespace MyAssessment.Controllers
{
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly ILocationRepository _locationRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILocationAvailabilityService _locationAvailabilityService;
        private readonly ITableService _tableService;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger,
            ILocationRepository locationRepository, 
            IRestaurantRepository restaurantRepository,
            ILocationAvailabilityService locationAvailabilityService,
            ITableService tableService,
            IReservationService reservationService)
        {
            _logger = logger;
            _locationRepository = locationRepository;
            _restaurantRepository = restaurantRepository;
            _locationAvailabilityService = locationAvailabilityService;
            _tableService = tableService;
            _reservationService = reservationService;
        }

        [HttpPost("restaurants/{restaurantId}/locations/{locationId}/reserve")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReservationDTO>> Reserve([FromBody] ReservationForm form, int restaurantId, int locationId)
        {
            // TODO validate form and convert to the needed data type (do now allow accepting past data, validate it either here or in availabilityService)
            var datetime = DateTime.Parse(form.DateTime);

            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantId) ?? throw new Exception("Not Found"); // todo: rework exception
            var location = await _locationRepository.GetLocationById(locationId) ?? throw new Exception("Not Found");// todo: rework exception

            if (!(await _locationAvailabilityService.IsDatetimeAvailable(location, datetime)))
            {
                throw new Exception("location is not working at the given time");
            }

            var table = await _tableService.GetTableForPeople(location, form.NumberOfPeople);
            var reservation = await _reservationService.Reserve(table, datetime, form.NumberOfPeople);

            return new ReservationDTO()
            {
                ReservationId = reservation.ReservationId,
                NumberOfPeople = reservation.NumberOfPeople,
            };
        }
    }
}