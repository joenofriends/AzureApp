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
using Microsoft.Extensions.Primitives;

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


            int drillId = 0;
            string date= null;
            int dayOrNight= 0;

            double dewateringDelay= 0.0;
            double fishingDelay=0.0;
            double calibrationDelay=0.0; 
            double rigMaintenanceDelay=0.0;
            double rigBreakdownDelay=0.0;
            double surveyToolSignalLossDelay=0.0; 
            double dHMBreakdownDelay=0.0;
            double contractorIncidentDelay=0.0;
            double manningDelay=0.0;
            double otherContractorDelay=0.0;
            double stoneDustingDelay=0.0;
            double noTransportDelay=0.0; 
            double noLoaderDriftyDelay=0.0;
            double accessEnvironmentDelay=0.0; 
            double noPowerDelay=0.0;
            double electricalCodesDelay=0.0;
            double dewaterDelay=0.0;
            double eRZInspectionsDelay=0.0;
            double mineIncidentDelay=0.0;
            double surfaceSuctionDelay=0.0;
            double otherPitDelay=0.0;
            double drillingCoalHours=0.0;
            double drillingStoneHours=0.0;
            double branchingHours=0.0;
            double flushingHours=0.0;
            double pushPullRodsHours=0.0;
            double coringHours=0.0;
            double conduitCycleHours=0.0;
            double feedFrameHours=0.0;
            double standpipeHours=0.0;
            double reamingHours=0.0;
            double setupHours=0.0;
            double meetingsHours=0.0;
            double travelHours=0.0;
            double groutingBoreholesHours=0.0;
            double labourHours=0.0;
            double gasFlowsHours=0.0;
            double consumablesHours=0.0;
            double mobilisationHours=0.0;
            double deMobilisationHours=0.0;
            int plannedDrillingCoalMetres=0;
            int plannedDrillingStoneMetres=0;
            int plannedConduitingMetres=0;
            int plannedReamingMetres=0;
            int plannedCoringMetres=0;
            int drilledCoalMetres=0;
            int drilledStoneMetres=0;
            int conduitingMetres=0;
            int reamingMetres=0;
            int coringMetres=0; 
            string startOfShift= null;
            string firstActivity= null;
            string lastActivity= null;
            string endOfShift= null;
            int drillerId=0;
            int offsider=0;
            int fitter=0;
            int dHMSerialNo=0;
            int dGSSerialNo=0;
            int sLAMs=0;
            int vFL=0;
            int hazob=0;
            int pOPs=0;


            Int32.TryParse(req.Query["DrillId"], out drillId);
            string tdate = req.Query["Date"];
            if (tdate !="" && !(StringValues.IsNullOrEmpty(req.Query["Date"]))){
                date = tdate;
            }
            Int32.TryParse(req.Query["DayOrNight"], out dayOrNight);

            Single.TryParse(req.Query["DewateringDelay"], out dewateringDelay);
            Single.TryParse(req.Query["FishingDelay"], out fishingDelay);
            Single.TryParse(req.Query["CalibrationDelay"], out calibrationDelay); 
            Single.TryParse(req.Query["RigMaintenanceDelay"], out rigMaintenanceDelay);
            Single.TryParse(req.Query["RigBreakdownDelay"], out rigBreakdownDelay);
            Single.TryParse(req.Query["SurveyToolSignalLossDelay"], out surveyToolSignalLossDelay); 
            Single.TryParse(req.Query["DHMBreakdownDelay"], out dHMBreakdownDelay);
            Single.TryParse(req.Query["ContractorIncidentDelay"], out contractorIncidentDelay);
            Single.TryParse(req.Query["ManningDelay"], out manningDelay);
            Single.TryParse(req.Query["OtherContractorDelay"], out otherContractorDelay);
            Single.TryParse(req.Query["StoneDustingDelay"], out stoneDustingDelay);
            Single.TryParse(req.Query["NoTransportDelay"], out noTransportDelay); 
            Single.TryParse(req.Query["NoLoaderDriftyDelay"], out noLoaderDriftyDelay);
            Single.TryParse(req.Query["AccessEnvironmentDelay"], out accessEnvironmentDelay); 
            Single.TryParse(req.Query["NoPowerDelay"], out noPowerDelay);
            Single.TryParse(req.Query["ElectricalCodesDelay"], out electricalCodesDelay);
            Single.TryParse(req.Query["DewaterDelay"], out dewaterDelay);
            Single.TryParse(req.Query["ERZInspectionsDelay"], out eRZInspectionsDelay);
            Single.TryParse(req.Query["MineIncidentDelay"], out mineIncidentDelay);
            Single.TryParse(req.Query["SurfaceSuctionDelay"], out surfaceSuctionDelay);
            Single.TryParse(req.Query["OtherPitDelay"], out otherPitDelay);
            Single.TryParse(req.Query["DrillingCoalHours"], out drillingCoalHours);
            Single.TryParse(req.Query["DrillingStoneHours"], out drillingStoneHours);
            Single.TryParse(req.Query["BranchingHours"], out branchingHours);
            Single.TryParse(req.Query["FlushingHours"], out flushingHours);
            Single.TryParse(req.Query["PushPullRodsHours"], out pushPullRodsHours);
            Single.TryParse(req.Query["CoringHours"], out coringHours);
            Single.TryParse(req.Query["ConduitCycleHours"], out conduitCycleHours);
            Single.TryParse(req.Query["FeedFrameHours"], out feedFrameHours);
            Single.TryParse(req.Query["StandpipeHours"], out standpipeHours);
            Single.TryParse(req.Query["ReamingHours"], out reamingHours);
            Single.TryParse(req.Query["SetupHours"], out setupHours);
            Single.TryParse(req.Query["MeetingsHours"], out meetingsHours);
            Single.TryParse(req.Query["TravelHours"], out travelHours);
            Single.TryParse(req.Query["GroutingBoreholesHours"], out groutingBoreholesHours);
            Single.TryParse(req.Query["LabourHours"], out labourHours);
            Single.TryParse(req.Query["GasFlowsHours"], out gasFlowsHours);
            Single.TryParse(req.Query["ConsumablesHours"], out consumablesHours);
            Single.TryParse(req.Query["MobilisationHours"], out mobilisationHours);
            Single.TryParse(req.Query["DeMobilisationHours"], out deMobilisationHours);
            Int32.TryParse(req.Query["PlannedDrillingCoalMetres"], out plannedDrillingCoalMetres);
            Int32.TryParse(req.Query["PlannedDrillingStoneMetres"], out plannedDrillingStoneMetres);
            Int32.TryParse(req.Query["PlannedConduitingMetres"], out plannedConduitingMetres);
            Int32.TryParse(req.Query["PlannedReamingMetres"], out plannedReamingMetres);
            Int32.TryParse(req.Query["PlannedCoringMetres"], out plannedCoringMetres);
            Int32.TryParse(req.Query["DrilledCoalMetres"], out drilledCoalMetres);
            Int32.TryParse(req.Query["DrilledStoneMetres"], out drilledStoneMetres);
            Int32.TryParse(req.Query["ConduitingMetres"], out conduitingMetres);
            Int32.TryParse(req.Query["ReamingMetres"], out reamingMetres);
            Int32.TryParse(req.Query["CoringMetres"], out coringMetres); 
            string tstartOfShift = req.Query["StartOfShift"];
            if (tstartOfShift !="" && !(StringValues.IsNullOrEmpty(req.Query["StartOfShift"]))){
                startOfShift = tstartOfShift;
            }string tfirstActivity = req.Query["FirstActivity"];
            if (tfirstActivity !="" && !(StringValues.IsNullOrEmpty(req.Query["FirstActivity"]))){
                firstActivity = tfirstActivity;
            }string tlastActivity = req.Query["LastActivity"];
            if (tlastActivity !="" && !(StringValues.IsNullOrEmpty(req.Query["LastActivity"]))){
                lastActivity = tlastActivity;
            }string tendOfShift = req.Query["EndOfShift"];
            if (tendOfShift !="" && !(StringValues.IsNullOrEmpty(req.Query["EndOfShift"]))){
                endOfShift = tendOfShift;
            }
            Int32.TryParse(req.Query["DrillerId"], out drillerId);
            Int32.TryParse(req.Query["Offsider"], out offsider);
            Int32.TryParse(req.Query["Fitter"], out fitter);
            Int32.TryParse(req.Query["DHMSerialNo"], out dHMSerialNo);
            Int32.TryParse(req.Query["DGSSerialNo"], out dGSSerialNo);
            Int32.TryParse(req.Query["SLAMs"], out sLAMs);
            Int32.TryParse(req.Query["VFL"], out vFL);
            Int32.TryParse(req.Query["Hazob"], out hazob);
            Int32.TryParse(req.Query["POPs"], out pOPs);

            using(var conn = new SqlConnection(AZURE_CONN_STRING))
            {
                var result = await conn.QuerySingleOrDefaultAsync<string>(
                    "web.PostDrillData", 
                    new {
                        @DrillId = drillId,
                        Date = date,
                        @DayOrNight = dayOrNight,
                        DewateringDelay = dewateringDelay,
                        FishingDelay = fishingDelay,
                        CalibrationDelay = calibrationDelay, 
                        RigMaintenanceDelay = rigMaintenanceDelay,
                        RigBreakdownDelay = rigBreakdownDelay,
                        SurveyToolSignalLossDelay = surveyToolSignalLossDelay, 
                        DHMBreakdownDelay = dHMBreakdownDelay,
                        ContractorIncidentDelay = contractorIncidentDelay,
                        ManningDelay = manningDelay,
                        OtherContractorDelay = otherContractorDelay,
                        StoneDustingDelay = stoneDustingDelay,
                        NoTransportDelay = noTransportDelay, 
                        NoLoaderDriftyDelay = noLoaderDriftyDelay,
                        AccessEnvironmentDelay = accessEnvironmentDelay, 
                        NoPowerDelay = noPowerDelay,
                        ElectricalCodesDelay = electricalCodesDelay,
                        DewaterDelay = dewaterDelay,
                        ERZInspectionsDelay = eRZInspectionsDelay,
                        MineIncidentDelay = mineIncidentDelay,
                        SurfaceSuctionDelay = surfaceSuctionDelay,
                        OtherPitDelay = otherPitDelay,
                        DrillingCoalHours = drillingCoalHours,
                        DrillingStoneHours = drillingStoneHours,
                        BranchingHours = branchingHours,
                        FlushingHours = flushingHours,
                        PushPullRodsHours = pushPullRodsHours,
                        CoringHours = coringHours,
                        ConduitCycleHours = conduitCycleHours,
                        FeedFrameHours = feedFrameHours,
                        StandpipeHours = standpipeHours,
                        ReamingHours = reamingHours,
                        SetupHours = setupHours,
                        MeetingsHours = meetingsHours,
                        TravelHours = travelHours,
                        GroutingBoreholesHours = groutingBoreholesHours,
                        LabourHours = labourHours,
                        GasFlowsHours = gasFlowsHours,
                        ConsumablesHours = consumablesHours,
                        MobilisationHours = mobilisationHours,
                        DeMobilisationHours = deMobilisationHours,
                        @PlannedDrillingCoalMetres = plannedDrillingCoalMetres,
                        @PlannedDrillingStoneMetres = plannedDrillingStoneMetres,
                        @PlannedConduitingMetres = plannedConduitingMetres,
                        @PlannedReamingMetres = plannedReamingMetres,
                        @PlannedCoringMetres = plannedCoringMetres,
                        @DrilledCoalMetres = drilledCoalMetres,
                        @DrilledStoneMetres = drilledStoneMetres,
                        @ConduitingMetres = conduitingMetres,
                        @ReamingMetres = reamingMetres,
                        @CoringMetres = coringMetres, 
                        StartOfShift = startOfShift,
                        FirstActivity = firstActivity,
                        LastActivity = lastActivity,
                        EndOfShift = endOfShift,
                        @DrillerId = drillerId,
                        @Offsider = offsider,
                        @Fitter = fitter,
                        @DHMSerialNo = dHMSerialNo,
                        @DGSSerialNo = dGSSerialNo,
                        @SLAMs = sLAMs,
                        @VFL = vFL,
                        @Hazob = hazob,
                        @POPs = pOPs,

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