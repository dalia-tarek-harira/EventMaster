using EventMaster.DTOs;
using EventMaster.Models; 
namespace EventMaster.Services
{
    public interface IAttachmentService
    {
        Task<Attachment> AddAttachmentAsync(AttachmentDTO dto);
        Task<IEnumerable<Attachment>> GetAttachmentsByEventIdAsync(int eventId);
        Task<Attachment?> GetAttachmentByIdAsync(int id);
        Task<bool> DeleteAttachmentAsync(int id);
    }
}
