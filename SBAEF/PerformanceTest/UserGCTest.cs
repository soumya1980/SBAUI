using NBench;
using ProjectTrackerAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace PerformanceTest
{
    public class UserGCTest : PerformanceTestSuite<UserGCTest>
    {
        private UsersController _userController = new UsersController();

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
                    _userController.Request = new HttpRequestMessage();
                    var config = new HttpConfiguration();
                    _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
                    HttpResponseMessage apiResponse = _userController.GetUsers();
                }
                _userController.Dispose();
            }
        }
    }
}
