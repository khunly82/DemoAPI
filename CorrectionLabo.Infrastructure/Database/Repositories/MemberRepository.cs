using CorrectionLabo.Application.Abstractions.Repositories;
using CorrectionLabo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorrectionLabo.Infrastructure.Database.Repositories
{
    public class MemberRepository(ChessContext context) : IMemberRepository
    {

        public async Task Add(Member member)
        {
            await context.Members.AddAsync(member);
            await context.SaveChangesAsync();
        }

        public Task<bool> Any(string? username, string? email)
        {
            return context.Members.AnyAsync(m => (
                username == null || EF.Functions.Like(m.Username, username)
            ) && (
                email == null || EF.Functions.Like(m.Email, email)
            ));
        }

        public async Task<bool> ExistMemberWithEmailOrUsername(string email, string username)
        {
            return await context.Members.AnyAsync(m => 
                EF.Functions.Like(m.Email,email) || EF.Functions.Like(m.Username, username));
        }
    }
}
