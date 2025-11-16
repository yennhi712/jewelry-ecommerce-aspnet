using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using SportsStore.Models;

namespace SportsStore.Pages.Customer
{
    [Authorize]
    public class MyOrdersModel : PageModel
    {
        private readonly IOrderRepository _repository;

        public List<Order> CustomerOrders { get; set; } = new();

        public MyOrdersModel(IOrderRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            var userEmail = User.FindFirst("email")?.Value
                ?? User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
                ?? User.Identity?.Name;

            if (!string.IsNullOrEmpty(userEmail))
            {
                CustomerOrders = _repository.Orders
                    .Where(o => o.Email == userEmail)
                    .OrderByDescending(o => o.CreatedDate)
                    .ToList();
            }
        }
    }
}
