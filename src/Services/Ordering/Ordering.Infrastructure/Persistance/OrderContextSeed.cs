using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                var orders = GetPreconfiguredOrders();
                orderContext.Orders.AddRange(orders);
                await orderContext.SaveChangesAsync();

                logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() 
                {
                    UserName = "swn", 
                    FirstName = "Mehmet", 
                    LastName = "Ozkaya", 
                    EmailAddress = "filipeqs@outlook.com", 
                    AddressLine = "Bahcelievler", 
                    Country = "Turkey", 
                    TotalPrice = 350 
                }
            };
        }
    }
}
