using AutoMapper;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // NSwag represents OpenAPI date-time values as DateTimeOffset; the existing
            // Blazor view models intentionally keep their date-only UI values as DateTime.
            CreateMap<DateTimeOffset, DateTime>().ConvertUsing(source => source.LocalDateTime);
            CreateMap<DateTime, DateTimeOffset>().ConvertUsing(source => new DateTimeOffset(source));

            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<EventListVm, EventListViewModel>().ReverseMap();
            CreateMap<EventDetailVm, EventDetailViewModel>().ReverseMap();

            CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();

            CreateMap<CategoryEventDto, EventNestedViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryEventsViewModel>().ReverseMap();
        }
    }
}
