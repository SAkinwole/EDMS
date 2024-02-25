namespace EDMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        //public IFormFile FileImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string FileUrl { get; set; }
    }
}
