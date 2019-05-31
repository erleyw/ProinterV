using ProinterV.CrossCutting.Identity.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ProinterV.CrossCutting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme seu email",
                $"Por favor confirme sua conta clicando <a href='{HtmlEncoder.Default.Encode(link)}'>nesse link</a>");
        }
    }
}
