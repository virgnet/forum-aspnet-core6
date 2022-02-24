using System.ComponentModel.DataAnnotations;

namespace Forum.Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        virtual public List<Topic> Topics { get; set; }
    }
}
