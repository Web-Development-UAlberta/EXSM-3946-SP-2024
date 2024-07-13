using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetAPIDemo.Models;

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
    [Display(Name = "Author")]
    public string Author { get; set; } = "";
    [Required]
    [Column("text", TypeName = "text")]
    [Display(Name = "Text")]
    public string Text { get; set; } = "";
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("post_id")]
    [Display(Name = "Post")]
    public int PostID { get; set; }

    [ForeignKey(nameof(PostID))]
    [InverseProperty(nameof(Models.Post.Comments))]
    [ValidateNever]
    [JsonIgnore]
    public virtual Post Post { get; set; }

}