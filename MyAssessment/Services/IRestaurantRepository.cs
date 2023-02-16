using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IRestaurantRepository
{
    Restaurant GetRestaurantById(int restaurantId);
}

public class RestaurantRepository : IRestaurantRepository
{
    private readonly ApplicationDbContext _context;

    public RestaurantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Restaurant GetRestaurantById(int restaurantId)
    {
        // todo: make async
        return _context.Restaurants.Find(restaurantId) ?? throw new InvalidOperationException();
    }
} 