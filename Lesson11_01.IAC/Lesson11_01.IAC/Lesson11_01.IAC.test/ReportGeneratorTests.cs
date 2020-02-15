using System;
using IAC.BL;
using IAC.BL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson11_01.IAC.test
{
    [TestClass]
    public class ReportGeneratorTests
    {
        [TestMethod]
        public void GenerateReportAircraftInEuropeShouldReturnListWithReportItems()
        {
            // Assign
            ReportGenerator reportGenerator = new ReportGenerator(
                new AircraftRepository(),
                new AircraftModelRepository(),
                new CompanyRepository(),
                new CountryRepository());

            // Act
            var report = reportGenerator.GenerateReportAircraftInEurope();

            // Assert
            Assert.IsNotNull(report);
        }
    }
}
