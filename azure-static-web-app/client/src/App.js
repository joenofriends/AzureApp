import logo from './logo.svg';
import './App.css';
import jQuery from 'jquery'
import React from 'react';


var DrillId=0;
var Date='2029-03-05';
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

function getDrillData(){
  const apiUrl = `/api/bus-dataa`;
    jQuery.getJSON(apiUrl, data => {
      console.log("test", data);
      //plotWKT(data); 
    });
}

function Page(props){
  const [date, setDate] = React.useState();
  const [dayOrNight, setDayOrNight] = React.useState();
  const [siteId, setSiteId] = React.useState();
  const [dewateringDelay, setDewateringDelay] = React.useState();
  const [fishingDelay, setFishingDelay] = React.useState();
  const [calibrationDelay, setCalibrationDelay] = React.useState(); 
  const [rigMaintenanceDelay, setRigMaintenanceDelay] = React.useState();
  const [rigBreakdownDelay, setRigBreakdownDelay] = React.useState();
  const [surveyToolSignalLossDelay, setSurveyToolSignalLossDelay] = React.useState(); 
  const [dHMBreakdownDelay, setDHMBreakdownDelay] = React.useState();
  const [contractorIncidentDelay, setContractorIncidentDelay] = React.useState();
  const [manningDelay, setManningDelay] = React.useState();
  const [otherContractorDelay, setOtherContractorDelay] = React.useState();
  const [stoneDustingDelay, setStoneDustingDelay] = React.useState();
  const [noTransportDelay, setNoTransportDelay] = React.useState(); 
  const [noLoaderDriftyDelay, setNoLoaderDriftyDelay] = React.useState();
  const [accessEnvironmentDelay, setAccessEnvironmentDelay] = React.useState(); 
  const [noPowerDelay, setNoPowerDelay] = React.useState();
  const [electricalCodesDelay, setElectricalCodesDelay] = React.useState();
  const [dewaterDelay, setDewaterDelay] = React.useState();
  const [eRZInspectionsDelay, setERZInspectionsDelay] = React.useState();
  const [mineIncidentDelay, setMineIncidentDelay] = React.useState();
  const [surfaceSuctionDelay, setSurfaceSuctionDelay] = React.useState();
  const [otherPitDelay, setOtherPitDelay] = React.useState();
  const [drillingCoalHours, setDrillingCoalHours] = React.useState();
  const [drillingStoneHours, setDrillingStoneHours] = React.useState();
  const [branchingHours, setBranchingHours] = React.useState();
  const [flushingHours, setFlushingHours] = React.useState();
  const [pushPullRodsHours, setPushPullRodsHours] = React.useState();
  const [coringHours, setCoringHours] = React.useState();
  const [conduitCycleHours, setConduitCycleHours] = React.useState();
  const [feedFrameHours, setFeedFrameHours] = React.useState();
  const [standpipeHours, setStandpipeHours] = React.useState();
  const [reamingHours, setReamingHours] = React.useState();
  const [setupHours, setSetupHours] = React.useState();
  const [meetingsHours, setMeetingsHours] = React.useState();
  const [travelHours, setTravelHours] = React.useState();
  const [groutingBoreholesHours, setGroutingBoreholesHours] = React.useState();
  const [labourHours, setLabourHours] = React.useState();
  const [gasFlowsHours, setGasFlowsHours] = React.useState();
  const [consumablesHours, setConsumablesHours] = React.useState();
  const [mobilisationHours, setMobilisationHours] = React.useState();
  const [deMobilisationHours, setDeMobilisationHours] = React.useState();
  const [plannedDrillingCoalMetres, setPlannedDrillingCoalMetres] = React.useState();
  const [plannedDrillingStoneMetres, setPlannedDrillingStoneMetres] = React.useState();
  const [plannedConduitingMetres, setPlannedConduitingMetres] = React.useState();
  const [plannedReamingMetres, setPlannedReamingMetres] = React.useState();
  const [plannedCoringMetres, setPlannedCoringMetres] = React.useState();
  const [drilledCoalMetres, setDrilledCoalMetres] = React.useState();
  const [drilledStoneMetres, setDrilledStoneMetres] = React.useState();
  const [conduitingMetres, setConduitingMetres] = React.useState();
  const [reamingMetres, setReamingMetres] = React.useState();
  const [coringMetres, setCoringMetres] = React.useState(); 
  const [startOfShift, setStartOfShift] = React.useState();
  const [firstActivity, setFirstActivity] = React.useState();
  const [lastActivity, setLastActivity] = React.useState();
  const [endOfShift, setEndOfShift] = React.useState();
  const [fitter, setFitter] = React.useState();
  const [sLAMs, setSLAMs] = React.useState();
  const [vFL, setVFL] = React.useState();
  const [hazob, setHazob] = React.useState();
  const [pOPs, setPOPs] = React.useState();

  // drill exclusives
  const [drillId, setDrillId] = React.useState();
  const [drillerId, setDrillerId] = React.useState();
  const [offsider, setOffsider] = React.useState();
  const [dHMSerialNo, setDHMSerialNo] = React.useState();
  const [dGSSerialNo, setDGSSerialNo] = React.useState();

  // Service Exclusives
  const [supervisorId, setSupervisorId] = React.useState();
  const [gasFlowsAndServices, setGasFlowsAndServices] = React.useState();
  const [otherServices, setOtherServices] = React.useState();
  const [tBTSite, setTBTSite] = React.useState();
  const [tBTRadco, setTBTRadco] = React.useState();
  const [jSACompleted, setJSACompleted] = React.useState();
  const [sWPReview, setSWPReview] = React.useState();

  // Form Config
  const [sites, setSites] = React.useState([]);

  return (
    <DrillForm siteSetter = {setSiteId} sites={sites}></DrillForm>
  )
}

class SiteDropdown extends React.Component{
  constructor(props) {
    super(props);
    //console.log(props)
    //<button onClick={() => this.props.drillChanger("HERS1240")}>HERS1240</button>
  }
  render() {  
    const sites = this.props.sites;
    const options = sites.map((site)=>
      <option value = {String(site)}>{site}</option>
    );
    //console.log(this.props)
    return (
      <select onChange={(e) => this.props.siteChanger(e.target.value)}>
        <option value = "null">-Select a {this.props.object}-</option>
        {options}
      </select>
    );
  }
}

//<form onSubmit={this.handleSubmit}


function DrillForm(props){
  return (
    <div>
      <SiteDropdown siteChanger = {props.siteSetter} sites = {props.sites} object = "Site"></SiteDropdown>
      <form>
        <label>
          Name:
          <input type="text" value={this.state.value} onChange={this.handleChange} />
        </label>
        <input type="submit" value="Submit" />
      </form>
    </div>
  );
}

function ServicesForm(props){
  return (
    <form onSubmit={this.handleSubmit}>
      <label>
        Name:
        <input type="text" value={this.state.value} onChange={this.handleChange} />
      </label>
      <input type="submit" value="Submit" />
    </form>
  );
}

function App() {
  return (
    <div className="App">
      <div>
        <div>
            "i do what i want"
            <button onClick={getDrillData()}>Click me</button>
            
        </div>
      </div>
    </div>
  );
}

export default App;
