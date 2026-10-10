using System;
using System.Collections.Generic;
using System.Text;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetOrdersForTaskMonth(DateTime date)
        {
            return await _dbContext.Orders
                .Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
