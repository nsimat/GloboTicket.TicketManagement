using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IOrderDataService
    {
        Task<List<OrdersForMonthListViewModel>> GetOrdersForMonth(DateTime date);
    }
}
