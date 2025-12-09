using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = default!;

    [Column("name")]
    public string Name { get; set; } = default!;

    [Column("email")]
    public string Email { get; set; } = default!;

    [Column("email_verified")]
    public bool EmailVerified { get; set; } = false;

    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("username")]
    public string? Username { get; set; }

    [Column("display_username")]
    public string? DisplayUsername { get; set; }

    [Column("role")]
    public string Role { get; set; } = default!;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = default!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
