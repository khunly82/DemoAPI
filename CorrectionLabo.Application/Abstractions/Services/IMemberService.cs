using CorrectionLabo.Domain.Entities;

namespace CorrectionLabo.Application.Abstractions.Services
{
    public interface IMemberService
    {
        Task AddMember(Member member, int? elo);
        Task<bool> Exist(string? username, string? email);
    }
}