using System.ComponentModel.DataAnnotations;

namespace ClubActivitiesSystem.Models.ViewModel
{
    public class GuestRegistrationViewModel
    {
        [Required]
        public int EventId { get; set; }

        [Display(Name = "姓名")]
        [StringLength(200)]
        public string? Name { get; set; }

        [Display(Name = "電子郵件")]
        [EmailAddress]
        [StringLength(200)]
        public string? Email { get; set; }

        [Display(Name = "電話")]
        [Phone]
        [StringLength(50)]
        public string? Phone { get; set; }
    }
}