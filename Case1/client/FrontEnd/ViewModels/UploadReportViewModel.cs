
using Frontend.Agents.Models;
using Frontend.Exceptions;
using System;

namespace FrontEnd.ViewModel
{
    public struct UploadReportViewModel
    {
        public readonly string FileName;
        public readonly string Label;
        public readonly string Message;

        public UploadReportViewModel(string fileName, string label, string message)
        {
            FileName = fileName;
            Label = label;
            Message = message;
        }

        public static UploadReportViewModel fromUploadReport(UploadReport report)
        {
            string label = "success";
            string message = $"{report.AmountInserted} cursussen toegevoegd! {report.AmountOfDuplicates} cursussen niet toegevoegd, omdat ze al aanwezig waren.";

            if (report.AmountTotal == 0)
            {
                label = "info";
                message = "Dit bestand bevat geen cursussen, controleer of het goede bestand is geselecteerd.";
            } else if (report.AmountInserted == 0)
            {
                label = "warning";
                message = $"Geen nieuwe cursussen gevonden. Alle {report.AmountTotal} cursussen waren al aanwezig. Controleer of het goede bestand is geselecteerd.";
            } else if (report.AmountOfDuplicates == 0)
            {
                label = "success";
                message = $"Alle {report.AmountInserted} cursussen zijn nieuw toegevoegd!";
            }

            return new UploadReportViewModel(report.FileName, label, message);
        }

        public static UploadReportViewModel fromException(InvalidLineException exception)
        {
            return new UploadReportViewModel(exception.FileName, "danger", exception.Message);
        }
    }
}
