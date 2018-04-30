using TrackMyJob.Api;
using TrackMyJob.Framework.Test;
using Xunit;

namespace TrackMyJob.UnitTest
{
    public class SampleTest : IClassFixture<WebHostFixture<Startup>>
    {
        public SampleTest(WebHostFixture<Startup> webHostFixture)
        {
            WebHostFixture = webHostFixture;
        }

        public WebHostFixture<Startup> WebHostFixture { get; }

        private string path = "api/v1/Sample";

        //[Fact]
        //public async Task test_insert_update_delete_projects()
        //{
        //    Func<ProjectInsertCommand, HttpStatusCode, HttpContent> postFunc = (postObj, statusExpected) =>
        //    {
        //        var httpResponse = this.WebHostFixture.TestClient.PostAsObjectAsync(this.path, postObj).Result;
        //        Assert.True(httpResponse.StatusCode == statusExpected, httpResponse.Content.ReadAsStringAsync().Result);
        //        return httpResponse.Content;
        //    };
        //}
    }
}