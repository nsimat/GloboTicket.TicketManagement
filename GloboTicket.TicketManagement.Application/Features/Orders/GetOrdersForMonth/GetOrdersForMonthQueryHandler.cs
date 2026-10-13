using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, List<OrdersForMonthDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersForMonthDto>> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetOrdersForMonth(request.Date);

            return _mapper.Map<List<OrdersForMonthDto>>(list);
        }
    }
}
