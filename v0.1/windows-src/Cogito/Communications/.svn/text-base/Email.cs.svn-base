using System;
using System.Net;
using System.Net.Mail;

namespace CogitoProject.Communication
{
    /**
     * Emailer makes it possible to send emails using the Cogito Project.  GMail
     * credentials must be used, but other accounts are hoped to be supported soon.
     * 
     * @author Brent Strysko
     * @date 2/16/10
     */
    public class Emailer
    {
        /**
         * The client used to send the email.
         */
        private SmtpClient _client;

        /**
         * Instantiates the Emailer class with the sender credentials.
         * 
         * @param username the sending party's gmail username
         * @param password the sending party's gmail password
         */
        public Emailer(String username, String password)
        {
            this._client = new SmtpClient("smtp.gmail.com", 587);
            this._client.EnableSsl = true;
            this._client.Credentials = new NetworkCredential(username,password);
        }

        /**
         * Sends an email with no attachments.
         * 
         * @param to the receiving party's email
         * @param subject subject of the email
         * @param body body of the email
         * 
         * @return true if email sent sucessfully
         */
        public bool sendEmail(String to, String subject, String body)
        {
            return sendEmail(to, subject, body, new String[] { "" });
        }

        /**
         * Sends an email with no attachments.
         * 
         * @param to the receiving party's email
         * @param subject subject of the email
         * @param body body of the email
         * @param format text or html
         * @param attachmentPath an array of attachment paths to attach to the email
         * 
         * @return true if email sent sucessfully
         */
        public bool sendEmail(String to, String subject, String body,String[] attachmentPath)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("");
                message.Subject = subject;

                message.Body = body;

                foreach(String e in attachmentPath)
                {
                    message.Attachments.Add(new Attachment(e));
                }

                message.To.Add(new MailAddress(to));
                _client.Send(message);
                
                return true;
            }
        }
    }
}
