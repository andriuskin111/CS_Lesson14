using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using IAC.BL;
using IAC.BL.Repositories;

namespace AirportIAC
{
    class Program
    {
        public static NetworkCredential Credentials { get; private set; }
        public static bool EnableSsl { get; private set; }

        static void Main(string[] args)
        {
            ReportGenerator reportGenerator = new ReportGenerator(
               new AircraftRepository(),
               new AircraftModelRepository(),
               new CompanyRepository(),
               new CountryRepository());

            HTMLFormatter hTMLFormatter =  new HTMLFormatter();

            string report = hTMLFormatter.FormatHTML(reportGenerator.GenerateReportAircraftInEurope());

            //Console.WriteLine(report);

            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("740fca1e4b51f5", "a6e511b6f5b235"),
                EnableSsl = true
            };

            var msg = new MailMessage(
                "from@gmail.com",
                "to@gmail.com",
                "HTML Report",
                report);

            msg.IsBodyHtml = true;

            client.Send(msg);

            Console.WriteLine("send");

            //foreach (var item in reportGenerator.GenerateReportAircraftInEurope())
            //{
            //    Console.WriteLine(
            //        $"{item.AircraftTailNumber}" +
            //        $", {item.ModelNumber}" +
            //        $", {item.ModelDescription}" +
            //        $", {item.OwnerCompanyName}" +
            //        $", {item.CompanyCountryCode}" +
            //        $", {item.CompanyCountryName}" +
            //        $", {item.BelongsToEU}");
            //}
            
            Console.ReadLine();
        }
    }
}
