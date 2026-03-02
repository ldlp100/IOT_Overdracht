import { Component, OnInit, Input, Output, ViewChild, EventEmitter, OnChanges,SimpleChanges } from '@angular/core';
import { GridDataResult, DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import * as allIcons from "@progress/kendo-svg-icons";
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../base.component';
import { Stream } from 'stream';
import { CONDITIONAL_TYPES } from '@babel/types';
import {
  LoaderType,
  LoaderThemeColor,
  LoaderSize,
} from "@progress/kendo-angular-indicators";

@Component({
  selector: 'app-devicePublished',
  templateUrl: './devicePublished.component.html',
  styleUrls: ['./devicePublished.component.css']
})
export class DevicePublishedComponent extends BaseComponent implements OnInit, OnChanges {

  public device: DTO.DeviceDTO;
  public deviceMessageContent: DTO.DeviceMessageContentDTO;

  @Input() public devicePublished: DTO.DeviceDefinitionDTO;

  public id: string;
  public lastMessage: string;
  public initiated: boolean = false;
  public deviceInfos: DTO.DeviceInfoDTO;
  public periodData = [{value:0,text:"Last Hour"},{value:1,text:"Last Day"},{value:2,text:"Last Week"},{value:3,text:"Last Month"},{value:4,text:"Last Quarter"},{value:5,text:"Last Year"}]
  public intervalData = [{value:0,text:"Minute"},{value:1,text:"Hour"},{value:2,text:"Day"},{value:3,text:"Week"},{value:4,text:"Month"},{value:5,text:"Quarter"},,{value:6,text:"Year"}]
  public startDate: Date = new Date();
  public endDate: Date = new Date();
  public intervalValue: number = 0;
  public periodValue: number = 0;
  public icon = allIcons;
  public icons = { reload: this.icon.arrowRotateCwIcon, searchIcon: this.icon.searchIcon, save: this.icon.saveIcon };
  public loader = 
    {
      type: <LoaderType>"pulsing",
      themeColor: <LoaderThemeColor>"primary",
      size: <LoaderSize>"medium",
    };
  constructor(private service: IoTExService, private _router: Router, private _activatedRoute: ActivatedRoute) {
    super();
  }
  public ngOnChanges(changes: SimpleChanges){
    
    this.service.deviceService.getDevice(this.id).subscribe((result) => {
      console.log("RESULT", result);
      this.device = result.value;
      this.service.deviceService.getPublishDevice(this.device.deviceTypeId, this.device.deviceBatchId, this.device.id).subscribe((result) => {
        this.devicePublished = result.value;
        this.refresh();
        
      });
      
    });
  }
  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  }

  public ngOnInit(): void {
    this.id = this._activatedRoute.snapshot.paramMap.get('deviceId');

    this.service.deviceService.getDevice(this.id).subscribe((result) => {
      console.log("RESULT-DEVICE", result.value);
      this.device = result.value;
      this.service.deviceService.getPublishDevice(this.device.deviceTypeId, this.device.deviceBatchId, this.device.id).subscribe((result) => {
        console.log("RESULT-PUBLISHED-DEVICE", result.value);
        this.devicePublished = result.value;
        this.refresh();
        
      });
      
    });
    
    
  };
  public OnQuery():void{
    this.getLastMessage();
  }
  public getLastMessage() {

    this.service.deviceMessageService.getLastMessage(this.device.deviceTypeId, this.device.deviceBatchId, this.device.id).subscribe((result) => {
        console.log("RESULT-DEVICE-MESSAGE", result);
        if (result.isOk) {
          //Strip more events in more messages
          this.deviceMessageContent = new DTO.DeviceMessageContentDTO();
          this.deviceMessageContent.rcvDateTime = result.value.rcvDateTime;
          this.deviceMessageContent.events = [];
          
          for (let i=result.value.events.length ;i>0; i--){
            
            if (this.deviceMessageContent.events.filter(e => e.name == result.value.events[i-1].name).length==0){
              this.deviceMessageContent.events.push(result.value.events[i-1]);
            }
          }
          this.deviceMessageContent.events.sort((a, b) => a.name.localeCompare(b.name));
          this.lastMessage =this.deviceMessageContent.rcvDateTime.toString();

        } 
        else {
          console.log("No messages found.");
        }
      });
  }
  public getDevicePublishedInfo(){
    this.service.deviceService.getPublishDevice(this.device.deviceTypeId, this.device.deviceBatchId, this.device.id).subscribe((result) => {
      console.log("RESULT-PUBLISHED-DEVICE", result);
      if (result.isOk){
        this.devicePublished = result.value;
        this.deviceInfos = this.devicePublished.info;

      }
      this.initiated = true;
    });
  }
  public getEventValue(event: DTO.DocumentTelemetryEventDTO): string {
    if (event.type== DTO.DeviceEventType.ALERT){

      const evt = this.devicePublished.settings.alerts.filter((alert) => (alert.name == event.name));
      if (evt.length>0){
        const arr = evt[0].values.filter((alert) => alert.value == event.value);
          if (arr.length>0)
            return arr[0].name;          
      }
    }
    if (event.type== DTO.DeviceEventType.STATE){
      const evt = this.devicePublished.settings.states.filter((state) => (state.name == event.name));
      if (evt.length>0){
        const arr = evt.values[0].filter((alert) => alert.value == event.value);
          if (arr.length>0)
            return arr[0].name;          
      }
    }
    return event.value.toFixed(3);
    
  }
  public refresh() {
    console.log("REFRESH");
    this.getDevicePublishedInfo();
    this.getLastMessage();
  }

}
