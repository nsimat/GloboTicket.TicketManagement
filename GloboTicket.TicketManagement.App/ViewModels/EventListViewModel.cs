namespace GloboTicket.TicketManagement.App.ViewModels
{
    /// <summary>
    /// Represents an event in a list.
    /// </summary>
    public class EventListViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
    }
}
