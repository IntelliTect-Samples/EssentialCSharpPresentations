using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharp9
{
    public class CustomizingRecordsTests
    {
        public record FinglePrint/*(string CreatedBy)*/
        {
            public DateTime CreatedDate { get; } = DateTime.UtcNow;
            public string CreatedBy { get; }

            public FinglePrint(string createdBy)
            {
                CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            }

            public DateTime? ModifiedDate { get; init; }

            public string? ModifiedBy { get; init; }
            //private string? _ModifiedBy;
            //public string? ModifiedBy
            //{
            //    get => _ModifiedBy;
            //    init
            //    {
            //        _ModifiedBy = value;
            //        ModifiedDate = DateTime.UtcNow;
            //    }
            //}
        }

        [Fact]
        public async Task Equality()
        {
            FinglePrint finglePrint1 = new("Inigo"){ ModifiedBy = "Inigo" };
            await Task.Delay(50);
            FinglePrint finglePrint2 = finglePrint1 with { ModifiedBy = "Buttercup" };
            FinglePrint finglePrint3 = finglePrint2 with { ModifiedBy = "Inigo" };

            Assert.True(finglePrint1 != finglePrint2);
            Assert.True(finglePrint1 == finglePrint3);

            Assert.Equal(finglePrint1.CreatedDate, finglePrint2.CreatedDate);
            Assert.Equal(finglePrint1.CreatedDate, finglePrint3.CreatedDate);
        }

        [Fact]
        public async Task ModifiedBy()
        {
            FinglePrint finglePrint1 = new("Inigo");
            await Task.Delay(50);
            var finglePrint2 = finglePrint1 with { ModifiedBy = "Buttercup" };

            Assert.NotEqual(finglePrint1.ModifiedDate, finglePrint2.ModifiedDate);
        }
    }
}
