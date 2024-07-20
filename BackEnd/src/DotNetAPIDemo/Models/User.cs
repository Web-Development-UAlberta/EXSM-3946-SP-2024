using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotNetAPIDemo.Models;

[Table("app_user")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int ID { get; set; }
    [Required]
    [Column("email", TypeName = "varchar(255)")]
    [Display(Name = "E-Mail Address")]
    public string Email { get; set; } = "";
    [Required]
    [Column("password", TypeName = "varchar(255)")]
    [Display(Name = "Password")]
    public string Password { get; set; } = "";
    [Required]
    [MaxLength(30)]
    [Column("first_name", TypeName = "varchar(30)")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = "";
    [Required]
    [MaxLength(30)]
    [Column("last_name", TypeName = "varchar(30)")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = "";
}
