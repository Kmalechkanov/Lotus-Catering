namespace AnisMasterpieces.Services.Messaging
{
    public class EmailAttachment
    {
        public byte[] Context { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }
    }
}