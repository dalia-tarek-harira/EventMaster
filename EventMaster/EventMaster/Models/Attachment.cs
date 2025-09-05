namespace EventMaster.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public int EventId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedAt { get; set; }

        public Event Event { get; set; }

    }
}
