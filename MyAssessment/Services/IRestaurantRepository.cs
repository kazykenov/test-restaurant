using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IRestaurantRepository
{
    Task<Restaurant> GetRestaurantById(int restaurantId);
}

public class RestaurantRepository : IRestaurantRepository
{
    private readonly ApplicationDbContext _context;

    public RestaurantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Restaurant> GetRestaurantById(int restaurantId)
    {
        // todo: make async
        return await _context.Restaurants.FindAsync(restaurantId) ?? throw new InvalidOperationException();
    }
} 