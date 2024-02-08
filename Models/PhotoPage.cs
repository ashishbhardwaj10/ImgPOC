namespace ImgPOC.Models
{
    public class PhotoPage
    {
        public int total_results { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public List<Photo> photos { get; set; } = new List<Photo>();
        public string next_page { get; set; }
        public string prev_page { get; set; }
    }
}
