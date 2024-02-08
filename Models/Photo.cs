namespace ImgPOC.Models
{
    public class Photo
    {
        public int id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string photographer { get; set; }
        public string photographer_url { get; set; }
        public int photographer_id { get; set; }
        public string avg_color { get; set; }
        public Src src { get; set; } = new Src();
        public bool liked { get; set; }
        public string alt { get; set; }
    }
}
