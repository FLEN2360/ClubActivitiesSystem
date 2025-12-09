using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("sessions")]
public class Session
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = default!;

    [Column("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [Column("token")]
    public string Token { get; set; } = default!;

    [Column("ip_address")]
    public string? IpAddress { get; set; }

    [Column("user_agent")]
    public string? UserAgent { get; set; }

    [Column("user_id")]
    public string UserId { get; set; } = default!;

    public User User { get; set; } = default!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
