import { AppComponent } from './../../app.component';
import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges,SimpleChanges } from '@angular/core';
import { BaseComponent } from '../../base.component';
import * as DTO from '../../models/_index';
import { IoTExService } from '../../services/_index';
import { SeriesClickEvent } from '@progress/kendo-angular-charts';
import {
  LoaderType,
  LoaderThemeColor,
  LoaderSize,
} from "@progress/kendo-angular-indicators";
import * as allIcons from "@progress/kendo-svg-icons";
import { min } from 'rxjs';
import { Console } from 'console';
import { data } from 'jquery';

@Component({
  selector: 'app-device-chart',
  templateUrl: './device-chart.component.html',
  styleUrl: './device-chart.component.css'
})

export class DeviceChartComponent extends BaseComponent implements OnInit {

  @Input() public devicePublished: DTO.DeviceDefinitionDTO;
  public periodData = [{value:0,text:"Last Hour"},{value:1,text:"Last Day"},{value:2,text:"Last Week"},{value:3,text:"Last Month"},{value:4,text:"Last Quarter"},{value:5,text:"Last Year"}]
  public intervalData = [{value:'1m',text:"Minute"},{value:'5m',text:"5 Minutes"},{value:'15m',text:"15 Minutes"},
                        {value:'1h',text:"Hour"},{value:'1d',text:"Day"},{value:'7d',text:"Week"},
                        {value:'1M',text:"Month"},{value:'3M',text:"Quarter"},{value:'1Y',text:"Year"}]
  public startDate: Date = new Date();
  public endDate: Date = new Date();
  public intervalValue: string = '5m';
  public periodValue: number = 0;
  public icon = allIcons;
  public icons = { reload: this.icon.arrowRotateCwIcon, searchIcon: this.icon.searchIcon, save: this.icon.saveIcon };
  public TelemetryData = new Map<string, any>();
  public myData = null;
  
  public labels = new Array();
  public clickedData: string = '';
  //public dataChart: MyChartData[] = [];
  public dataChart: Record<string, MyChartData> = {};
  constructor(private service: IoTExService) {
    super();
  }
  public ngOnInit(): void {
    

    this.changeQuery(0);
    this.refresh(); 
    
  } 
  public refresh(): void {
      
      this.log("Device Chart-refresh");
      //this.myData = new Array();
      
      // for (let i = 0; i < this.devicePublished.settings.alerts.length; i++) {
      //   for(let j = 0; j < this.devicePublished.settings.alerts[i].values.length; j++) {            
      //     const alertName = this.devicePublished.settings.alerts[i].name;
      //     const alertSubName = this.devicePublished.settings.alerts[i].values[j].name;
      //     this.myData.push({name:alertName+"-"+alertSubName+"-AVG", value: []});
      //     this.myData.push({name:alertName+"-"+alertSubName+"-MIN", value: []});
      //     this.myData.push({name:alertName+"-"+alertSubName+"-MAX", value: []});
      //     this.myData.push({name:alertName+"-"+alertSubName+"-SUM", value: []});
      //     this.myData.push({name:alertName+"-"+alertSubName+"-COUNT", value: []});
      //   }
      // }

      // for (let i = 0; i < this.devicePublished.settings.states.length; i++) {
      //   for(let j = 0; j < this.devicePublished.settings.states[i].values.length; j++) {            
      //     const stateName = this.devicePublished.settings.states[i].name;
      //     const stateSubName = this.devicePublished.settings.states[i].values[j].name;
      //     this.myData.push({name:stateName+"-"+stateSubName+"-AVG", value: []});
      //     this.myData.push({name:stateName+"-"+stateSubName+"-MIN", value: []});
      //     this.myData.push({name:stateName+"-"+stateSubName+"-MAX", value: []});
      //     this.myData.push({name:stateName+"-"+stateSubName+"-SUM", value: []});
      //     this.myData.push({name:stateName+"-"+stateSubName+"-COUNT", value: []});
      //   }
      // }

      // for (let i = 0; i < this.devicePublished.settings.measurements.length; i++) {
      //   const measurementName = this.devicePublished.settings.measurements[i].name;
      //   this.myData.push({name:measurementName+"-AVG", value: []});
      //   this.myData.push({name:measurementName+"-MIN", value: []});
      //   this.myData.push({name:measurementName+"-MAX", value: []});
      //   this.myData.push({name:measurementName+"-SUM", value: []});
      //   this.myData.push({name:measurementName+"-COUNT", value: []});
      //   this.myData.push({name:measurementName+"-LAST", value: []});
      //   this.myData.push({name:measurementName+"-ACTUAL", value: []});
      // }

      // this.myData.push({name:"IOTDEVICE_VOLT"+"-AVG", value: []});
      // this.myData.push({name:"IOTDEVICE_VOLT"+"-MIN", value: []});
      // this.myData.push({name:"IOTDEVICE_VOLT"+"-MAX", value: []});
      // this.myData.push({name:"IOTDEVICE_VOLT"+"-SUM", value: []});
      // this.myData.push({name:"IOTDEVICE_VOLT"+"-COUNT", value: []});
      // this.myData.push({name:"IOTDEVICE_VOLT"+"-LAST", value: []});

      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-AVG", value: []});
      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-MIN", value: []});
      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-MAX", value: []});
      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-SUM", value: []});
      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-COUNT", value: []});
      // this.myData.push({name:"IOTDEVICE_COUNTER"+"-LAST", value: []});
    
      this.log("Device Chart", "ngOnInit", "getTelemetry");
      this.getTelemetry();
  }
  public OnQuery():void{
    this.getTelemetry();
    
  }
  public OnDownload(): void {
    const groupedData: { [key: string]: any } = {};
    //console.log("MY-DATA", this.myData);
    for (const entry of this.myData) {
      if (entry.name.startsWith("IOTDEVICE")) continue; // Skip IOTDEVICE metrics

      const splitIndex = entry.name.lastIndexOf(".");
      if (splitIndex === -1) continue;

      const baseName = entry.name.substring(0, splitIndex);
      const metric = entry.name.substring(splitIndex + 1);

      if (!groupedData[entry.name]) {
        groupedData[entry.name] = {};
      }

      groupedData[entry.name] = {"avgValue": entry.avgValue, "minValue": entry.minValue, "maxValue": entry.maxValue, "sumValue": entry.sumValue, "countValue": entry.countValue};
    }
    //console.log("GROUPED-DATA", groupedData);
    // Format JSON data
    const exportData = {
      queryInfo: {
        startDate: this.startDate.toISOString(),
        endDate: this.endDate.toISOString(),
        interval: this.intervalValue
      },
      labels: this.labels,
      data: groupedData
    };

    // Convert to JSON and create a Blob for download
    const jsonContent = JSON.stringify(exportData, null, 2);
    const blob = new Blob([jsonContent], { type: 'application/json' });
    const link = document.createElement("a");
    const url = URL.createObjectURL(blob);
    link.setAttribute("href", url);
    link.setAttribute("download", "chart_data.json");
    link.style.visibility = 'hidden';

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
  public changeInterval(newValue: any)
  {
    this.intervalValue = newValue;
  }
  public changeQuery(newValue: any){
    
    this.periodValue = newValue;
    const now = new Date();
    switch(this.periodValue) {
      case 0:
        this.startDate=new Date(now.getTime() - 60 * 60 * 1000);
        break;
      case 1:      
        this.startDate=new Date(now.getTime() - 24* 60 * 60 * 1000);
        break;
      case 2:
        this.startDate=new Date(now.getTime() - 7* 24* 60 * 60 * 1000);
        break;
      case 3:
        this.startDate=new Date(now);
        this.startDate.setMonth(now.getMonth()-1);
        break;
      case 4:
        this.startDate=new Date(now);
        this.startDate.setMonth(now.getMonth()-3);
        break;
      case 5:
        this.startDate=new Date(now);
        this.startDate.setFullYear(now.getFullYear()-1);
        break;
    }
    
  }
  private getIntervalInMilliseconds(window: string): number {
    const interval = Number(window.substring(0, window.length - 1));
    const unit =  window.substring(window.length - 1);
    switch(unit) {
      case 'm':
        return interval * 60 * 1000;
      case 'h':
        return interval * 60 * 60 * 1000;
      case 'd':
        return interval * 24 * 60 * 60 * 1000;
      case 'M':
        return interval * 30 * 24 * 60 * 60 * 1000;
      case 'Y':
        return interval * 365 * 24 * 60 * 60 * 1000;
    }
    return 0;
  }
  private createLabels(startDate:Date, window: string, numberOfWindows:number): void {
    this.labels = new Array();
    const unit =  window.substring(window.length - 1);
    const intervalms = this.getIntervalInMilliseconds(window);
    for (let i = 0; i < numberOfWindows; i++) {
      const date = new Date(startDate.getTime() + i * intervalms);
      switch (unit) {
        case 'm':
          this.labels.push(date.getHours().toString().padStart(2, '0') + ':'+date.getMinutes().toString().padStart(2, '0'));
          break;
        case 'h':
          this.labels.push(date.getHours().toString().padStart(2, '0') + ':00');
          break;
        case 'd':
          this.labels.push(date.getMonth() + '/' + date.getDate().toString().padStart(2, '0'));
          break;
        case 'M':
          this.labels.push(date.getFullYear() +"/"+date.getMonth().toString().padStart(2, '0') );
          break;
        case 'Y':
          this.labels.push(date.getFullYear());
          break;
      }
      
    }
    console.log("LABELS",this.labels);
  }
  public onSeriesClick(event: SeriesClickEvent): void {
    // console.log("SERIES-CLICK", event);
    // const category = event.category;
    
    // const value = event.value;
    // this.clickedData = `Category: ${category}, Value: ${value}`;
  }
  public getTelemetry() {

    //let endDate = new Date();
    //let startDate =new Date(endDate.getTime() -  7*24* 60 * 60 * 1000);
    console.log("START", this.startDate);
    console.log("END", this.endDate);
    console.log("INTERVAL", this.intervalValue);

    let window = this.intervalValue;
    const diffInMs = this.endDate.getTime() - this.startDate.getTime();
    const numberOfWindows = Math.ceil(diffInMs / this.getIntervalInMilliseconds(window));
    console.log("NUMBER OF WINDOWS", numberOfWindows);
    this.createLabels(this.startDate, window, numberOfWindows);
     
    console.log("DATA",this.myData);
    var mData = new Array();
    this.service.DeviceTelemetryService.gets(this.devicePublished.deviceId,this.startDate,this.endDate,window).subscribe((result) => {
        console.log("RESULT-DEVICE-TELEMETRY", result);
        if (result.isOk) {
          console.log("TELEMETRY-DATA",result);
          result.value.forEach((element) => {
            
            let domain =  mData.find(o=>o.name === element.name);
            if (domain === undefined) {
                //console.log("ADDING DOMAIN:"+ element.name);
                mData.push({name:element.name, 
                  avgValue: new Array(numberOfWindows).fill(null),
                  minValue: new Array(numberOfWindows).fill(null),
                  maxValue: new Array(numberOfWindows).fill(null),
                  sumValue: new Array(numberOfWindows).fill(null),
                  countValue: new Array(numberOfWindows).fill(null)
                });                
            }
            var item = mData.find(o=>o.name === element.name);
            item.avgValue[element.windowIdx] = Math.ceil(element.avg * 1000) / 1000;
            item.minValue[element.windowIdx] = Math.ceil(element.min * 1000) / 1000;
            item.maxValue[element.windowIdx] = Math.ceil(element.max * 1000) / 1000;
            item.sumValue[element.windowIdx] = 0;
            item.countValue[element.windowIdx] = element.count;
            
            this.dataChart[element.name] = new MyChartData();            
            this.dataChart[element.name].avgValue = item.avgValue;
            this.dataChart[element.name].minValue = item.minValue;
            this.dataChart[element.name].maxValue = item.maxValue;
            this.dataChart[element.name].sumValue = item.sumValue;
            this.dataChart[element.name].countValue = item.countValue;
            this.dataChart[element.name].rangeValues = [];
            for (let i = 0; i < item.minValue.length; i++) {
              this.dataChart[element.name].rangeValues.push({min:item.minValue[i], max:item.maxValue[i]});
            }
            
            //console.log("UPDATED DOMAIN:",this.myData.find(o=>o.name === element.name));
         
          });
          
          for (let meas of this.devicePublished.settings.measurements)
          {
              for (let data of mData){
                  if (data.name.slice(0, meas.name.length) === meas.name) {
                    meas.name = data.name;
                  }
              }
          }
          for (let state of this.devicePublished.settings.states)
          {
              for (let data of mData){
                  if (data.name.slice(0, state.name.length) === state.name) {
                    state.name = data.name;
                  }
              }
          }
          for (let alert of this.devicePublished.settings.alerts)
          {
              for (let data of mData){
                  if (data.name.slice(0, alert.name.length) === alert.name) {
                    alert.name = data.name;
                  }
              }
          }
          this.myData = mData;
          // for (let i = 0; i < this.myData.length; i++) {
          //   this.myData[i].avgValue = [...this.myData[i].avgValue];
          //   this.myData[i].minValue = [...this.myData[i].minValue];
          //   this.myData[i].maxValue = [...this.myData[i].maxValue];
          //   this.myData[i].sumValue = [...this.myData[i].sumValue];
          //   this.myData[i].countValue = [...this.myData[i].countValue];

          // }
          console.log("CHARTDATA",this.dataChart);
          console.log("DATA2",this.myData);
        } 
        else {
          console.log("No messages found.");
        }
      });
  }
  // public getDataForChart(name, subName):any {
  //   //let domain = this.TelemetryData.get(name)
  //   return;
  //   //console.log("DATA-CHART",name, subName, this.myData.find(o=>o.name === name));
  //   if (this.myData.find(o=>o.name === name)===undefined){
  //     //console.log("NO-DATA-FOR-CHART",name);
  //     return null;
  //   }
  //   if (subName=='AVG'){
  //     this.dataChart[name+"-"+subName] = this.myData.find(o=>o.name === name).avgValue;
  //     return this.dataChart[name+"-"+subName];
  //   }
  //   else if (subName=='MIN'){
  //     this.dataChart[name+"-"+subName] = this.myData.find(o=>o.name === name).minValue;
  //     return this.dataChart[name+"-"+subName];
  //   }
  //   if (subName=='MAX'){
  //     this.dataChart[name+"-"+subName] = this.myData.find(o=>o.name === name).maxValue;
  //     return this.dataChart[name+"-"+subName];
  //   }
  //   else if (subName=='SUM'){
  //     this.dataChart[name+"-"+subName] = this.myData.find(o=>o.name === name).sumValue;
  //     return this.dataChart[name+"-"+subName];
  //   }
  //   else if (subName=='COUNT'){
  //     this.dataChart[name+"-"+subName] = this.myData.find(o=>o.name === name).countValue;
  //     return this.dataChart[name+"-"+subName];
  //   }
    
  //   return null;
  // }
  // public getDataForRangeChart(name):any {
  //   return;
  //   var data =[];
  //   if (this.myData.find(o=>o.name === name)===undefined){
  //     //console.log("NO-DATA-FOR-RANGE-CHART",name);
  //     return null;
  //   }
  //   //console.log("RANGE-CHART",name, this.myData.find(o=>o.name === name));
  //   var dataMin = this.myData.find(o=>o.name === name).minValue;
  //   var dataMax = this.myData.find(o=>o.name === name).maxValue;
  //   for (let i = 0; i < dataMin.length; i++) {
  //     data.push({min:dataMin[i], max:dataMax[i]});
  //   }
    
  //   return data;
  // }
}
export
class MyChartData{
  name:string;
  avgValue:any[]
  minValue:any[]
  maxValue:any[]
  sumValue:any[]
  countValue:any[]
  rangeValues:any[]
}
