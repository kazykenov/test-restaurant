using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ILocationRepository
{
    Location GetLocationById(int locationId);
}