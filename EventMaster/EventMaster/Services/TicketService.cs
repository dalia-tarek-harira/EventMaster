using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;

namespace EventMaster.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;

        public TicketService(ITicketRepository ticketRepository, IEventRepository eventRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Ticket> CreateTicketAsync(TicketDTO ticketDto)
        {
            var evnt = await _eventRepository.GetByIdAsync(ticketDto.EventId);

            if (evnt == null || evnt.AvailableTicket <= 0)
                throw new Exception("Event not found or tickets sold out.");

            var ticket = new Ticket
            {
                EventId = ticketDto.EventId,
                ParticipantId = ticketDto.ParticipantId,
                PricePaid = ticketDto.PricePaid,
                PurchaseDate = DateTime.UtcNow
            };

            await _ticketRepository.AddAsync(ticket);

            // Decrease available tickets
            evnt.AvailableTicket -= 1;
            await _eventRepository.UpdateAsync(evnt);
            await _eventRepository.SaveChangesAsync();

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            return await _ticketRepository.GetTicketsByEventIdAsync(eventId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByParticipantIdAsync(int participantId)
        {
            var allTickets = await _ticketRepository.GetAllAsync();
            return allTickets.Where(t => t.ParticipantId == participantId);
        }
    }
}
