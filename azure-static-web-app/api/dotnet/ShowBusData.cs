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
using System.Text.Json;
using Microsoft.Extensions.Primitives.StringValues;

namespace ShowBusData
{    

    public class DrillPackage
    {
        public int DrillId { get; set; }
        public string Date { get; set; }
        public int DayOrNight { get; set; }
        public float DewateringDelay { get; set; }
        public float FishingDelay { get; set; }
        public float CalibrationDelay { get; set; }
        public float RigMaintenanceDelay { get; set; }
        public float RigBreakdownDelay { get; set; }
        public float SurveyToolSignalLossDelay { get; set; }
        public float DHMBreakdownDelay { get; set; }
        public float ContractorIncidentDelay { get; set; }
        public float ManningDelay { get; set; }
        public float OtherContractorDelay { get; set; }
        public float StoneDustingDelay { get; set; }
        public float NoTransportDelay { get; set; }
        public float NoLoaderDriftyDelay { get; set; }
        public float AccessEnvironmentDelay { get; set; } 
        public float NoPowerDelay { get; set; }
        public float ElectricalCodesDelay { get; set; }
        public float DewaterDelay { get; set; }
        public float ERZInspectionsDelay { get; set; }
        public float MineIncidentDelay { get; set; }
        public float SurfaceSuctionDelay { get; set; }
        public float OtherPitDelay { get; set; }
        public float DrillingCoalHours { get; set; }
        public float DrillingStoneHours { get; set; }
        public float BranchingHours { get; set; }
        public float FlushingHours { get; set; }
        public float PushPullRodsHours { get; set; }
        public float CoringHours { get; set; }
        public float ConduitCycleHours { get; set; }
        public float FeedFrameHours { get; set; }
        public float StandpipeHours { get; set; }
        public float ReamingHours { get; set; }
        public float SetupHours { get; set; }
        public float MeetingsHours { get; set; }
        public float TravelHours { get; set; }
        public float GroutingBoreholesHours { get; set; }
        public float LabourHours { get; set; }
        public float GasFlowsHours { get; set; }
        public float ConsumablesHours { get; set; }
        public float MobilisationHours { get; set; }
        public float DeMobilisationHours { get; set; }
        public int PlannedDrillingCoalMetres { get; set; }
        public int PlannedDrillingStoneMetres { get; set; }
        public int PlannedConduitingMetres { get; set; }
        public int PlannedReamingMetres { get; set; }
        public int PlannedCoringMetres { get; set; }
        public int DrilledCoalMetres { get; set; }
        public int DrilledStoneMetres { get; set; }
        public int ConduitingMetres { get; set; }
        public int ReamingMetres { get; set; }
        public int CoringMetres { get; set; }
        public string StartOfShift { get; set; }
        public string FirstActivity { get; set; }
        public string LastActivity { get; set; }
        public string EndOfShift { get; set; }
        public int DrillerId { get; set; }
        public int Offsider { get; set; }
        public int Fitter { get; set; }
        public int DHMSerialNo { get; set; }
        public int DGSSerialNo { get; set; }
        public int SLAMs { get; set; }
        public int VFL { get; set; }
        public int Hazob { get; set; }
        public int POPs { get; set; }
    }

    public static class ShowBusDataMain
    {
        private static HttpClient httpClient = new HttpClient();
        private static readonly string AZURE_CONN_STRING = Environment.GetEnvironmentVariable("AzureSQLConnectionString");
        
        [FunctionName("ShowBusData")]
        public static async Task<IActionResult> ShowBusData([HttpTrigger("get", Route = "bus-dataa")] HttpRequest req, ILogger log)
        {                              
            int rid = 4, gid = 0, bean = 0;


            int drillId=null;
            string date= null;
            int dayOrNight= null;
            /*
            var DewateringDelay= 0.0;
            var FishingDelay=0.0;
            var CalibrationDelay=0.0; 
            var RigMaintenanceDelay=0.0;
            var RigBreakdownDelay=0.0;
            var SurveyToolSignalLossDelay=0.0; 
            var DHMBreakdownDelay=0.0;
            var ContractorIncidentDelay=0.0;
            var ManningDelay=0.0;
            var OtherContractorDelay=0.0;
            var StoneDustingDelay=0.0;
            var NoTransportDelay=0.0; 
            var NoLoaderDriftyDelay=0.0;
            var AccessEnvironmentDelay=0.0; 
            var NoPowerDelay=0.0;
            var ElectricalCodesDelay=0.0;
            var DewaterDelay=0.0;
            var ERZInspectionsDelay=0.0;
            var MineIncidentDelay=0.0;
            var SurfaceSuctionDelay=0.0;
            var OtherPitDelay=0.0;
            var DrillingCoalHours=0.0;
            var DrillingStoneHours=0.0;
            var BranchingHours=0.0;
            var FlushingHours=0.0;
            var PushPullRodsHours=0.0;
            var CoringHours=0.0;
            var ConduitCycleHours=0.0;
            var FeedFrameHours=0.0;
            var StandpipeHours=0.0;
            var ReamingHours=0.0;
            var SetupHours=0.0;
            var MeetingsHours=0.0;
            var TravelHours=0.0;
            var GroutingBoreholesHours=0.0;
            var LabourHours=0.0;
            var GasFlowsHours=0.0;
            var ConsumablesHours=0.0;
            var MobilisationHours=0.0;
            var DeMobilisationHours=0.0;
            var PlannedDrillingCoalMetres=0;
            var PlannedDrillingStoneMetres=0;
            var PlannedConduitingMetres=0;
            var PlannedReamingMetres=0;
            var PlannedCoringMetres=0;
            var DrilledCoalMetres=0;
            var DrilledStoneMetres=0;
            var ConduitingMetres=0;
            var ReamingMetres=0;
            var CoringMetres=0; 
            string StartOfShift= null;
            string FirstActivity= null;
            string LastActivity= null;
            string EndOfShift= null;
            var DrillerId=0;
            var Offsider=0;
            var Fitter=0;
            var DHMSerialNo=0;
            var DGSSerialNo=0;
            var SLAMs=0;
            var VFL=0;
            var Hazob=0;
            var POPs=0;
            */


            Int32.TryParse(req.Query["DrillId"], out drillId);
            string tdate = req.Query["Date"];
            if (tdate !="" && !(tdate == StringValues.Empty)){
                date = tdate;
            }
            Int32.TryParse(req.Query["DayOrNight"], out dayOrNight);

            //Single.TryParse(req.Query["DewateringDelay"], out gid);

            using(var conn = new SqlConnection(AZURE_CONN_STRING))
            {
                var result = await conn.QuerySingleOrDefaultAsync<string>(
                    "web.PostDrillData2", 
                    new {
                        @DrillId = drillId,
                        Date = date,
                        @DayOrNight = dayOrNight
                        


                    }, commandType: CommandType.StoredProcedure);                
                
                return new OkObjectResult(JObject.Parse(result));
            }            
        }
        
        /*
        [FunctionName("PostDrillData")]
        public static async Task<IActionResult> PostDrillData([HttpTrigger("get", Route = "drill-data")] HttpRequest req, ILogger log)
        {                              
            string drillString = "";

            drillString = req.Query["dpack"];

            DrillPackage? drillPackage = 
                System.Text.Json.JsonSerializer.Deserialize<DrillPackage>(drillString);


            using(var conn = new SqlConnection(AZURE_CONN_STRING))
            {
                var result = await conn.QuerySingleOrDefaultAsync<string>(
                    "web.PostDrillData", 
                    new {

                        @DrillId = 1,
                        Date = "2022-01-01",
                        @DayOrNight = 0
                        
                        @DewateringDelay = drillPackage.DewateringDelay,
                        @FishingDelay = drillPackage.FishingDelay,
                        @CalibrationDelay = drillPackage.CalibrationDelay, 
                        @RigMaintenanceDelay = drillPackage.RigMaintenanceDelay,
                        @RigBreakdownDelay = drillPackage.RigBreakdownDelay,
                        @SurveyToolSignalLossDelay = drillPackage.SurveyToolSignalLossDelay,
                        @DHMBreakdownDelay = drillPackage.DHMBreakdownDelay,
                        @ontractorIncidentDelay = drillPackage.ContractorIncidentDelay,
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
        }*/
    }
}

/*
using System.Text.Json;

namespace DeserializeExtra
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public IList<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";
                
            WeatherForecast? weatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(jsonString);

            Console.WriteLine($"Date: {weatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast?.Summary}");
        }
    }
}
// output:
//Date: 8/1/2019 12:00:00 AM -07:00
//TemperatureCelsius: 25
//Summary: Hot
*/