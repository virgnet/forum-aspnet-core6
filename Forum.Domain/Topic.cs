using System.ComponentModel.DataAnnotations;

namespace Forum.Domain
{
    public class Topic
    {
        [Key]
        public Guid TopicId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        virtual public User User { get; set; }
    }
}