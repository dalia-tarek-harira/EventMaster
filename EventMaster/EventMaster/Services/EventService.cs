using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories;
using EventMaster.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace EventMaster.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public EventService(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        public async Task<Event> CreateEventAsync(EventDTO dto)
        {
            var organizer = await _userRepository.GetByIdAsync(dto.OrganizerId);
            if (organizer == null)
                throw new Exception("Organizer not found.");

            var newEvent = new Event
            {
                OrganizerId = dto.OrganizerId,
                CategoryId = dto.CategoryId,
                Title = dto.Title,
                Description = dto.Description,
                Venue = dto.Venue,
                EventDate = dto.EventDate,
                TicketPrice = dto.TicketPrice,
                TotalTickets = dto.TotalTickets,
                AvailableTicket = dto.TotalTickets,
                IsApproved = false // default
            };

            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveChangesAsync();
            return newEvent;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            return await _eventRepository.GetUpcomingEventsAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByOrganizerAsync(int organizerId)
        {
            return await _eventRepository.GetEventsByOrganizerAsync(organizerId);
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
        }

        public async Task<Event?> UpdateEventAsync(int id, EventDTO dto)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(id);
            if (existingEvent == null) return null;

            existingEvent.Title = dto.Title;
            existingEvent.Description = dto.Description;
            existingEvent.Venue = dto.Venue;
            existingEvent.EventDate = dto.EventDate;
            existingEvent.TicketPrice = dto.TicketPrice;

            // update total tickets but keep available tickets in sync
            int oldTotal = existingEvent.TotalTickets;
            int oldAvailable = existingEvent.AvailableTicket;

            existingEvent.TotalTickets = dto.TotalTickets;

            // adjust available tickets relative to the change
            int soldTickets = oldTotal - oldAvailable;
            existingEvent.AvailableTicket = Math.Max(0, dto.TotalTickets - soldTickets);

            await _eventRepository.UpdateAsync(existingEvent);
            await _eventRepository.SaveChangesAsync();
            return existingEvent;
        }


        public async Task<bool> DeleteEventAsync(int id)
        {
            var ev = await _eventRepository.GetByIdAsync(id);
            if (ev == null) return false;

            _eventRepository.Remove(ev);
            await _eventRepository.SaveChangesAsync();
            return true;
        }
    }
}
