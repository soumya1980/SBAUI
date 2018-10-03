using NBench;
using ProjectTrackerAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class TaskGCTest : PerformanceTestSuite<TaskGCTest>
    {
        private TasksController _taskController = new TasksController();

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void MeasureGarbageCollections()
        {
            RunTest();
        }
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen0, MustBe.LessThan, 300)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen1, MustBe.LessThan, 150)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThan, 20)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThan, 50)]
        public void TestGarbageCollections()
        {
            RunTest();
        }
        private void RunTest()
        {
            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    _taskController.Request = new HttpRequestMessage();
                    var config = new HttpConfiguration();
                    _taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
                    HttpResponseMessage apiResponse = _taskController.GetTasks();
                }
                _taskController.Dispose();
            }
        }
    }
}
