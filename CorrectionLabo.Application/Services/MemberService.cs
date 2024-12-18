using CorrectionLabo.Application.Abstractions.Mail;
using CorrectionLabo.Application.Abstractions.Repositories;
using CorrectionLabo.Application.Abstractions.Services;
using CorrectionLabo.Application.Utils;
using CorrectionLabo.Domain.Entities;
using System.Security.Cryptography;
using System.Transactions;

namespace CorrectionLabo.Application.Services
{
    public class MemberService(IMemberRepository memberRepository, IMailer mailer) : IMemberService
    {
        public async Task AddMember(Member member, int? elo)
        {
            if (await memberRepository.ExistMemberWithEmailOrUsername(member.Email, member.Username))
            {
                throw new Exception("Le membre existe déjà");
            }
            string plainPassword = PasswordUtils.CreatePassword();
            byte[] hashedPassword = PasswordUtils.HashPassword(plainPassword, member.Username);
            member.Password = hashedPassword;
            member.ELO = elo ?? 1200;

            //TransactionScope scope = new TransactionScope();
            
            await memberRepository.Add(member);
            await mailer.SendAsync(member.Email, "Inscription OK", $"Votre mot de passe = {plainPassword}");

            //scope.Complete();

        }

        public async Task<bool> Exist(string? username, string? email)
        {
            return await memberRepository.Any(username, email);
        }
    }
}
