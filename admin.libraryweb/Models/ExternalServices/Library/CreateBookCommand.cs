namespace admin.libraryweb.Models.ExternalServices.Library
{
    public class CreateBookCommand
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Authors { get; set; }
        public string Isdn { get; set; }
        public string FileBase64 { get; set; }
    }
}
