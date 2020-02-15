using System;
using System.Collections.Generic;
using System.Text;
using IAC.BL.Repositories;

namespace IAC.BL
{
    public class ReportGenerator
    {
        private AircraftRepository _aircraftRepository;
        private AircraftModelRepository _aircraftModelRepository;
        private CompanyRepository _companyRepository;
        private CountryRepository _countryRepository;

        public ReportGenerator(
            AircraftRepository aircraftRepository,
            AircraftModelRepository aircraftModelRepository,
            CompanyRepository companyRepository,
            CountryRepository countryRepository)
        {
            _aircraftRepository = aircraftRepository;
            _aircraftModelRepository = aircraftModelRepository;
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
        }

        public List<ReportItem> GenerateReportAircraftInEurope()
        {
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var aircraft in _aircraftRepository.Retrieve())
            {
                Company company = _companyRepository.Retrieve(aircraft.CompanyId);
                Country country = _countryRepository.Retrieve(company.CountryId);
                AircraftModel aircraftModel = _aircraftModelRepository.Retrieve(aircraft.ModelId);

                if(country.Continent == "Europe")
                {
                    ReportItem reportItem = new ReportItem();

                    CreateRaportItem(aircraft, company, country, aircraftModel, reportItem);

                    reportItems.Add(reportItem);
                }
            }

            return reportItems;
        }

        private static void CreateRaportItem(Aircraft aircraft, Company company, Country country, AircraftModel aircraftModel, ReportItem reportItem)
        {
            reportItem.AircraftTailNumber = aircraft.TailNumber;
            reportItem.ModelNumber = aircraftModel.Number;
            reportItem.ModelDescription = aircraftModel.Description;
            reportItem.OwnerCompanyName = company.Name;
            reportItem.CompanyCountryCode = country.Code;
            reportItem.CompanyCountryName = country.Name;
            reportItem.BelongsToEU = country.BelongsToEU;
        }
    }
}
