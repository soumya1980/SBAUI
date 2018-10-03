using NBench;
using ProjectTrackerAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class TaskMemoryTest : PerformanceTestSuite<TaskMemoryTest>
    {
        private const int NumberOfAdds = 1000000;
        private const int EntrySize = 24;
        private const int MaxExpectedMemory = NumberOfAdds * EntrySize;

        private TasksController _taskController;

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void AddMemoryMeasurement()
        {
            _taskController = new TasksController();
            _taskController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _taskController.GetTasks();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test, Description = "getTask with capacity, add memory test.")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, MaxExpectedMemory)]
        public void AddMemory_PassingTest()
        {
            _taskController = new TasksController();
            _taskController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _taskController.GetTasks();
        }
    }
}
