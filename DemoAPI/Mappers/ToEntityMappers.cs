using CorrectionLabo.Domain.Entities;
using CorrectionLabo.DTO.MemberDTOS;

namespace CorrectionLabo.Mappers
{
    public static class ToEntityMappers
    {
        public static Member ToEntity(this RegisterMemberFormDTO dto)
        {
            return new Member
            {
                Username = dto.Username,
                Email = dto.Email,
                Birhtdate = dto.BirthDate,
                Gender = dto.Gender,
            };
        }
    }
}
