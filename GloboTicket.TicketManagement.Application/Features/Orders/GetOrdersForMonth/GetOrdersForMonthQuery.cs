using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<List<OrdersForMonthDto>>
    {
        public DateTime Date { get; set; }
    }
}
