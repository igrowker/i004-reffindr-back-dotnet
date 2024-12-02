using MailKit.Net.Smtp;
using MimeKit;
using Reffindr.Application.Services.Interfaces;

namespace Reffindr.Application.Services.Classes
{
	public class EmailService : IEmailService
	{
		public async Task SendEmailAsync(string to, string subject, string body)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Nombre", "example@example.com"));
			message.To.Add(new MailboxAddress("Destinatario", to));
			message.Subject = subject; 
			var bodyBuilder = new BodyBuilder { HtmlBody = body };
			message.Body = bodyBuilder.ToMessageBody();
			using (var client = new SmtpClient()) 
			{ 
				await client.ConnectAsync("smtp.example.com", 587, false); 
				await client.AuthenticateAsync("tu_usuario", "tu_contraseña");
				await client.SendAsync(message); await client.DisconnectAsync(true); 
			}
		}
	}
}
