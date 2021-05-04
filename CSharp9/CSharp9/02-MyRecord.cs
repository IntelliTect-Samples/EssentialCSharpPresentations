using Xunit;

namespace CSharp9
{
    public class MyRecordTests
    {
        public class FinglePrint
        {
            public string CreatedBy { get; set; }

            public string? ModifiedBy { get; set; }

            public FinglePrint(string createdBy, string? modifiedBy = null)
            {
                CreatedBy = createdBy;
                ModifiedBy = modifiedBy;
            }
        }

        [Fact]
        public void Create()
        {
            FinglePrint finglePrint = new("Inygo");
        }

        [Fact]
        public void UpdateProperties()
        {
            FinglePrint? finglePrint = CreateFinglePrint();
            finglePrint.CreatedBy = "Kevin";
            finglePrint.ModifiedBy = "Humperdink";
        }

        private static FinglePrint CreateFinglePrint(
                string createdBy = "Inygo",
                string? modifiedBy = "Humperdink")
        {
            return new(createdBy)
            {
                ModifiedBy = modifiedBy
            };
        }

        [Fact]
        public void ModifyRecord()
        {
            FinglePrint finglePrint = CreateFinglePrint();

            //FinglePrint finglePrint2 = fingerPrint.With("Buttercup");
        }
    }
}
