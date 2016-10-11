

namespace WebAPIServiceLayer.Application.Services
{
    public class UploadReport
    {
        public string Label { get; set; }
        public string Message { get; set; }

        public string FileName { get; set; }

        public UploadReport(int insertedCount, int allCount)
        {
            InitialiseMessageAndLabel(insertedCount, allCount);
        }

        private void InitialiseMessageAndLabel(int insertedCount, int allCount)
        {
            int duplicatesCount = allCount - insertedCount;

            if (allCount == 0)
            {
                Label = "info";
                Message =  "Dit bestand bevat geen cursussen, controleer of het goede bestand is geselecteerd.";
            }

            if (insertedCount == 0)
            {
                Label = "warning";
                Message = $"Geen nieuwe cursussen gevonden. Alle {allCount} cursussen waren al aanwezig. Controleer of het goede bestand is geselecteerd.";
            }

            if (duplicatesCount == 0)
            {
                Label = "success";
                Message = $"Alle {insertedCount} cursussen zijn nieuw toegevoegd!";
            }

            Label = "success";
            Message = $"{insertedCount} cursussen toegevoegd! {duplicatesCount} cursussen niet toegevoegd, omdat ze al aanwezig waren.";
        }
    }
}
