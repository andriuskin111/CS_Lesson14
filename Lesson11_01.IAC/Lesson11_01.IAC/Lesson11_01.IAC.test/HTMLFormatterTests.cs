using System;
using System.Collections.Generic;
using System.IO;
using IAC;
using IAC.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson11_01.IAC.test
{
    [TestClass]
    public class HTMLFormatterTests
    {
        [TestMethod]
        public void FormatHTMLShouldMakeHTMLPage()
        {
            // Assign
            HTMLFormatter hTMLFormatter = new HTMLFormatter();

            // Act
            string htmlPage = hTMLFormatter.FormatHTML(ReportMoc());

            // Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(htmlPage));            
        }

        private void SaveOutputToDesktop(string page, string fileName)
        {
            string fileNameWithPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            File.WriteAllText(fileNameWithPath, page);
        }

        private List<ReportItem> ReportMoc()
        {
            return new List<ReportItem>()
            {
                new ReportItem()
                {
                    AircraftTailNumber = "111",
                    ModelNumber = "Boeing 737",
                    ModelDescription = "@@@",
                    OwnerCompanyName = "AirLita",
                    CompanyCountryCode = "LT",
                    CompanyCountryName = "Lithuania",
                    BelongsToEU = true
                },
                new ReportItem()
                {
                    AircraftTailNumber = "222",
                    ModelNumber = "AirBus A330",
                    ModelDescription = "###",
                    OwnerCompanyName = "BelLot",
                    CompanyCountryCode = "BY",
                    CompanyCountryName = "Belarus",
                    BelongsToEU = false
                }
            };
        }
    }
}
