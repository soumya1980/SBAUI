using NBench;
using ProjectTrackerAPI.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class UserThoughPutTest : PerformanceTestSuite<UserThoughPutTest>
    {
        private UsersController _userController = new UsersController();
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
            _userController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
            HttpResponseMessage apiResponse = _userController.GetUsers();
            addCounter.Increment();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, 100)]
        public void AddThroughput_IterationsMode(BenchmarkContext context)
        {
            for (var i = 0; i < 100; i++)
            {
                _userController.Request = new HttpRequestMessage();
                var config = new HttpConfiguration();
                _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
                HttpResponseMessage apiResponse = _userController.GetUsers();
                addCounter.Increment();
            }
        }

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            _userController.Dispose();
        }
    }
}
