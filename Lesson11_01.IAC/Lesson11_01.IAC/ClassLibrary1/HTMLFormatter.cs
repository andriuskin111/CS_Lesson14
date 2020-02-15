using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL
{
    public class HTMLFormatter
    {
        private string _pageTemplate = 
@" 
<html>
  <head>
    <style>
      table, th, td {
        border: 1px solid black;
        border-collapse: collapse;
        padding: 5px;
        }
    </style>
  </head>
  <body>
    {0}
  </body>
</html>
";

        private string _tableTemplate =
@"
<table>
  <caption>{0}</caption>
  <tr>
    <th>Tail number</th>
    <th>Model number</th>
    <th>Model description</th>
    <th>Owner company name</th>
    <th>Company country code</th>
    <th>Company country name</th>
  </tr>
  {1}
</table>
";
        private string _rowTemplate =
@"
<tr style='background-color:{6}'>
  <td>{0}</td>
  <td>{1}</td>
  <td>{2}</td>
  <td>{3}</td>
  <td>{4}</td>
  <td>{5}</td>  
</tr>
";

        public string FormatHTML(List<ReportItem> ataskaitosEilutes)
        {
            string lentelesEilutes = MakeTableRows(ataskaitosEilutes);
            string lentele = MakeTable(lentelesEilutes);
            string puslapis = MakePage(lentele);

            return puslapis;
        }

        private string MakePage(string lentele)
        {
            return _pageTemplate.Replace("{0}", lentele);
        }

        private string MakeTable(string lentelesEilutes)
        {
            return string.Format(
                _tableTemplate,
                "Aircrafts from Europe",
                lentelesEilutes);
        }

        private string MakeTableRows(List<ReportItem> ataskaita)
        {
            string lentelesEilutes = "";
            foreach (var eilute in ataskaita)
            {
                string color = GetLineColor(eilute);
                string lentelesEilute = string.Format(
                    _rowTemplate,
                    eilute.AircraftTailNumber,
                    eilute.ModelNumber,
                    eilute.ModelDescription,
                    eilute.OwnerCompanyName,
                    eilute.CompanyCountryCode,
                    eilute.CompanyCountryName,
                    color);

                lentelesEilutes = lentelesEilutes + Environment.NewLine + lentelesEilute;
            }

            return lentelesEilutes;
        }

        private static string GetLineColor(ReportItem eilute)
        {
            string color;
            if (eilute.BelongsToEU.HasValue && eilute.BelongsToEU == true)
            {
                // sviesiai melynas
                color = "#99ccff";
            }
            else
            {
                // sviesiai raudonas
                color = "#ffccff";
            }

            return color;
        }
    }
}
