using System.ComponentModel.DataAnnotations;

namespace ImgPOC.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photographer { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
