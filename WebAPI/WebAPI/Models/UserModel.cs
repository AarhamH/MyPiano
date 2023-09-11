using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]public string Password { get; set; }
    }
}
