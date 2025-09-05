using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Services
{
    public interface IEventService
    {
        Task<Event> CreateEventAsync(EventDTO dto);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetEventsByOrganizerAsync(int organizerId);
        Task<Event> GetEventByIdAsync(int id);
        Task<Event> UpdateEventAsync(int id, EventDTO dto);
        Task<bool> DeleteEventAsync(int id);
    }
}
