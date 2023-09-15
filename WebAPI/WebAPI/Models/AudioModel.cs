using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class AudioModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public UserModel? UserModel { get; set; }
    }
}   
