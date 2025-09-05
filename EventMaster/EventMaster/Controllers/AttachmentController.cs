using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        // POST: api/attachments
        /*[HttpPost]
        public async Task<IActionResult> AddAttachment([FromBody] AttachmentDTO dto)
        {
            var attachment = await _attachmentService.AddAttachmentAsync(dto);
            return CreatedAtAction(nameof(GetAttachmentById), new { id = attachment.AttachmentId }, attachment);
        }*/
         [HttpPost]
         [ProducesResponseType(typeof(AttachmentDTO), StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<IActionResult> AddAttachment([FromBody] AttachmentDTO dto)
         {
             var attachment = await _attachmentService.AddAttachmentAsync(dto);
             if (attachment == null)
                 return BadRequest("Could not create attachment");


             return CreatedAtAction(nameof(GetAttachmentById), new { id = attachment.AttachmentId }, attachment);
         }




        // GET: api/attachments/event/5
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetAttachmentsByEvent(int eventId)
        {
            var attachments = await _attachmentService.GetAttachmentsByEventIdAsync(eventId);
            return Ok(attachments);
        }

        // GET: api/attachments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttachmentById(int id)
        {
            var attachment = await _attachmentService.GetAttachmentByIdAsync(id);
            if (attachment == null) return NotFound();

            return Ok(attachment);
        }

        // DELETE: api/attachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            var result = await _attachmentService.DeleteAttachmentAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
