
using simo2api.Helpers;
using System.Threading.Tasks;
namespace simo2api.Services
{
    public interface IMailService
    {
        void SendEmailAsync(MailRequest mailRequest);

    }
}