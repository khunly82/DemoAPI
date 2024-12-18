using CorrectionLabo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CorrectionLabo.DTO.MemberDTOS
{
    public class RegisterMemberFormDTO
    {
        [MaxLength(255)]
        public string Username { get; set; } = null!;

        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        [Range(0,3000)]
        public int? ELO { get; set; }
    }
}
