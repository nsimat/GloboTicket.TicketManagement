using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
