using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IRestaurantRepository
{
    Restaurant GetRestaurantById(int restaurantId);
}