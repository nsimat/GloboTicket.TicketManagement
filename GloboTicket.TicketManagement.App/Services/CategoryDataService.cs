using AutoMapper;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Services
{
    public class CategoryDataService(IClient client, IMapper mapper) : ICategoryDataService
    {
        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var categories = await client.GetAllCategoriesAsync();
            return mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory)
        {
            var categories = await client.GetCategoriesWithEventsAsync(includeHistory);
            return mapper.Map<List<CategoryEventsViewModel>>(categories);
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryViewModel)
        {
            var command = mapper.Map<CreateCategoryCommand>(categoryViewModel);
            var category = await client.AddCategoryAsync(command);
            return mapper.Map<CategoryViewModel>(category);
        }
    }
}
