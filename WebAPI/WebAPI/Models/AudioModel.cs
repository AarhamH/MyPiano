using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class AudioModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Created { get; set; }

        

    }
}
