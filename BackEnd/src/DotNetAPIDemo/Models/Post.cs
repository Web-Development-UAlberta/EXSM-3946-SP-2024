using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models;

[Table("post")]
public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }
    [Column("title")]
    public string Title { get; set; } = "";
    [Column("content")]
    public string Content { get; set; } = "";
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [InverseProperty(nameof(Comment.Post))]
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; }
}