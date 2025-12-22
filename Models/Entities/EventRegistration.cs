using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubActivitiesSystem.Models.Entities
{
    [Table("event_registrations")]
    public class EventRegistration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("event_id")]
        public int EventId { get; set; }

        public Event Event { get; set; } = default!;

        // 允許為 null（訪客報名）
        [Column("user_id")]
        public string? UserId { get; set; }

        public User? User { get; set; }

        [Column("registered_at")]
        public DateTime RegisteredAt { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Pending";

        [Column("payment_status")]
        public string PaymentStatus { get; set; } = "Unpaid";

        // 訪客欄位
        [Column("guest_name")]
        [StringLength(200)]
        public string? GuestName { get; set; }

        [Column("guest_email")]
        [StringLength(200)]
        public string? GuestEmail { get; set; }

        [Column("guest_phone")]
        [StringLength(50)]
        public string? GuestPhone { get; set; }
    }

}
