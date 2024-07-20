using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetAPIDemo.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; } = "";

        [Required]
        [Column("content", TypeName = "text")]
        public string Content { get; set; } = "";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}