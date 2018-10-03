using NBench;
using ProjectTrackerAPI.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class TaskThroughPutTest : PerformanceTestSuite<TaskThroughPutTest>
    {
        private TasksController _taskController = new TasksController();
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
            _taskController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _taskController.GetTasks();
            addCounter.Increment();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, 100)]
        public void AddThroughput_IterationsMode(BenchmarkContext context)
        {
            for (var i = 0; i < 100; i++)
            {
                _taskController.Request = new HttpRequestMessage();
                var config = new HttpConfiguration();
                _taskController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
                HttpResponseMessage apiResponse = _taskController.GetTasks();
                addCounter.Increment();
            }
        }

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            _taskController.Dispose();
        }
    }
}
