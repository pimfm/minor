

namespace WebAPIServiceLayer.Domain.Entities
{
    public class UploadReport
    {
        public int AmountInserted { get; private set; }
        public int AmountTotal { get; private set; }
        public int AmountOfDuplicates { get; private set; }

        public string FileName { get; set; }

        public UploadReport(int insertedCount, int allCount)
        {
            AmountInserted = insertedCount;
            AmountTotal = allCount;
            AmountOfDuplicates = allCount - insertedCount;
        }
    }
}
