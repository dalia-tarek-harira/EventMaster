using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Services
{
    public interface ITicketService
    {

        Task<Ticket> CreateTicketAsync(TicketDTO ticketDto);
        Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId);
        Task<IEnumerable<Ticket>> GetTicketsByParticipantIdAsync(int participantId);
    }
}
