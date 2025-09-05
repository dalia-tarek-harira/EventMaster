using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;
using Microsoft.EntityFrameworkCore;
namespace EventMaster.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Attachment> AddAttachmentAsync(AttachmentDTO dto)
        {
            var attachment = new Attachment
            {
                EventId = dto.EventId,
                FilePath = dto.FilePath,
                FileName = dto.FileName,
                UploadedAt = DateTime.UtcNow
            };

            await _attachmentRepository.AddAsync(attachment);
            await _attachmentRepository.SaveChangesAsync();
            return attachment;
        }

        public async Task<IEnumerable<Attachment>> GetAttachmentsByEventIdAsync(int eventId)
        {
            return await _attachmentRepository.GetAttachmentsByEventIdAsync(eventId);
        }

        public async Task<Attachment?> GetAttachmentByIdAsync(int id)
        {
            return await _attachmentRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteAttachmentAsync(int id)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(id);
            if (attachment == null) return false;

            _attachmentRepository.Remove(attachment);
            await _attachmentRepository.SaveChangesAsync();

            return true;
        }
    }
}
