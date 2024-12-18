using CorrectionLabo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CorrectionLabo.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Email { get; set; } = null!;
        [MaxLength(255)]
        public string Username { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public DateTime Birhtdate { get; set; }
        public Gender Gender { get; set; }
        [Range(0,3000)]
        public int ELO { get; set; }
        public bool IsAdmin { get; set; }
    }
}
