using Application.Common.Abstractions;
using System.Net.Mail;
using System.Net;

namespace Infrastructure.Servicees;

public class EmailService : INotificationService
{
    // TODO:    Lots of technical debt in this service. Move to using something like
    //          FluentEmail, and use a propert email service like SendGrid.
    //          Move all the magic strings to config or secrets, and separate logic
    //          for generating email content (note this comes out of the box with
    //          FluentEmail because you can use razor templates).
    public async Task SendEmailNotification(string emailAddress, string customerRef)
    {
        // Create a new MailMessage object
        MailMessage message = new MailMessage();

        // Set the sender and recipient addresses
        message.From = new MailAddress("orders@Lasagnecommerce.com");
        message.To.Add(emailAddress);

        // Set the subject and body of the message
        message.Subject = "Order received";
        message.Body = $"Good news! Your order #{customerRef} has been received and will be on its way soon.";

        // Create a new SmtpClient object and set the SMTP server and port
        SmtpClient smtpClient = new SmtpClient("smtp.Lasagnecommerce.com", 587);

        // Set the credentials for the SMTP server (if required)
        smtpClient.Credentials = new NetworkCredential("orders", "5p4gh3tt1");

        // Send the message
        smtpClient.SendAsync(message, CancellationToken.None);
    }
}
