using NBench;
using ProjectTrackerAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class ProjectMemoryTest : PerformanceTestSuite<TaskMemoryTest>
    {
        private const int NumberOfAdds = 1000000;
        private const int EntrySize = 24;
        private const int MaxExpectedMemory = NumberOfAdds * EntrySize;

        private ProjectsController _projectController;

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void AddMemoryMeasurement()
        {
            _projectController = new ProjectsController();
            _projectController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _projectController.GetProjects();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test, Description = "getProject with capacity, add memory test.")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, MaxExpectedMemory)]
        public void AddMemory_PassingTest()
        {
            _projectController = new ProjectsController();
            _projectController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _projectController.GetProjects();
        }
    }
}
