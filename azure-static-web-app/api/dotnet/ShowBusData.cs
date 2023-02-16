using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ShowBusData
{    
    public static class ShowBusDataMain
    {
        private static HttpClient httpClient = new HttpClient();
        private static readonly string AZURE_CONN_STRING = Environment.GetEnvironmentVariable("AzureSQLConnectionString");

        [FunctionName("ShowBusData")]
        public static async Task<IActionResult> ShowBusData([HttpTrigger("get", Route = "bus-data")] HttpRequest req, ILogger log)
        {                              
            int rid = 0, gid = 0, bean = 0;

            Int32.TryParse(req.Query["rid"], out rid);
            Int32.TryParse(req.Query["gid"], out gid);

            using(var conn = new SqlConnection(AZURE_CONN_STRING))
            {
                var result = await conn.QuerySingleOrDefaultAsync<string>(
                    "web.GetMonitoredBusData", 
                    new {
                        @RouteId = rid,
                        @GeofenceId = gid
                    }, commandType: CommandType.StoredProcedure);                
                
                return new OkObjectResult(JObject.Parse(result));
            }            
        }
        
        [FunctionName("PostDrillData")]
        public static async Task<IActionResult> PostDrillData([HttpTrigger("get", Route = "drill-data")] HttpRequest req, ILogger log)
        {                              
            string drillString = "";

            Int32.TryParse(req.Query["dpack"], out drillPackage);

            var drillPackage = JSON.parse(drillString);


            using(var conn = new SqlConnection(AZURE_CONN_STRING))
            {
                var result = await conn.QuerySingleOrDefaultAsync<string>(
                    "web.PostDrillData", 
                    new {

                        @DrillId = drillPackage.DrillId,
                        @Date = drillPackage.Date,
                        @DayOrNight = drillPackage.DayOrNight,
                        @DewateringDelay = drillPackage.DewateringDelay,
                        @FishingDelay = drillPackage.FishingDelay,
                        @CalibrationDelay = drillPackage.CalibrationDelay, 
                        @RigMaintenanceDelay = drillPackage.RigMaintenanceDelay,
                        @RigBreakdownDelay = drillPackage.RigBreakdownDelay,
                        @SurveyToolSignalLossDelay = drillPackage.SurveyToolSignalLossDelay,
                        @DHMBreakdownDelay = drillPackage.DHMBreakdownDelay,
                        @ontractorIncidentDelay = drillPackage.ontractorIncidentDelay,
                        @ManningDelay = drillPackage.ManningDelay,
                        @OtherContractorDelay = drillPackage.OtherContractorDelay,
                        @StoneDustingDelay = drillPackage.StoneDustingDelay,
                        @NoTransportDelay = drillPackage.NoTransportDelay,
                        @NoLoaderDriftyDelay = drillPackage.NoLoaderDriftyDelay,
                        @AccessEnvironmentDelay = drillPackage.AccessEnvironmentDelay, 
                        @NoPowerDelay = drillPackage.NoPowerDelay,
                        @ElectricalCodesDelay = drillPackage.ElectricalCodesDelay,
                        @DewaterDelay = drillPackage.DewaterDelay,
                        @ERZInspectionsDelay = drillPackage.ERZInspectionsDelay,
                        @MineIncidentDelay = drillPackage.MineIncidentDelay,
                        @SurfaceSuctionDelay = drillPackage.SurfaceSuctionDelay,
                        @OtherPitDelay = drillPackage.OtherPitDelay,
                        @DrillingCoalHours = drillPackage.DrillingCoalHours,
                        @DrillingStoneHours = drillPackage.DrillingStoneHours,
                        @BranchingHours = drillPackage.BranchingHours,
                        @FlushingHours = drillPackage.FlushingHours,
                        @PushPullRodsHours = drillPackage.PushPullRodsHours,
                        @CoringHours = drillPackage.CoringHours,
                        @ConduitCycleHours = drillPackage.ConduitCycleHours,
                        @FeedFrameHours = drillPackage.FeedFrameHours,
                        @StandpipeHours = drillPackage.StandpipeHours,
                        @ReamingHours = drillPackage.ReamingHours,
                        @SetupHours = drillPackage.SetupHours,
                        @MeetingsHours = drillPackage.MeetingsHours,
                        @TravelHours = drillPackage.TravelHours,
                        @GroutingBoreholesHours = drillPackage.GroutingBoreholesHours,
                        @LabourHours = drillPackage.LabourHours,
                        @GasFlowsHours = drillPackage.GasFlowsHours,
                        @ConsumablesHours = drillPackage.ConsumablesHours,
                        @MobilisationHours = drillPackage.MobilisationHours,
                        @DeMobilisationHours = drillPackage.DeMobilisationHours,
                        @PlannedDrillingCoalMetres = drillPackage.PlannedDrillingCoalMetres,
                        @PlannedDrillingStoneMetres = drillPackage.PlannedDrillingStoneMetres,
                        @PlannedConduitingMetres = drillPackage.PlannedConduitingMetres,
                        @PlannedReamingMetres = drillPackage.PlannedReamingMetres,
                        @PlannedCoringMetres = drillPackage.PlannedCoringMetres,
                        @DrilledCoalMetres = drillPackage.DrilledCoalMetres,
                        @DrilledStoneMetres = drillPackage.DrilledStoneMetres,
                        @ConduitingMetres = drillPackage.ConduitingMetres,
                        @ReamingMetres = drillPackage.ReamingMetres,
                        @CoringMetres = drillPackage.CoringMetres, 
                        @StartOfShift = drillPackage.StartOfShift,
                        @FirstActivity = drillPackage.FirstActivity,
                        @LastActivity = drillPackage.LastActivity,
                        @EndOfShift = drillPackage.EndOfShift,
                        @DrillerId = drillPackage.DrillerId,
                        @Offsider = drillPackage.Offsider,
                        @Fitter = drillPackage.Fitter,
                        @DHMSerialNo = drillPackage.DHMSerialNo,
                        @DGSSerialNo = drillPackage.DGSSerialNo,
                        @SLAMs = drillPackage.SLAMs,
                        @VFL = drillPackage.VFL,
                        @Hazob = drillPackage.Hazob,
                        @POPs = drillPackage.POPs

                    }, commandType: CommandType.StoredProcedure);                
                
                return new OkObjectResult(JObject.Parse(result));
            }            
        }
    }
}
