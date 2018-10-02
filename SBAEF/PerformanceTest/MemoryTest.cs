using NBench;
using ProjectTrackerAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class MemoryTest : PerformanceTestSuite<MemoryTest>
    {
        private const int NumberOfAdds = 1000000;
        private const int EntrySize = 24;
        private const int MaxExpectedMemory = NumberOfAdds * EntrySize;

        private UsersController _userController;

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void AddMemoryMeasurement()
        {
            _userController = new UsersController();
            _userController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _userController.GetUsers();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test, Description = "getUser with capacity, add memory test.")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, MaxExpectedMemory)]
        public void AddMemory_PassingTest()
        {
            _userController = new UsersController();
            _userController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _userController.GetUsers();
        }
    }
}
