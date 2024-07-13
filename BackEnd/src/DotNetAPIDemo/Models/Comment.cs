using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetAPIDemo.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("author", TypeName = "varchar(30)")]
        public string Author { get; set; } = "";

        [Required]
        [Column("text", TypeName = "text")]
        public string Text { get; set; } = "";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("post_id")]
        public int PostID { get; set; }

        [ForeignKey(nameof(PostID))]
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}