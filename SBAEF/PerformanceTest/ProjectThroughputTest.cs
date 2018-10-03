using NBench;
using ProjectTrackerAPI.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class ProjectThroughputTest : PerformanceTestSuite<ProjectThroughputTest>
    {
        private ProjectsController _projectController = new ProjectsController();
        private const string AddCounterName = "AddCounter";
        private Counter addCounter;
        private const int AcceptableMinAddThroughput = 20000000;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);
        }

        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public void AddThroughput_ThroughputMode(BenchmarkContext context)
        {
            _projectController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _projectController.GetProjects();
            addCounter.Increment();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, 100)]
        public void AddThroughput_IterationsMode(BenchmarkContext context)
        {
            for (var i = 0; i < 100; i++)
            {
                _projectController.Request = new HttpRequestMessage();
                var config = new HttpConfiguration();
                _projectController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
                HttpResponseMessage apiResponse = _projectController.GetProjects();
                addCounter.Increment();
            }
        }

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            _projectController.Dispose();
        }
    }
}
