using Xunit;

namespace CSharp9
{
    public class Records
    {
        public record FinglePrint(string CreatedBy, string? ModifiedBy = null) { }

        [Fact]
        public void Create()
        {
            FinglePrint _ = new("Inygo");
        }

        private static FinglePrint CreateFinglePrint(
                string createdBy = "Inygo",
                string? modifiedBy = "Humperdink"
            ) => new(createdBy)
            {
                ModifiedBy = modifiedBy
            };

        [Fact]
        public void UpdateProperties()
        {
            FinglePrint? finglePrint = CreateFinglePrint();
            //finglePrint.CreatedBy = "Kevin";
            //finglePrint.ModifiedBy = "Humperdink";
        }

        [Fact]
        public void ModifyRecord()
        {
            FinglePrint finglePrint = CreateFinglePrint();

            FinglePrint finglePrint2 = finglePrint with { ModifiedBy = "Buttercup" };
        }

    }
}
