using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class AudioModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

    }
}
