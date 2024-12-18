using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionLabo.Application.Abstractions.Mail
{
    public interface IMailer
    {
        Task<bool> SendAsync(string dest, string subject, string body);
    }
}
