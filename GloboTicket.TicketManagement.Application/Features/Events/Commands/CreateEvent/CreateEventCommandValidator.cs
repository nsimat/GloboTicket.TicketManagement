using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        public CreateEventCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now).WithMessage("{PropertyName} must be a future date.");

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand command, CancellationToken token)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(command.Name, command.Date));
        }
    }
}
