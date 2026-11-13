using AutoMapper;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Services
{
    public class EventDataService(IClient client, IMapper mapper) : IEventDataService
    {
        public async Task<List<EventListViewModel>> GetAllEvents()
        {
            var events = await client.GetAllEventsAsync();
            return mapper.Map<List<EventListViewModel>>(events);
        }

        public async Task<EventDetailViewModel> GetEventById(Guid id)
        {
            var selectedEvent = await client.GetEventByIdAsync(id);
            return mapper.Map<EventDetailViewModel>(selectedEvent);
        }

        public async Task<Guid> CreateEvent(EventDetailViewModel eventDetailViewModel)
        {
            var command = mapper.Map<CreateEventCommand>(eventDetailViewModel);
            return await client.AddEventAsync(command);
        }

        public async Task UpdateEvent(EventDetailViewModel eventDetailViewModel)
        {
            var command = mapper.Map<UpdateEventCommand>(eventDetailViewModel);
            await client.UpdateEventAsync(command);
        }

        public async Task DeleteEvent(Guid id)
        {
            await client.DeleteEventAsync(id);
        }
    }
}
