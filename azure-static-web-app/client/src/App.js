import logo from './logo.svg';
import './App.css';
import jQuery from 'jquery'


var Date='2029-03-02';
var DayOrNight=1;
var SiteId =1;
var DewateringDelay=0.0;
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
var StartOfShift= '2016-10-23 12:45:37.333';
var FirstActivity= '2016-10-24 12:45:37.333';
var LastActivity= '2016-10-25 12:45:37.333';
var EndOfShift= '2016-10-26 12:45:37.333';
var Fitter=0;
var SLAMs=0;
var VFL=0;
var Hazob=0;
var POPs=0;

// drill exclusives
var DrillId=1;
var DrillerId=0;
var Offsider=0;
var DHMSerialNo=0;
var DGSSerialNo=0;

// Service Exclusives
var SupervisorId=0;
var GasFlowsAndServices=0;
var OtherServices=0;
var TBTSite=0;
var TBTRadco=0;
var JSACompleted=0;
var SWPReview=0;




var mode = 0;

function postDrillData(){
  const apiUrl = `/api/bus-data?DrillId=${DrillId}&Date=${Date}&DayOrNight=${DayOrNight}&SiteId=${SiteId}&DewateringDelay=${DewateringDelay}&FishingDelay=${FishingDelay}&CalibrationDelay=${CalibrationDelay}&RigMaintenanceDelay=${RigMaintenanceDelay}&RigBreakdownDelay=${RigBreakdownDelay}&SurveyToolSignalLossDelay=${SurveyToolSignalLossDelay}&DHMBreakdownDelay=${DHMBreakdownDelay}&ContractorIncidentDelay=${ContractorIncidentDelay}&ManningDelay=${ManningDelay}&OtherContractorDelay=${OtherContractorDelay}&StoneDustingDelay=${StoneDustingDelay}&NoTransportDelay=${NoTransportDelay}&NoLoaderDriftyDelay=${NoLoaderDriftyDelay}&AccessEnvironmentDelay=${AccessEnvironmentDelay}&NoPowerDelay=${NoPowerDelay}&ElectricalCodesDelay=${ElectricalCodesDelay}&DewaterDelay=${DewaterDelay}&ERZInspectionsDelay=${ERZInspectionsDelay}&MineIncidentDelay=${MineIncidentDelay}&SurfaceSuctionDelay=${SurfaceSuctionDelay}&OtherPitDelay=${OtherPitDelay}&DrillingCoalHours=${DrillingCoalHours}&DrillingStoneHours=${DrillingStoneHours}&BranchingHours=${BranchingHours}&FlushingHours=${FlushingHours}&PushPullRodsHours=${PushPullRodsHours}&CoringHours=${CoringHours}&ConduitCycleHours=${ConduitCycleHours}&FeedFrameHours=${FeedFrameHours}&StandpipeHours=${StandpipeHours}&ReamingHours=${ReamingHours}&SetupHours=${SetupHours}&MeetingsHours=${MeetingsHours}&TravelHours=${TravelHours}&GroutingBoreholesHours=${GroutingBoreholesHours}&LabourHours=${LabourHours}&GasFlowsHours=${GasFlowsHours}&ConsumablesHours=${ConsumablesHours}&MobilisationHours=${MobilisationHours}&DeMobilisationHours=${DeMobilisationHours}&PlannedDrillingCoalMetres=${PlannedDrillingCoalMetres}&PlannedDrillingStoneMetres=${PlannedDrillingStoneMetres}&PlannedConduitingMetres=${PlannedConduitingMetres}&PlannedReamingMetres=${PlannedReamingMetres}&PlannedCoringMetres=${PlannedCoringMetres}&DrilledCoalMetres=${DrilledCoalMetres}&DrilledStoneMetres=${DrilledStoneMetres}&ConduitingMetres=${ConduitingMetres}&ReamingMetres=${ReamingMetres}&CoringMetres=${CoringMetres}&StartOfShift=${StartOfShift}&FirstActivity=${FirstActivity}&LastActivity=${LastActivity}&EndOfShift=${EndOfShift}&DrillerId=${DrillerId}&Offsider=${Offsider}&Fitter=${Fitter}&DHMSerialNo=${DHMSerialNo}&DGSSerialNo=${DGSSerialNo}&SLAMs=${SLAMs}&VFL=${VFL}&Hazob=${Hazob}&POPs=${POPs}`;
    jQuery.getJSON(apiUrl, data => {
      //console.log("test", data);
      //plotWKT(data); 
    });
}

function App() {
  return (
    <div className="App">
      <div>
        <div>
            "i do what i want"
            <button onclick={postDrillData()}>Click me</button>
            
        </div>
      </div>
    </div>
  );
}

export default App;
