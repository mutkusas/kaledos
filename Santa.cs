using System;
using System.Net;
using System.Net.Mail;

namespace SecretSanta
{
    class Santa
    {
        public String name;
        public String email;
        public Santa asignee;

        public Santa (String vardas, String pastas)
        {
            Random rnd = new Random();
            name = vardas;
            email = pastas;
        }

        public String toString()
        {
            return name + "ištraukė" + asignee.name;
        }

        public void sendMail()
        {

            var fromAddress = new MailAddress("slaptosdovanos@gmail.com", "Kalėdų Senelis");
            var toAddress = new MailAddress(email);
            const string fromPassword = "slaptazodis";
            const string subject = "Kalėdos";
            string body = "Tu esi slaptas Kalėdų Senelis žmogaus, kurio vardas yra " + asignee.name ;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
    }
}
