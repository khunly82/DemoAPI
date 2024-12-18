using CorrectionLabo.Domain.Entities;

namespace CorrectionLabo.Application.Abstractions.Repositories
{
    public interface IMemberRepository
    {
        Task Add(Member member);
        Task<bool> Any(string? username, string? email);
        Task<bool> ExistMemberWithEmailOrUsername(string email, string username);
    }
}
