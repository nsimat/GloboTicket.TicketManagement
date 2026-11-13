using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IEventDataService
    {
        Task<List<EventListViewModel>> GetAllEvents();
        Task<EventDetailViewModel> GetEventById(Guid id);
        Task<Guid> CreateEvent(EventDetailViewModel eventDetailViewModel);
        Task UpdateEvent(EventDetailViewModel eventDetailViewModel);
        Task DeleteEvent(Guid id);
    }
}
