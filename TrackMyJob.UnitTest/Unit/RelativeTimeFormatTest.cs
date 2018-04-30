using System;
using System.Threading.Tasks;
using Xunit;
using TrackMyJob.Domain.Helpers;

namespace TrackMyJob.UnitTest.Unit
{
    public class RelativeTimeFormatTest
    {
        [Fact]
        public void test_format_times()
        {
            string value = RelativeTimeFormat.RelativizeTime(DateTime.Now.AddDays(-1));
            Assert.True(value == "yesterday");

            value = RelativeTimeFormat.RelativizeTime(DateTime.Now);
            Assert.True(value == "today");

            value = RelativeTimeFormat.RelativizeTime(DateTime.Now.AddDays(1));
            Assert.True(value == "tomorrow");

            value = RelativeTimeFormat.RelativizeTime(DateTime.Now.AddDays(-2));
            Assert.True(value == DateTime.Now.AddDays(-2).ToString("MM/dd"));

            value = RelativeTimeFormat.RelativizeTime(DateTime.Now.AddDays(2));
            Assert.True(value == DateTime.Now.AddDays(2).ToString("MM/dd"));
        }
    }
}
