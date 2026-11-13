using AutoMapper;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Services.Base
{
    public class OrderDataService(IClient client, IMapper mapper) : IOrderDataService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IClient _client = client;

        public async Task<List<OrdersForMonthListViewModel>> GetOrdersForMonth(DateTime date)
        {
            var orders = await client.GetOrdersForMonthAsync(new DateTimeOffset(date));
            return mapper.Map<List<OrdersForMonthListViewModel>>(orders);
        }
    }
}
