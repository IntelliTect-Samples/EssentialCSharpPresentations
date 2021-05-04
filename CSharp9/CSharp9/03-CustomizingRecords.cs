using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharp9
{
    public class CustomizingRecordsTests
    {
        public record FinglePrint(string CreatedBy)
        {
            public DateTime? ModifiedDate { get; init; }
            public string? ModifiedBy { get; init; }
        }

        [Fact]
        public async Task Equality()
        {
            FinglePrint finglePrint1 = new("Inigo"){ ModifiedBy = "Inigo" };
            FinglePrint finglePrint2 = finglePrint1 with { ModifiedBy = "Buttercup" };
            FinglePrint finglePrint3 = finglePrint2 with { ModifiedBy = "Inigo" };

        }

        [Fact]
        public async Task ModifiedBy()
        {
            FinglePrint finglePrint1 = new("Inigo");
            var finglePrint2 = finglePrint1 with { ModifiedBy = "Buttercup" };

            Assert.NotEqual(finglePrint1.ModifiedDate, finglePrint2.ModifiedDate);
        }
    }
}
